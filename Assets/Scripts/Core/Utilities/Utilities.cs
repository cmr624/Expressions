using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public struct PuzzleVisualizer
    {
        public List<int> colLeft;// = new List<int>();
        public List<string> colMiddle;// = new List<string>();
        public List<int> colRight;// = new List<int>();

    }
    public static class Utilities
    {
        public static string RandomStringFromArray(List<string> list)
        {
            int index = Random.Range(0, list.Count);
            return list[index];
        }
        /// <summary>
        /// Shuffles the element order of the specified list.
        /// </summary>
        public static void Shuffle<T>(this IList<T> ts)
        {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = Random.Range(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }
    }
}

