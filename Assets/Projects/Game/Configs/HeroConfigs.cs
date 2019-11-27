using System;
using System.Collections.Generic;
using System.Linq;
using Game.Model;
using UnityEngine;

namespace Game.Configs {
    [Serializable]
    public struct HeroParams {
        public AbilityType AbilityType;
        public int PriceValue;
        public int MaxAbilityUsages;
    }
    
    // ReSharper disable once ClassNeverInstantiated.Global
    [Serializable]
    public class HeroItem : ConfigItem<HeroType, HeroParams> { }

    public class HeroConfigs : ScriptableObject {
        [SerializeField] private HeroItem[] _heroParams;
        private List<HeroInfo> _infos;

        public HeroInfo GetInfo(HeroType type) {
            if (_infos == null)
                Init();
            return _infos.FirstOrDefault(info => info.Type == type);
        }

        private void Init() {
            var count = _heroParams.Length;
            _infos = new List<HeroInfo>(count);
            for (var i = 0; i < count; ++i) {
                var item = _heroParams[i];
                var price = new Price(item.Item.PriceValue);
                var info = new HeroInfo(item.Id, item.Item.AbilityType, price, item.Item.MaxAbilityUsages);
                _infos.Add(info);
            }
        }
    }
}