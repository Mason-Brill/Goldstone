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
        if(globalVars.elderQuest == 2 && spawnSkeleton == true)
        {
            Instantiate(skeleton, new Vector3(-21f,0.57f,0f), Quaternion.identity).SetActive(true);
            Instantiate(skeleton, new Vector3(-18f,-0.52f,0f), Quaternion.identity).SetActive(true);
            Instantiate(skeleton, new Vector3(-15f,0.65f,0f), Quaternion.identity).SetActive(true);
            spawnSkeleton = false;

            //set the above instantiations to a GameObject
            //somehow keep track of when they are killed and increment "globalVars.elderQuest" to 3
            //maybe add a globalVar and increment it everytime the skeleton is killed
            //you could place this in the animation event function that plays when a skeleton dies
        }
    }
}
