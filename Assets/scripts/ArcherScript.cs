using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArcherScript : MonoBehaviour
{
    // public Transform player;
    private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 1.0f;


    public string[] quests = new string[3];
    public GameObject panel;
    public TMP_Text questText;
    public GameObject player;
    private bool canChange = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Initialize rb
        rb.freezeRotation = true;
        animator.SetBool("Right", true);

        quests = new string[] {
            "Hello traveler, I am the archer! I can teach you how to use your bow. Visit the elder within the town hall and return to me so I can teach you your first attack.",
            "I will teach you your first bow attack. The more you use your bow in battle, the more bow attacks I can teach you. Here is a basic bow and arrow, press 'L' to use your bow.",
            "Go talk with the Mage and Blacksmith, then return to the elder in the town hall."};
    }

    // Update is called once per frame
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

                if(globalVars.archerQuest == 1)
                {
                    globalVars.ranged = "bow";
                    globalVars.archerQuest += 1;
                }
            }

            if(animator.GetBool("Right"))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if(position.x > -3.5f)
                {
                    rb.velocity = new Vector2(0.0f, rb.velocity.y);
                    animator.SetBool("Left", true);
                    animator.SetBool("Right", false);
                }
            }
            else if(animator.GetBool("Left"))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                if(position.x < -10.0f)
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

        questText.text = quests[globalVars.archerQuest];
        questText.gameObject.SetActive(true);
        panel.SetActive(true);
    }
}
