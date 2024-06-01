using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mage : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Rigidbody2D rb;
    private float speed = 1.0f;



    public string[] quests = new string[3];
    public GameObject panel;
    public TMP_Text questText;
    public GameObject player;
    private bool canChange = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        animator.SetBool("Down", true);

        quests = new string[] {
            "Hello traveler, I am the mage! I can teach you magic attacks. Visit the elder within the town hall and return to me so I can teach you your first attack.",
            "edef",
            "aefaef"};
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

            //cehcking if user was in dialogue with npc
            if (!animator.GetBool("Up") && !animator.GetBool("Down"))
            {
                animator.SetBool("Up",true);
            }

            Vector2 position = rb.position;

            if(animator.GetBool("Down"))
            {
                rb.velocity = new Vector2(0.0f,-speed);
                if(position.y < -8.0f)
                {
                    animator.SetBool("Down",false);
                    animator.SetBool("Up", true);
                }
            }

            if(animator.GetBool("Up"))
            {
                rb.velocity = new Vector2(0.0f, speed);
                if(position.y > -2.0f)
                {
                    animator.SetBool("Up",false);
                    animator.SetBool("Down",true);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
    }

    public void Dialogue()
    {
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        canChange = true;

        playermovement playerMovement = player.GetComponent<playermovement>();

        questText.text = quests[playerMovement.quest];
        questText.gameObject.SetActive(true);
        panel.SetActive(true);
    }
}
