using System.Collections.Generic;
using Game.GameEntity;

namespace Game {
    public static class Share {
        private static readonly List<SeedlingCharacter> _registeredSeedlings = new List<SeedlingCharacter>();
        public static Configs.Configs Configs;

        public static void RegisterSeedling(SeedlingCharacter seedling) {
            _registeredSeedlings.Add(seedling);
        }

        public static SeedlingCharacter[] CollectSeedlings() {
            var size = _registeredSeedlings.Count;
            var result = new SeedlingCharacter[size];
            for (var i = 0; i < size; ++i)
                result[i] = _registeredSeedlings[i];
            _registeredSeedlings.Clear();
            return result;
        }
    }
}