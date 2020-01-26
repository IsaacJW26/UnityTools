using UnityEngine;

namespace UnityTools
{
    namespace Maths
    {
        public struct rint
        {
            public readonly int Min;
            public readonly int Max;
            public int intValue;

            public rint(int min, int max)
            {
                if (min > max)
                    Debug.LogError("Min " + min + " value larger than Max " + max);

                this.Min = min;
                this.Max = max;
                intValue = min;
            }

            public rint(int min, int max, int value)
            {
                if (min > max)
                    Debug.LogError("Min " + min + " value larger than Max " + max);

                this.Min = min;
                this.Max = max;
                intValue = (value > max) ? max : (value < min) ? min : value;
            }

            //methods--------------
            /// <summary>
            /// Linearly interpolates between min and max for value t
            /// </summary>
            /// <param name="t">The interpolation value between min and max</param>
            public int LerpValue(float t)
            {
                intValue = (int)((Max - Min) * t) + Min;
                return intValue;
            }

            public float GetPercent()
            {
                return (intValue - Min) / (Max - Min);
            }

            public override int GetHashCode()
            {
                var hashCode = 135456946;
                hashCode = hashCode * -1521134295 + Min.GetHashCode();
                hashCode = hashCode * -1521134295 + Max.GetHashCode();
                hashCode = hashCode * -1521134295 + intValue.GetHashCode();
                return hashCode;
            }

            //operators----------------
            public static rint operator +(rint a, rint b)
            {
                return new rint(a.Min, a.Max, a.intValue + b.intValue);
            }

            public static rint operator +(rint a, int b)
            {
                return new rint(a.Min, a.Max, a.intValue + b);
            }

            public static rint operator -(rint a, int b)
            {
                return new rint(a.Min, a.Max, a.intValue - b);
            }

            //equality
            public static bool operator ==(rint a, rint b)
            {
                return (a.intValue == b.intValue);
            }

            public static bool operator !=(rint a, rint b)
            {
                return !(a == b);
            }

            public static bool operator ==(rint a, int b)
            {
                return (a.intValue == b);
            }

            public static bool operator !=(rint a, int b)
            {
                return !(a == b);
            }
        }
    }

}

