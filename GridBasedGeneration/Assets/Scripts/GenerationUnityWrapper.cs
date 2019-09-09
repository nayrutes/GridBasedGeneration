using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridBasedGeneration;

public class GenerationUnityWrapper : MonoBehaviour
{
    public List<GameObject> Prefabs;
    public Vector3 origin;

    private GenerationManager generationManager;

    // Start is called before the first frame update
    void Start()
    {
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
