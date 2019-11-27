using System;
using System.Collections;
using Game.Model;
using Unity.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI {
    [Serializable]
    public class PopupSettings {
        public Color Color;
        public string Text;
    }
    
    public class GameOverPopup : MonoBehaviour {
        [SerializeField] private Text _label;
        [SerializeField] private PopupSettings _victory;
        [SerializeField] private PopupSettings _defeat;
        [SerializeField] private float _animationDuration;
        [SerializeField] private Button _reloadButton;
        private Coroutine _coroutine;

        public void Show(GameResult result) {
            var settings = result == GameResult.Victory ? _victory : _defeat;
            ImplementSettings(settings);
            gameObject.SetActive(true);
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(Animate());
        }

        private void ImplementSettings(PopupSettings settings) {
            _label.text = settings.Text;
            _label.color = settings.Color;
        }

        private IEnumerator Animate() {
            if (_animationDuration <= 0) {
                SetAnimationProgress(1f);
                _reloadButton.gameObject.SetActive(true);
                yield break;
            }
            
            _reloadButton.gameObject.SetActive(false);
            var startTime = Time.time;
            var endTime = startTime + _animationDuration;
            while (Time.time < endTime) {
                var progr = (Time.time - startTime) / _animationDuration;
                SetAnimationProgress(progr);
                yield return null;
            }
            SetAnimationProgress(1f);
            _reloadButton.gameObject.SetActive(true);
            _coroutine = null;
        }

        private void SetAnimationProgress(float progress) {
            _label.color = _label.color.ChangeAlpha(progress);
        }

        public void OnReloadButtonClick() {
            SceneManager.LoadScene(0);
        }
    }
}