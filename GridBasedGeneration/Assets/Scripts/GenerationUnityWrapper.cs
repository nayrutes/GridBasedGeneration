using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridBasedGeneration;
using NUnit.Framework.Constraints;

public class GenerationUnityWrapper : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private Vector3 origin;
    private List<Conditions> prefabConditions;

    private GenerationManager generationManager;

    // Start is called before the first frame update
    void Start()
    {
        //prepare
        
        //startgeneration
        generationManager = new GenerationManager(UnityToNum(origin),prefabConditions);
        generationManager.ChooseFittingUnity = ChooseFittingUnity;
        
        generationManager.Generate();
    }

    private void ChooseFittingUnity(ref List<Conditions> arg1, System.Numerics.Vector3 arg2)
    {
        //select one condition
        //manage unit prefab
        //
    }

    public static System.Numerics.Vector3 UnityToNum(Vector3 vec)
    {
        return new System.Numerics.Vector3(vec.x,vec.y,vec.z);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
