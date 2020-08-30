using UnityEngine;

namespace UnityTools
{
    namespace Maths
    {
        /// <summary>
        /// ranged integer, that has a minimum and maximum
        /// </summary>
        public struct Rint
        {
            public readonly int Min;
            public readonly int Max;
            public int intValue;

            public Rint(int min, int max)
            {
                if (min > max)
                    Debug.LogError("Min " + min + " value larger than Max " + max);

                this.Min = min;
                this.Max = max;
                intValue = min;
            }

            public Rint(int min, int max, int value)
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
            public static Rint operator +(Rint a, Rint b)
            {
                return new Rint(a.Min, a.Max, a.intValue + b.intValue);
            }

            public static Rint operator +(Rint a, int b)
            {
                return new Rint(a.Min, a.Max, a.intValue + b);
            }

            public static Rint operator -(Rint a, int b)
            {
                return new Rint(a.Min, a.Max, a.intValue - b);
            }

            //equality--
            public override bool Equals(object obj)
            {
                if (!(obj is Rint))
                {
                    return false;
                }

                var rint = (Rint)obj;
                return intValue == rint.intValue;
            }

            public static bool operator ==(Rint a, Rint b)
            {
                return (a.intValue == b.intValue);
            }

            public static bool operator !=(Rint a, Rint b)
            {
                return !(a == b);
            }

            public static bool operator ==(Rint a, int b)
            {
                return (a.intValue == b);
            }

            public static bool operator !=(Rint a, int b)
            {
                return !(a == b);
            }
        }
    }

}

