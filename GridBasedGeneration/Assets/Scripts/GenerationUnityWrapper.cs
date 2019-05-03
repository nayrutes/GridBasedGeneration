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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
