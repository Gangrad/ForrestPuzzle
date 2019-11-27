using System;
using CsExtensions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class StatPanel : MonoBehaviour, IDisposable {
        [SerializeField] private Text _label;
        private IDisposable _unsubscribe;
        private Model.Game _game;

        public void Present(Model.Game game) {
            _unsubscribe.SafeDispose();
            _game = game;
            _unsubscribe = _game.OnChanged.SubscribeAndInvoke(UpdateLabel);
        }

        private void UpdateLabel() {
            _label.text = string.Format("Alive: {0}\nSaved: {1}\nLost: {2}",
                _game.CharactersAlive, _game.CharactersSaved, _game.CharactersLost);
        }

        public void Dispose() {
            _unsubscribe.SafeDispose();
        }
    }
}