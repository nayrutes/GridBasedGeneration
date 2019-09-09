using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;

namespace GridBasedGeneration
{
    public class Conditions
    {
        //condition == 0 => no information (can set self)
        //condition == 1 => no connection (no door)
        //condition == 2 => connection (one door)
        //condition == 3 => other connection (two doors)

        public int ConditionInX { get; set; }
        public int ConditionInZ { get; set; }
        public int ConditionInMinusX { get; set; }
        public int ConditionInMinusZ { get; set; }

        public Conditions()
        {

        }
        public Conditions(int x, int mx, int z, int mz)
        {
            ConditionInX = x;
            ConditionInZ = z;
            ConditionInMinusX = mx;
            ConditionInMinusZ = mz;
        }

        public static bool operator <=(Conditions a, Conditions b)
        {
            return b >= a;
        }

        //does a have more conditions as b? Aka does b fit into a?
        //a: set tile; b: tile to test if it fits
        //b should have no 0
        public static bool operator >=(Conditions a, Conditions b)
        {
            bool result = true;
            if (a.ConditionInX != 0 && a.ConditionInX != b.ConditionInX)
            {
                result = false;
            }
            if (a.ConditionInZ != 0 && a.ConditionInZ != b.ConditionInZ)
            {
                result = false;
            }
            if (a.ConditionInMinusX != 0 && a.ConditionInMinusX != b.ConditionInMinusX)
            {
                result = false;
            }
            if (a.ConditionInMinusZ != 0 && a.ConditionInMinusZ != b.ConditionInMinusZ)
            {
                result = false;
            }

            return result;
        }
    }
}
