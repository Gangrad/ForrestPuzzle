using System;
using CsExtensions;
using Game.Model;
using UnityEngine;

namespace Game.UI {
    public class PlayerControlPanel : MonoBehaviour {
        [SerializeField] private ResourcesPanel _resourcesPanel;
        [SerializeField] private DeckPanel _deckPanel;
        [SerializeField] private StatPanel _statPanel;
        private HeroPlacer _heroPlacer;
        private Model.Game _game;
        private readonly DisposableCollection _disposableCollection = new DisposableCollection();

        private void Awake() {
            _heroPlacer = new HeroPlacer(transform);
        }

        public void Present(Model.Game game) {
            _disposableCollection.Dispose();
            _game = game;
            _game.OnChanged.SubscribeAndInvoke(UpdateValues).DisposeBy(_disposableCollection);
            _game.OnGameOver.Subscribe(result => _disposableCollection.Dispose()).DisposeBy(_disposableCollection);
            _deckPanel.Fill(_game.AvailableHeroes, _heroPlacer);
            _statPanel.Present(_game);
            _heroPlacer.PlaceHero.Subscribe((type, pos) => _game.PlaceHero(type, pos)).DisposeBy(_disposableCollection);
            _heroPlacer.DisposeBy(_disposableCollection);
            _deckPanel.DisposeBy(_disposableCollection);
            _statPanel.DisposeBy(_disposableCollection);
        }

        private void UpdateValues() {
            _resourcesPanel.Fill(_game.ForestPoints);
        }

        private void OnDestroy() {
            _disposableCollection.Dispose();
        }
    }
}