using System;
using UnityEngine;

namespace Game.Configs {
    [Serializable]
    public class PrefabItem : ConfigItem<string, GameObject> { }

    public class PrefabsConfig : ScriptableObjectConfig<PrefabItem, string, GameObject> {
        [SerializeField] private PrefabItem[] _items;
        protected override PrefabItem[] Items { get { return _items; } }

        public GameObject GetPrefab(string id) {
            return GetItem(id);
        }
    }
}