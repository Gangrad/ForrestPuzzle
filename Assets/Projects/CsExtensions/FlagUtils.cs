namespace CsExtensions {
    public static class FlagUtils {
        //-----------------------------byte
        
        public static byte SetFlag(this byte container, bool value, byte mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref byte container, bool value, byte mask) {
            if (value)
                container |= mask;
            else {
                int tmp = container & ~mask;
                container = (byte) tmp;
            }
        }

        public static bool Flag(this byte container, byte mask) {
            return (container & mask) > 0;
        }
        
        //-----------------------------short
        
        public static short SetFlag(this short container, bool value, short mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref short container, bool value, short mask) {
            if (value)
                container |= mask;
            else {
                int tmp = container & ~mask;
                container = (byte) tmp;
            }
        }
        
        public static short SetFlag(this short container, bool value, byte mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref short container, bool value, byte mask) {
            if (value) {
                var maskShort = (short) mask;
                container |= maskShort;
            }
            else {
                int tmp = container & ~mask;
                container = (byte) tmp;
            }
        }

        public static bool Flag(this short container, short mask) {
            return (container & mask) > 0;
        }

        public static bool Flag(this short container, byte mask) {
            return (container & mask) > 0;
        }
        
        //-----------------------------int
        
        public static int SetFlag(this int container, bool value, int mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref int container, bool value, int mask) {
            if (value)
                container |= mask;
            else {
                int tmp = container & ~mask;
                container = (byte) tmp;
            }
        }
        
        public static int SetFlag(this int container, bool value, short mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref int container, bool value, short mask) {
            if (value) {
                var maskInt = (int) mask;
                container |= maskInt;
            }
            else {
                int tmp = container & ~mask;
                container = (byte) tmp;
            }
        }
        
        public static int SetFlag(this int container, bool value, byte mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref int container, bool value, byte mask) {
            if (value)
                container |= mask;
            else {
                int tmp = container & ~mask;
                container = (byte) tmp;
            }
        }

        public static bool Flag(this int container, int mask) {
            return (container & mask) > 0;
        }

        public static bool Flag(this int container, short mask) {
            return (container & mask) > 0;
        }

        public static bool Flag(this int container, byte mask) {
            return (container & mask) > 0;
        }
        
        //-----------------------------long
        
        public static long SetFlag(this long container, bool value, long mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref long container, bool value, long mask) {
            if (value)
                container |= mask;
            else {
                long tmp = container & ~mask;
                container = (byte) tmp;
            }
        }
        
        public static long SetFlag(this long container, bool value, int mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref long container, bool value, int mask) {
            if (value) {
                var maskLong = (long) mask;
                container |= maskLong;
            }
            else {
                long tmp = container & ~mask;
                container = (byte) tmp;
            }
        }
        
        public static long SetFlag(this long container, bool value, short mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref long container, bool value, short mask) {
            if (value) {
                var maskLong = (long) mask;
                container |= maskLong;
            }
            else {
                long tmp = container & ~mask;
                container = (byte) tmp;
            }
        }
        
        public static long SetFlag(this long container, bool value, byte mask) {
            SetFlag(ref container, value, mask);
            return container;
        }
        
        public static void SetFlag(ref long container, bool value, byte mask) {
            if (value)
                container |= mask;
            else {
                long tmp = container & ~mask;
                container = (byte) tmp;
            }
        }

        public static bool Flag(this long container, long mask) {
            return (container & mask) > 0;
        }

        public static bool Flag(this long container, int mask) {
            return (container & mask) > 0;
        }

        public static bool Flag(this long container, short mask) {
            return (container & mask) > 0;
        }

        public static bool Flag(this long container, byte mask) {
            return (container & mask) > 0;
        }
    }
}