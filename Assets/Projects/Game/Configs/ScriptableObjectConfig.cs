using System;
using UnityEngine;

namespace Game.Configs {
    [Serializable]
    public class ConfigItem<TId, TItem> {
        public TId Id;
        public TItem Item;
    }
    
    public abstract class ScriptableObjectConfig<TConfigItem, TId, TItem> : ScriptableObject where TConfigItem : ConfigItem<TId, TItem>  {
        protected abstract TConfigItem[] Items { get; }

        protected TItem GetItem(TId id) {
            for (int i = 0, count = Items.Length; i < count; ++i) {
                var item = Items[i];
                if (item.Id.Equals(id))
                    return item.Item;
            }
            return default(TItem);
        }
    }
}