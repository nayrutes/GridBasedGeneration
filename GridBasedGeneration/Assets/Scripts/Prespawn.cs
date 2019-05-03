using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace GridBasedGeneration
{
    public class Prespawn
    {
        int conditionInX;
        int conditionInZ;
        int conditionInMinusX;
        int conditionInMinusZ;

        public Prespawn()
        {

        }
        public Prespawn(int x, int mx, int z, int mz)
        {
            conditionInX = x;
            conditionInZ = z;
            conditionInMinusX = mx;
            conditionInMinusZ = mz;
        }
    }
}
