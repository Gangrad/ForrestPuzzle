using UnityEngine;

namespace Unity.Utils {
    public static class LayerUtils {
        public static int NameToLayerMask(string layer) {
            var layerNum = LayerMask.NameToLayer(layer);
            return 1 << layerNum;
        }
    }
}