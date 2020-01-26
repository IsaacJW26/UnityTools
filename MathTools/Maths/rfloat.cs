using UnityEngine;

namespace UnityTools
{
    namespace Maths
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
    }

}

