using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class elder : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 1.0f;



    public string[] quests = new string[3];
    public GameObject panel;
    public TMP_Text questText;
    public GameObject player;
    private bool canChange = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Initialize rb
        rb.freezeRotation = true;
        animator.SetBool("Right", true);
        panel.SetActive(false);

        quests = new string[] {
            "Hello traveler, I am the elder for the town of Goldstone. There is much to be done, go speak with the Blacksmith, Mage, and Archer to learn new skills. Then, return to me and we will discuss more...",
            "Go speak with the Blacksmith, Mage, and Archer to learn new skills. Then, return to me."};
    }

    void Update()
    {
        if(!animator.GetBool("Idle"))
        {
            if(canChange == true)
            {
                questText.gameObject.SetActive(false);
                panel.SetActive(false);
                canChange = false;
            }

            Vector2 position = rb.position;

            //cehcking if user was in dialogue with npc
            if (!animator.GetBool("Right") && !animator.GetBool("Left"))
            {
                animator.SetBool("Right",true);
                if(globalVars.elderQuest == 0)
                {
                    globalVars.elderQuest = 1;
                }
            }

            if (animator.GetBool("Right"))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (position.x > 2.75f)
                {
                    rb.velocity = new Vector2(0.0f, rb.velocity.y);
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                }
            }
            else if (animator.GetBool("Left"))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (position.x < -2.0f)
                {
                    rb.velocity = new Vector2(0.0f, rb.velocity.y);
                    animator.SetBool("Right", true);
                    animator.SetBool("Left", false);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
    }

    public void Dialogue()
    {
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        canChange = true;

        questText.text = quests[globalVars.elderQuest];
        questText.gameObject.SetActive(true);
        panel.SetActive(true);

        if(globalVars.elderQuest == 0)
        {
            globalVars.mageQuest = 1;
            globalVars.blacksmithQuest = 1;
            globalVars.archerQuest = 1;
        }
    }
}
