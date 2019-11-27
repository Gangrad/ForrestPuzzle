using System;
using CsExtensions;
using Game.Model;
using UnityEngine;

namespace Game.GameEntity {
    public class WallHeroInstance : MonoBehaviour {
        [SerializeField] private HeroType _type;
        private readonly Signal _onAbilitiesEnded = new Signal();
        private readonly Signal _onFellIntoAbyss = new Signal();
        private readonly DisposableCollection _disposableCollection = new DisposableCollection();
        
        public int AbilityUsagesLeft { get; private set; }

        private void Start() {
            var info = Share.Configs.Heroes.GetInfo(_type);
            AbilityUsagesLeft = info.AbilityMaxUsages;
        }

        private void OnDestroy() {
            _disposableCollection.Dispose();
        }

        public WallHeroInstance SubscribeToAbilitiesEnded(Action callback) {
            _onAbilitiesEnded.Subscribe(callback).DisposeBy(_disposableCollection);
            return this;
        }

        public WallHeroInstance SubscribeToFellIntoAbyss(Action callback) {
            _onFellIntoAbyss.Subscribe(callback).DisposeBy(_disposableCollection);
            return this;
        }

        public bool TryUseAbility() {
            if (AbilityUsagesLeft < 0)
                return false;
            AbilityUsagesLeft--;
            if (AbilityUsagesLeft == 0)
                _onAbilitiesEnded.Dispatch();
            return true;
        }
    }
}