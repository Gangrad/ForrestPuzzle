using UnityEngine;

namespace Game.Configs {
    public class Configs : MonoBehaviour {
        public HeroConfigs Heroes;
        public PrefabsConfig HeroInstances;
        public PrefabsConfig HeroPreviews;
        public ImagesConfig HeroIcons;
        public ImagesConfig AbilityIcons;

        private void Awake() {
            Share.Configs = this;
        }
    }
}