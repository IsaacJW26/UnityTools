using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTools
{
    namespace MathTools
    {
        public struct rfloat
        {
            public readonly float Min;
            public readonly float Max;
            private float floatValue;

            public float FloatValue { get => floatValue; set
                {
                    floatValue = (value > Max) ? Max : (value < Min) ? Min : value; } }

            public rfloat(float min, float max)
            {
                if (min > max)
                    Debug.LogError("Min " + min + " value larger than Max " + max);

                this.Min = min;
                this.Max = max;
                this.floatValue = min;
            }

            public rfloat(float min, float max, float value)
            {
                if (min > max)
                    Debug.LogError("Min " + min + " value larger than Max " + max);

                this.Min = min;
                this.Max = max;
                this.floatValue = (value > Max) ? Max : (value < Min) ? Min : value;
            }

            //methods--------------
            /// <summary>
            /// Linearly interpolates between min and max for value t
            /// </summary>
            /// <param name="t">The interpolation value between min and max</param>
            public float LerpValue(float t)
            {
                FloatValue = Mathf.Lerp(Min, Max, t);
                return FloatValue;
            }

            public float GetPercent()
            {
                return (FloatValue - Min) / (Max - Min);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is rfloat))
                {
                    return false;
                }

                var @float = (rfloat)obj;
                return FloatValue == @float.FloatValue;
            }

            public override int GetHashCode()
            {
                var hashCode = 135456946;
                hashCode = hashCode * -1521134295 + Min.GetHashCode();
                hashCode = hashCode * -1521134295 + Max.GetHashCode();
                hashCode = hashCode * -1521134295 + FloatValue.GetHashCode();
                return hashCode;
            }

            //operators----------------
            public static rfloat operator +(rfloat a, rfloat b)
            {
                return new rfloat(a.Min, a.Max, a.FloatValue + b.FloatValue);
            }

            public static rfloat operator +(rfloat a, float b)
            {
                return new rfloat(a.Min, a.Max, a.FloatValue + b);
            }

            public static rfloat operator -(rfloat a, float b)
            {
                return new rfloat(a.Min, a.Max, a.FloatValue - b);
            }

            //equality
            public static bool operator ==(rfloat a, rfloat b)
            {
                if (Comparitors.GetFloatComparer().Compare(a.FloatValue, b.FloatValue) == 0)
                    return true;
                else
                    return false;
            }

            public static bool operator !=(rfloat a, rfloat b)
            {
                return !(a == b);
            }

            public static bool operator ==(float a, rfloat b)
            {
                if (Comparitors.GetFloatComparer().Compare(a, b.FloatValue) == 0)
                    return true;
                else
                    return false;
            }

            public static bool operator !=(float a, rfloat b)
            {
                return !(a == b);
            }

            public static bool operator ==(rfloat a, float b)
            {
                if (Comparitors.GetFloatComparer().Compare(a.FloatValue, b) == 0)
                    return true;
                else
                    return false;
            }

            public static bool operator !=(rfloat a, float b)
            {
                return !(a == b);
            }
        }

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

