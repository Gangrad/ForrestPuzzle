using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unity.Utils {
    public static class SliderUtils {
        public static void SetOnChangedAction(this Slider slider, Action<float> action) {
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(new UnityAction<float>(action));
        }
    }
}