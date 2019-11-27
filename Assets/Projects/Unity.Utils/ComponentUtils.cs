using System;
using System.Text;
using UnityEngine;

namespace Unity.Utils {
    public static class ComponentUtils {
        public static void SetObjectActive<T>(this T comp, bool state) where T : Component {
            comp.gameObject.SetActive(state);
        }

        public static void SetLabelText<T>(this T comp, string text) where T : Component {
            if (comp != null)
                comp.gameObject.SetLabelText(text);
        }

        public static string FullName<T>(this T comp, string separator = ".") where T : Component {
            if (comp == null)
                return string.Empty;
            var sb = new StringBuilder();
            var tr = comp.transform;
            sb.Append(tr.name);
            tr = tr.parent;
            while (tr != null) {
                sb.Insert(0, string.Format("{0}{1}", tr.name, separator));
                tr = tr.parent;
            }
            return sb.ToString();
        }
    }
}
