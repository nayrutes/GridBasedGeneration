using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace GridBasedGeneration
{
    [System.Serializable]
    public class Cell
    {
        public Vector3 Position;

        int conditionInX;
        int conditionInZ;
        int conditionInMinusX;
        int conditionInMinusZ;

        public Cell()
        {

        }
        public Cell(Vector3 pos, int x, int mx, int z, int mz)
        {
            Position = pos;
            conditionInX = x;
            conditionInZ = z;
            conditionInMinusX = mx;
            conditionInMinusZ = mz;
        }
    }
}


