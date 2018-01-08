using System;
using System.Collections.Generic;

namespace BasicCodes
{
    public class StackPicker
    {
        private static readonly Random Rand = new Random(DateTime.Now.Millisecond);
        public static List<int> RandomPick(int count, int stacks, int min, int max)
        {
            if (count < stacks*min || count > stacks*max) throw new ArgumentException("Invalid range");
            var ret = new List<int>();
            for (var i = stacks - 1; i >= 0; --i)
            {
                var next = Rand.Next(Math.Max(count - i * max, min), Math.Min(count - i * min, max) + 1);
                ret.Add(next);
                count -= next;
            }
            return ret;
        }
    }
}
