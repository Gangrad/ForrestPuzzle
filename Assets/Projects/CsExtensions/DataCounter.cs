using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsExtensions {
    public class DataCounter<T> {
        private readonly Dictionary<T, int> _data;

        public DataCounter() {
            _data = new Dictionary<T, int>();
        }

        public void Add(T value) {
            if (_data.ContainsKey(value))
                _data[value]++;
            else
                _data[value] = 1;
        }

        public List<KeyValuePair<T, int>> ToSortedList(bool descending = true) {
            var list = _data.ToList();
            list.Sort((v1, v2) => {
                int dv = v1.Value - v2.Value;
                if (dv == 0)
                    return 0;
                return dv > 0 ^ descending ? 1 : -1;
            });
            return list;
        }

        public string FormatString(string separator = "\n", bool descending = true, bool writeIf1 = true) {
            var list = ToSortedList(descending);
            if (list.Count == 0)
                return "";
            var sb = new StringBuilder();
            var val = list[0];
            if (val.Value == 1 && !writeIf1)
                sb.Append(val.Key.ToString());
            else
                sb.AppendFormat("{0} ({1})", val.Key.ToString(), val.Value.ToString());
            for (var i = 1; i < list.Count; ++i) {
                val = list[i];
                if (val.Value == 1 && !writeIf1)
                    sb.AppendFormat("{0}{1}", separator, val.Key.ToString());
                else
                    sb.AppendFormat("{0}{1} ({2})", separator, val.Key.ToString(), val.Value.ToString());
            }
            return sb.ToString();
        }
    }
}