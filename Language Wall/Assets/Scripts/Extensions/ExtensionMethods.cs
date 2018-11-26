using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LW.Extentions
{
    public static class ExtensionMethods
    {
        #region Methods
        public static float Map(this float value, float from1, float to1, float from2, float to2)
        {
            //return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
            return to1 + (value - from1) * (to2 - to1) / (from2 - from1);
        }
        #endregion
    }
}
