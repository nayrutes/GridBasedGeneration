using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine.UI;

namespace GridBasedGeneration
{
    public class GenerationManager
    {
        public bool isFinished = false;
        public float MidToSide;
        public int Iterations;
        private Vector3 Origin;
        private List<Conditions> PrefabConditions = new List<Conditions>();
        
        private List<Cell> spawnedCells = new List<Cell>();
        private List<Cell> spawnedCellsLast = new List<Cell>();
        private Dictionary<Vector3, Conditions> prespawns = new Dictionary<Vector3, Conditions>();
        private bool isIterating = false;

        //public Action<Conditions> ChooseFittingUnity;
        public delegate void ActionRef1<T1, T2>(ref T1 arg1, T2 arg2);

        public ActionRef1<List<Conditions>, Vector3> ChooseFittingUnity;
        
        //-----Debug-----
        public bool showMarker;

        
        public GenerationManager(Vector3 origin, List<Conditions> prefabConditions)
        {
            this.Origin = origin;
            this.PrefabConditions = prefabConditions;

        }

        
        //-----Part1: Generate Map-----
        public IEnumerable GenerateStep()
        {
            yield return null;
        }

        //prespawn indicate what constraints the position has
        //add fitting cell on top
        //modify coorresponding prespawn
        public void Generate()
        {
            isIterating = true;
            int currentIteration = 0;
            Vector3 startvector = new Vector3(0,0,0);
            spawnedCellsLast.Add(new Cell(startvector, 2, 2, 2, 2));
            prespawns.Add(startvector, new Conditions(2,2,2,2));
            
            while (isIterating)
            {
                List<Cell> spawnedCellsNow = new List<Cell>();
                
                //get new positions
                var cs = CheckSides(spawnedCells);
                //spawn markers
                var sp = SpawnPrespawn(cs);

                foreach (KeyValuePair<Vector3,Conditions> tile in sp)
                {
                    //find fitting cell (aka prefab in unity)
                    var ff = FindFitting(tile);
                    //select a fitting cell and modify tile
                    var cf = ChooseFitting(ff, tile.Key);
                }
                

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
            
            //Hashset prevents double position
            foreach (var cell in spawnedCells)
            {
                result.Add(cell.Position + Vector3.UnitX);
                result.Add(cell.Position - Vector3.UnitX);
                result.Add(cell.Position + Vector3.UnitZ);
                result.Add(cell.Position - Vector3.UnitZ);
            }

            return result;
        }

        private Dictionary<Vector3,Conditions> SpawnPrespawn(HashSet<Vector3> checkedSides)
        {
            Dictionary<Vector3, Conditions> result = new Dictionary<Vector3, Conditions>();

            foreach (var vec in checkedSides)
            {
                //Get condition from surrounding tiles
                //set condiotion for tile accordingly (axis reverserd)
                var x = (prespawns[vec + Vector3.UnitX]?.ConditionInX).GetValueOrDefault();
                var mx = (prespawns[vec - Vector3.UnitX]?.ConditionInMinusX).GetValueOrDefault();
                var z = (prespawns[vec + Vector3.UnitZ]?.ConditionInZ).GetValueOrDefault();
                var mz = (prespawns[vec - Vector3.UnitZ]?.ConditionInMinusZ).GetValueOrDefault();
                result.Add(vec, new Conditions(mx,x,mz,z));
            }

            return result;
        }

        

        private List<Conditions> FindFitting(KeyValuePair<Vector3,Conditions> tile)
        {
            List<Conditions> result = new List<Conditions>();

            foreach (var PrefabCondition in PrefabConditions)
            {
                if (tile.Value >= PrefabCondition)
                {
                    result.Add(PrefabCondition);
                }
            }
            
            return result;
        }

        private Cell ChooseFitting(List<Conditions> cond, Vector3 pos)
        {
            
            ChooseFittingUnity.Invoke(ref cond, pos);
            //modify prespawn at pos
            
            return new Cell();
        }


        //-----Part2: Close Open-----
        private void CloseDoors()
        {

        }
    }

}

