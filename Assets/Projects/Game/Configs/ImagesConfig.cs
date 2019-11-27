using System;
using UnityEngine;

namespace Game.Configs {
    [Serializable]
    public class ImageItem : ConfigItem<string, Sprite> { }

    public class ImagesConfig : ScriptableObjectConfig<ImageItem, string, Sprite> {
        [SerializeField] private ImageItem[] _items;
        protected override ImageItem[] Items { get { return _items; } }

        public Sprite GetImage(string id) {
            return GetItem(id);
        }
    }
}