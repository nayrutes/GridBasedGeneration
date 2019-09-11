using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridBasedGeneration;

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
        generationManager = new GenerationManager();
        generationManager.ChooseFittingUnity = ChooseFittingUnity;
    }

    private void ChooseFittingUnity(ref List<Conditions> arg1, System.Numerics.Vector3 arg2)
    {
        //select one condition
        //manage unit prefab
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
