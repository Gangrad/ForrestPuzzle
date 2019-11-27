using System;
using CsExtensions;
using Game.Model;
using UnityEngine;

namespace Game.UI {
    public class TempMovableGameObject : IDisposable {
        private readonly GameObject _obj;

        public TempMovableGameObject(GameObject obj) {
            _obj = obj;
        }

        public void Move(Vector2 pos) {
            _obj.transform.position = pos;
        }

        public void Dispose() {
            UnityEngine.Object.Destroy(_obj);
        }
    }
    
    public class HeroPlacer : IDisposable {
        private readonly Transform _root;
        private HeroType _type;
        private Vector2 _pos;
        private TempMovableGameObject _obj;
        public readonly Signal<HeroType, Vector2> PlaceHero = new Signal<HeroType, Vector2>();

        public HeroPlacer(Transform root) {
            _root = root;
        }
        
        public void OnStartDrag(HeroInfo info) {
            Debug.LogFormat("Select hero {0}", info.Type);
            var prefab = Share.Configs.HeroPreviews.GetPrefab(info.Type.ToString());
            if (prefab == null) {
                Debug.LogErrorFormat("[HeroPlacer]: Cant find preview prefab for hero {0}", info.Type);
                return;
            }
            _type = info.Type;
            var obj = UnityEngine.Object.Instantiate(prefab, _root);
            _obj = new TempMovableGameObject(obj);
        }

        public void OnDrag(Vector2 position) {
            if (_obj == null) 
                return;
            _pos = position;
            _obj.Move(position);
        }

        public void DropHero(Vector2 position) {
            Debug.LogFormat("Drop hero in {0}", position);
            if (_obj == null) 
                return;
            PlaceHero.Dispatch(_type, _pos);
            _obj.Dispose();
        }

        public void Dispose() {
            _obj.SafeDispose();
        }
    }
}