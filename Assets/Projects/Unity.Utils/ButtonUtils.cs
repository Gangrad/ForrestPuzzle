using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unity.Utils {
    public static class ButtonUtils {
        public static void SetOnClickAction(this Button button, Action action) {
            button.onClick.RemoveAllListeners();
            if (action != null)
                button.onClick.AddListener(new UnityAction(action));
        }

        public static void SetOnClickOnceAction(this Button button, Action action) {
            Action onClickAction = () => {
                action();
                button.onClick.RemoveAllListeners();
            };
            button.SetOnClickAction(onClickAction);
        }
    }
}
