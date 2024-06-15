using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class blacksmith : MonoBehaviour
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
            "Hello traveler, I am the blacksmith! I can teach you melee attacks to help you become stronger. Visit the elder within the town hall and return to me so I can teach you your first attack.",
            "edef",
            "aefaef"};
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
            }

            if (animator.GetBool("Right"))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (position.x > 10.0f)
                {
                    rb.velocity = new Vector2(0.0f, rb.velocity.y);
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                }
            }
            else if (animator.GetBool("Left"))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if (position.x < 3.0f)
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

        questText.text = quests[globalVars.quest];
        questText.gameObject.SetActive(true);
        panel.SetActive(true);
    }
}
