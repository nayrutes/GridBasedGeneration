using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace GridBasedGeneration
{
    [System.Serializable]
    public class Cell
    {
        public Vector3 Position;

        private Conditions p = new Conditions(0,0,0,0);
        public int ConditionInX
        {
            get => p.ConditionInX;
            set => p.ConditionInX = value;
        }

        public int ConditionInZ
        {
            get => p.ConditionInZ;
            set => p.ConditionInZ = value;
        }

        public int ConditionInMinusX
        {
            get => p.ConditionInMinusX;
            set => p.ConditionInMinusX = value;
        }

        public int ConditionInMinusZ
        {
            get => p.ConditionInMinusZ;
            set => p.ConditionInMinusZ = value;
        }

        public Cell()
        {

        }
        public Cell(Vector3 pos, int x, int mx, int z, int mz)
        {
            Position = pos;
            ConditionInX = x;
            ConditionInZ = z;
            ConditionInMinusX = mx;
            ConditionInMinusZ = mz;
        }
    }
}


