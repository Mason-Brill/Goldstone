using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject skeleton;
    private bool spawnSkeleton = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawning skeletons for first time
        if(globalVars.elderQuest == 2 && spawnSkeleton == true)
        {
            SpawnSkeleton(-21f, 0.57f);
            SpawnSkeleton(-18f, -0.52f);
            SpawnSkeleton(-15f, 0.65f);
            spawnSkeleton = false;   
        }
        if(globalVars.skeletonsKilled == 3)
        {
            globalVars.elderQuest = 3;
        }
    }

    //spawns skeletons, x = x position to spawn at, y = y position to spawn at
    void SpawnSkeleton(float x, float y)
    {
        Instantiate(skeleton, new Vector3(x, y, 0f), Quaternion.identity).SetActive(true);
    }
}
