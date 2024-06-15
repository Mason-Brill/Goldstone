using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerQuests : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void updateQuests(){
        //grabbing players current quest

        Debug.Log("hello");
        switch(globalVars.quest)
        {
            case 0:
                globalVars.quest += 1;
                break;
            default:
                break;
        }

    }
}