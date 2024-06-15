using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaveHouse1 : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Idle"))
        {
            animator.SetBool("Idle",false);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
