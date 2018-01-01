using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCodes
{
    public static class SortHelpers
    {

        public static void QuickSort<T>(this IList<T> list, Comparison<T> comparision = null) where T : IComparable
        {
            if (list.Count <= 1) return;
            var comparer = Comparer<T>.Default;
            if (comparision != null)
            {
                comparer = Comparer<T>.Create(comparision);
            }
            QuickSortRecursion(list, 0, list.Count - 1, comparer);
        }

        private static void QuickSortRecursion<T>(this IList<T> list, int start, int end, IComparer<T> comparer) where T : IComparable
        {
            var pivot = list[start];
            int i = start, j = end;
            while (i < j)
            {
                while (i < j && comparer.Compare(list[j], pivot) > 0) j--;
                if (i < j) list[i++] = list[j];
                while (i < j && comparer.Compare(list[i], pivot) < 0) i++;
                list[j--] = list[i];
            }
            list[i] = pivot;
            if (start < i) QuickSortRecursion(list, start, i - 1, comparer);
            if (end > i) QuickSortRecursion(list, i + 1, end, comparer);
        }

        public static void Print<T>(this IList<T> list, Func<T, string> formatter = null)
        {
            var sb = new StringBuilder("list:[");
            for (var i = 0; i < list.Count; i++)
            {
                sb.Append(formatter == null ? list[i].ToString() : formatter(list[i]));
                if (i != list.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            Logger.Log(sb.ToString());
        }
    }
}
