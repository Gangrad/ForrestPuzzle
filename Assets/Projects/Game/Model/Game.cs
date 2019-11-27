using System.Collections.Generic;
using System.Linq;
using CsExtensions;
using Game.GameEntity;
using UnityEngine;

namespace Game.Model {
    public enum StatusCode {
        Ok,
        WrongArgument,
        NotEnoughForestPoints
    }
    
    public class Game {
        public HeroInfo[] AvailableHeroes { get; private set; }
        public int ForestPoints { get; private set; }
        public int CharactersSaved { get; private set; }
        public int CharactersLost { get; private set; }
        public int CharactersAlive { get { return _characters.Count; } }
        private readonly List<SeedlingCharacter> _characters = new List<SeedlingCharacter>();
        private Transform _root;
        private Transform _heroesRoot;
        public readonly Signal OnChanged = new Signal();
        public readonly Signal<GameResult> OnGameOver = new Signal<GameResult>();

        public void StartGame(Transform root, HeroInfo[] heroes, int forestPoints, SeedlingCharacter[] characters) {
            AvailableHeroes = heroes;
            ForestPoints = forestPoints;
            for (int i = 0, count = characters.Length; i < count; ++i) {
                var character = characters[i];
                character.SubscribeToEnterInPortal(() => OnSeedlingEnterInPortal(character))
                    .SubscribeToCollideWithWall(obj => OnSeedlingCollideWithWall(character, obj))
                    .SubscribeToFellIntoAbyss(() => OnSeedlingFellIntoAbyss(character));
            }
            _characters.AddRange(characters);
            _root = root;
            var heroesRootObj = new GameObject("HeroesRoot");
            _heroesRoot = heroesRootObj.transform;
            _heroesRoot.SetParent(_root, false);
            _heroesRoot.SetSiblingIndex(_root.childCount - 2);
        }

        public StatusCode PlaceHero(HeroType type, Vector2 position) {
            var info = AvailableHeroes.FirstOrDefault(hero => hero.Type == type);
            if (info == null) {
                Debug.LogErrorFormat("[Game]: Trying to place hero of unknown type: {0}", type);
                return StatusCode.WrongArgument;
            }
            if (ForestPoints < info.Price.Value) {
                Debug.LogFormat("[Game]: Cant create hero {0}: price: {1}, available: {2}", 
                    type, info.Price.Value, ForestPoints);
                return StatusCode.NotEnoughForestPoints;
            }
            if (!CreateHero(type, position))
                return StatusCode.WrongArgument;
            ForestPoints -= info.Price.Value;
            OnChanged.Dispatch();
            return StatusCode.Ok;
        }

        private bool CreateHero(HeroType type, Vector2 position) {
            var prefab = Share.Configs.HeroInstances.GetPrefab(type.ToString());
            if (prefab == null) {
                Debug.LogErrorFormat("[Game]: Cant find prefab for hero of type {0}", type);
                return false;
            }
            var instance = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity, _heroesRoot);
            var hero = instance.GetComponent<WallHeroInstance>();
            if (hero == null) {
                Debug.LogErrorFormat("[Game]: Hero object doesnt contains hero script, prefab: {0}", prefab.name);
                UnityEngine.Object.Destroy(instance);
                return false;
            }

            hero.SubscribeToAbilitiesEnded(() => OnHeroUsedAllAbilities(hero))
                .SubscribeToFellIntoAbyss(() => OnHeroFellIntoAbyss(hero));
            return true;
        }

        private void OnSeedlingEnterInPortal(SeedlingCharacter character) {
            CharactersSaved++;
            DestroySeedling(character);
            OnChanged.Dispatch();
            CheckGameOver();
        }

        private void OnSeedlingCollideWithWall(SeedlingCharacter character, GameObject wallObj) {
            var hero = wallObj.GetComponent<WallHeroInstance>();
            if (hero == null) {
                Debug.LogErrorFormat("[Game]: Seedling collided with a wall but there is no hero, wall obj: {0}", 
                    wallObj.name);
                return;
            }
            if (hero.TryUseAbility())
                character.TurnAround();
        }

        private void OnSeedlingFellIntoAbyss(SeedlingCharacter character) {
            CharactersLost++;
            DestroySeedling(character);
            OnChanged.Dispatch();
            CheckGameOver();
        }

        private void DestroySeedling(SeedlingCharacter character) {
            _characters.Remove(character);
            UnityEngine.Object.Destroy(character.gameObject);
        }

        private void CheckGameOver() {
            if (_characters.Count == 0) {
                var result = CharactersSaved > 0 ? GameResult.Victory : GameResult.Defeat;
                Debug.LogFormat("[Game]: Game over. Result: {0}", result);
                OnGameOver.Dispatch(result);
            }
        }

        private void OnHeroUsedAllAbilities(WallHeroInstance hero) {
            UnityEngine.Object.Destroy(hero.gameObject);
        }

        private void OnHeroFellIntoAbyss(WallHeroInstance hero) {
            UnityEngine.Object.Destroy(hero.gameObject);
        }
    }
}