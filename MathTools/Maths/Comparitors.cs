using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTools
{
    namespace Maths
    {

        public static class Comparitors
        {
            /// <summary>
            /// Compares two floats (with a tolerance of 0.001f), and returns a value indicating whether one is less than, equal to, or greater than the other
            /// </summary>
            /// <returns>
            /// if less than 0, x is less than y
            /// if 0, x equals y
            /// if greater than 0, x is greater than y
            /// </returns>
            public static IComparer<float> GetFloatComparer()
            {
                return Comparer<float>.Create((x, y) =>
                {
                //equal
                if (Mathf.Abs(x - y) < 0.001f)
                    {
                        return 0;
                    }
                //x is greater than y
                else if (x > y)
                    {
                        return 1;
                    }
                //x is less than y
                else
                    {
                        return -1;
                    }
                });
            }

            public static int FloatCompare(float x, float y)
            {
                return GetFloatComparer().Compare(x, y);
            }
        }
    }

}

