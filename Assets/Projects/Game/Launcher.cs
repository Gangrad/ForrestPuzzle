using System;
using CsExtensions;
using Game.Model;
using Game.UI;
using UnityEngine;

namespace Game {
    public class Launcher : MonoBehaviour {
        [SerializeField] private PlayerControlPanel _controlPanel;
        [SerializeField] private Transform _gameRoot;
        [SerializeField] private GameOverPopup _gameOverPopup;
        private IDisposable _disposeGame;
        
        private void Start() {
            var heroes = new[]{Share.Configs.Heroes.GetInfo(HeroType.WallHero)};
            var seedlings = Share.CollectSeedlings();
            var game = new Model.Game();
            game.StartGame(_gameRoot, heroes, 2, seedlings);
            _disposeGame = game.OnGameOver.Subscribe(_gameOverPopup.Show);
            _controlPanel.Present(game);
        }

        private void OnDestroy() {
            _disposeGame.SafeDispose();
        }
    }
}