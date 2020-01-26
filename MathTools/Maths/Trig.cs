using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTools
{
    namespace Maths
    {
        public static class Trig
        {
            /// <summary>
            /// Returns the positive sine of radians input 
            /// </summary>
            /// <param name="radians"></param>
            /// <returns></returns>
            public static float PSin(float radians)
            {
                return (Mathf.Sin(radians) + 1f) / 2f;
            }
        }
    }
}
