using System;

namespace CsExtensions {
    public static class MathUtils {
        /// <summary>
        /// Строгое сравнение
        /// </summary>
        public static bool Inside<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) > 0 && val.CompareTo(max) < 0;
        }

        /// <summary>
        /// Нестрогое сравнение слева
        /// </summary>
        public static bool InsideLeft<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) >= 0 && val.CompareTo(max) < 0;
        }

        /// <summary>
        /// Нестрогое сравнение справа
        /// </summary>
        public static bool InsideRight<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) > 0 && val.CompareTo(max) <= 0;
        }

        /// <summary>
        /// Нестрогое сравнение с обеих сторон
        /// </summary>
        public static bool InsideBoth<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) >= 0 && val.CompareTo(max) <= 0;
        }

        /// <summary>
        /// Строгое сравнение
        /// </summary>
        public static bool Outside<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) < 0 && val.CompareTo(max) > 0;
        }

        /// <summary>
        /// Нестрогое сравнение слева
        /// </summary>
        public static bool OutsideLeft<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) <= 0 && val.CompareTo(max) > 0;
        }

        /// <summary>
        /// Нестрогое сравнение справа
        /// </summary>
        public static bool OutsideRight<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) < 0 && val.CompareTo(max) >= 0;
        }

        /// <summary>
        /// Нестрогое сравнение с обеих сторон
        /// </summary>
        public static bool OutsideBoth<T>(T min, T max, T val) where T : IComparable<T> {
            return val.CompareTo(min) <= 0 && val.CompareTo(max) >= 0;
        }
    }
}