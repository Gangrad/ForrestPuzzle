using System;

namespace CsExtensions {
    /// <summary>
    /// Рандомные интовые числа. Равномерное распределение.
    /// </summary>
    public class RandomInt {
        private static long _seed = DateTime.Now.Ticks;

        private static int NextSeed() {
            unchecked {
                int res = (int) _seed ^ (int) (_seed >> 32);
                _seed = _seed*179 ^ (_seed >> 12);
                return res;
            }
        }

        public readonly int Seed;
        private uint _hi;
        private uint _lo;

        public RandomInt() {
            Seed = NextSeed();
            unchecked {
                _hi = (uint)(Seed*41203 ^ (Seed << 12));
                _lo = (uint)(Seed*27011 ^ (Seed >> 18));
            }
        }

        /// <summary>
        /// value in range [0, max)
        /// </summary>
        public int Value(int max) {
            return Range(0, max);
        }

        /// <summary>
        /// value in range [min, max)
        /// </summary>
        public int Range(int min, int max) {
            int r = max - min;
            if (r <= 0)
                throw new ArgumentException(string.Format("Wrong random range: min={0}, max={1}", min, max));
            var v = (int)((_hi ^ _lo)%r);
            unchecked {
                _hi = (_hi >> 8)*9721;
                _lo = (_lo >> 16)*84631;
            }
            return v + min;
        }
    }
}