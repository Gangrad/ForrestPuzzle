using CsExtensions;
using Game.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI {
    public class HeroPanel : MonoBehaviour, IDragHandler, IEndDragHandler {
        [SerializeField] private Image _heroIcon;
        [SerializeField] private Text _priceLabel;
        [SerializeField] private Image _abilityIcon;
        [SerializeField] private Text _abilityUsages;
        public readonly Signal OnStartDragEvent = new Signal();
        public readonly Signal<Vector2> OnDragEvent = new Signal<Vector2>();
        public readonly Signal<Vector2> OnDropEvent = new Signal<Vector2>();
        private bool _dragging;
        
        public void Fill(HeroInfo info) {
            _heroIcon.sprite = Share.Configs.HeroIcons.GetImage(info.Type.ToString());
            _priceLabel.text = info.Price.Value.ToString();
            _abilityIcon.sprite = Share.Configs.AbilityIcons.GetImage(info.AbilityType.ToString());
            _abilityUsages.text = info.AbilityMaxUsages.ToString();
        }

        public void OnDrag(PointerEventData eventData) {
            if (!_dragging) {
                OnStartDragEvent.Dispatch();
                _dragging = true;
            }
            OnDragEvent.Dispatch(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData) {
            OnDropEvent.Dispatch(eventData.position);
            _dragging = false;
        }
    }
}