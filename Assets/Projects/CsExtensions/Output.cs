using System;
using System.Collections.Generic;
using System.Text;

namespace CsExtensions
{
    public static class Output
    {
        public enum BracketType {
            /// <summary> [] </summary>
            Square,

            /// <summary> () </summary>
            Round,

            /// <summary> {} </summary>
            Braces,
        }

        private static char BracketOpen(BracketType type) {
            switch (type) {
                case BracketType.Square:
                    return '[';
                case BracketType.Round:
                    return '(';
                case BracketType.Braces:
                    return '{';
                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }

        private static char BracketClose(BracketType type) {
            switch (type) {
                case BracketType.Square:
                    return ']';
                case BracketType.Round:
                    return ')';
                case BracketType.Braces:
                    return '}';
                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }

        public static string Format<T>(this IEnumerable<T> data, string separator = ", ", BracketType brackets = BracketType.Braces) {
            var sb = new StringBuilder();
            sb.Append(BracketOpen(brackets));
            if (data == null)
                sb.Append("NULL");
            else {
                var first = true;
                foreach (var e in data) {
                    if (!first)
                        sb.Append(separator);
                    sb.Append(e);
                    first = false;
                }
            }
            sb.Append(BracketClose(brackets));
            return sb.ToString();
        }
    }
}
