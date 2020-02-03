using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTools
{
    namespace Maths
    {
        [System.Serializable]
        public class Range<T>
        {
            [SerializeField]
            public T Min;
            [SerializeField]
            public T Max;

            protected Range(T min, T max)
            {
                this.Min = min;
                this.Max = max;
            }

            public static Range<int> IntRange(int min, int max)
            {
                return new Range<int>(min, max);
            }

            public static Range<float> FloatRange(float min, float max)
            {
                return new Range<float>(min, max);
            }
        }
    }
}