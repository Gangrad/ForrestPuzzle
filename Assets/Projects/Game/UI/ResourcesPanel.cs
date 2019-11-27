using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class ResourcesPanel : MonoBehaviour {
        [SerializeField] private Text _label;

        public void Fill(int forestPoints) {
            _label.text = forestPoints.ToString();
        }
    }
}