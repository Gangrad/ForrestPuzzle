using System;
using CsExtensions;
using Unity.Utils;
using UnityEngine;

namespace Game.GameEntity {
    public enum MoveDirection {
        Left,
        Right
    }

    public static class MoveDirectionUtils {
        public static MoveDirection Opposite(this MoveDirection dir) {
            return dir == MoveDirection.Left ? MoveDirection.Right : MoveDirection.Left;
        }
    }
    
    public class SeedlingCharacter : MonoBehaviour {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private MoveDirection _startDirection;
        [SerializeField] private float _moveForce;
        private bool _grounded;
        private MoveDirection _direction;
        private readonly Signal _onEnterPortal = new Signal();
        private readonly Signal<GameObject> _onCollideWithWall = new Signal<GameObject>();
        private readonly Signal _onFellIntoAbyss = new Signal();
        private readonly DisposableCollection _disposableCollection = new DisposableCollection();

        private void Awake() {
            Share.RegisterSeedling(this);
        }

        private void Start() {
            if (_startDirection != _direction)
                TurnAround();
        }

        private void FixedUpdate() {
            if (_grounded) {
                var force = new Vector2(_direction == MoveDirection.Right ? _moveForce : -_moveForce, 0);
                _rigidbody.AddForce(force, ForceMode2D.Force);
            }
        }

        private void OnDestroy() {
            _disposableCollection.Dispose();
        }

        public SeedlingCharacter SubscribeToEnterInPortal(Action callback) {
            _onEnterPortal.Subscribe(callback).DisposeBy(_disposableCollection);
            return this;
        }

        public SeedlingCharacter SubscribeToCollideWithWall(Action<GameObject> callback) {
            _onCollideWithWall.Subscribe(callback).DisposeBy(_disposableCollection);
            return this;
        }

        public SeedlingCharacter SubscribeToFellIntoAbyss(Action callback) {
            _onFellIntoAbyss.Subscribe(callback).DisposeBy(_disposableCollection);
            return this;
        }

        private void OnCollisionEnter2D(Collision2D other) {
            var obj = other.gameObject;
            if (IsPortal(obj)) {
                Debug.LogFormat("[SeedlingCharacter ({0})] Enter in portal {1}", name, obj.name);
                _onEnterPortal.Dispatch();
            }
            else if (IsAbyss(obj)) {
                Debug.LogFormat("[SeedlingCharacter ({0})] Fell into abyss", name);
                _onFellIntoAbyss.Dispatch();
            }
            else if (IsWall(obj)) {
                Debug.LogFormat("[SeedlingCharacter ({0})] Collide with a wall", name);
                _onCollideWithWall.Dispatch(obj);
            }
            else if (IsGround(obj))
                _grounded = true;
        }
        
        private void OnCollisionExit2D(Collision2D other) {
            if (IsGround(other.gameObject))
                CheckGrounded();
        }

        public void TurnAround() {
            _direction = _direction.Opposite();
            transform.localScale = _direction == MoveDirection.Left ? Vector3.one : new Vector3(-1f, 1f, 1f);
        }

        private void CheckGrounded() {
            var colliders = new Collider2D[16];
            var count = _rigidbody.GetContacts(colliders);
            for (var i = 0; i < count; ++i) {
                if (IsGround(colliders[i].gameObject)) {
                    _grounded = true;
                    return;
                }
            }
            _grounded = false;
        }

        private static bool IsGround(GameObject obj) {
            return obj.HasLayer("Ground");
        }

        private static bool IsWall(GameObject obj) {
            return obj.HasLayer("Hero");
        }

        private static bool IsPortal(GameObject obj) {
            return obj.HasLayer("Portal");
        }

        private static bool IsAbyss(GameObject obj) {
            return obj.HasLayer("Abyss");
        }
    }
}