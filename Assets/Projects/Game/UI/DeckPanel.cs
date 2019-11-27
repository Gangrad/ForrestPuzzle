using System;
using CsExtensions;
using Game.Model;
using UnityEngine;

namespace Game.UI {
    public class DeckPanel : MonoBehaviour, IDisposable {
        [SerializeField] private HeroPanel[] _heroes;
        private readonly DisposableCollection _disposableCollection = new DisposableCollection();

        public void Fill(HeroInfo[] heroes, HeroPlacer heroPlacer) {
            var count = heroes.Length;
            if (count > _heroes.Length) {
                Debug.LogErrorFormat("Cant fill deck panel: available {0} hero panels but received {1} items",
                    _heroes.Length, count);
                count = _heroes.Length;
            }

            _disposableCollection.Dispose();
            for (var i = 0; i < count; ++i) {
                var panel = _heroes[i];
                var hero = heroes[i];
                panel.Fill(hero);
                panel.OnStartDragEvent.Subscribe(() => heroPlacer.OnStartDrag(hero)).DisposeBy(_disposableCollection);
                panel.OnDragEvent.Subscribe(heroPlacer.OnDrag).DisposeBy(_disposableCollection);
                panel.OnDropEvent.Subscribe(heroPlacer.DropHero).DisposeBy(_disposableCollection);
                panel.gameObject.SetActive(true);
            }
            for (int i = count, size = _heroes.Length; i < size; ++i)
                _heroes[i].gameObject.SetActive(false);
        }

        private void OnDestroy() {
            Dispose();
        }

        public void Dispose() {
            _disposableCollection.Dispose();
        }
    }
}