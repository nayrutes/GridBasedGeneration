using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace GridBasedGeneration
{
    public class GenerationManager
    {
        public bool isFinished = false;
        public float MidToSide;
        public int Iterations;
        public Vector3 Origin;
        public List<Cell> PrefabCells = new List<Cell>();
        
        private List<Cell> spawnedCells = new List<Cell>();
        private List<Cell> spawnedCellsLast = new List<Cell>();
        private Dictionary<Vector3, Prespawn> prespawns = new Dictionary<Vector3, Prespawn>();
        private bool isIterating = false;

        //-----Debug-----
        public bool showMarker;

        
        public GenerationManager()
        {

        }

        
        //-----Part1: Generate Map-----
        public IEnumerable GenerateStep()
        {
            yield return null;
        }

        public void Generate()
        {
            isIterating = true;
            int currentIteration = 0;

            spawnedCellsLast.Add(new Cell(new Vector3(0, 0, 0), 1, 1, 1, 1));

            while (isIterating)
            {
                List<Cell> spawnedCellsNow = new List<Cell>();

                var cs = CheckSides(spawnedCells);
                var sp = SpawnPrespawn(cs);
                var ff = FindFitting();
                var cf = ChooseFitting(ff);

                spawnedCellsLast.Clear();
                spawnedCellsLast.AddRange(spawnedCellsNow);
                spawnedCells.AddRange(spawnedCellsNow);

                if (currentIteration >= Iterations)
                {
                    isIterating = false;
                }
                currentIteration++;
            }
        }


        private HashSet<Vector3> CheckSides(List<Cell> spawnedCells)
        {
            HashSet<Vector3> result = new HashSet<Vector3>();

            foreach (var cell in spawnedCells)
            {
                result.Add(cell.Position + Vector3.UnitX);
                result.Add(cell.Position - Vector3.UnitX);
                result.Add(cell.Position + Vector3.UnitZ);
                result.Add(cell.Position - Vector3.UnitZ);
            }

            return result;
        }

        private Dictionary<Vector3,Prespawn> SpawnPrespawn(HashSet<Vector3> checkedSides)
        {
            Dictionary<Vector3, Prespawn> result = new Dictionary<Vector3, Prespawn>();

            foreach (var vec in checkedSides)
            {
                
            }

            return result;
        }

        

        private List<Cell> FindFitting()
        {
            List<Cell> result = new List<Cell>();

            return result;
        }

        private Cell ChooseFitting(List<Cell> cells)
        {
            return new Cell();
        }


        //-----Part2: Close Open-----
        private void CloseDoors()
        {

        }
    }

}

