using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playermovement : MonoBehaviour
{
    //variables
    public TMP_Text Text;
    private float horizontal = 0;
    private float vertical = 0;
    private float speed = 3f;
    // private bool facingRight = true;

    [SerializeField] private Rigidbody2D rb;
    private Animator animator;
    public int health;
    public int quest;
    private bool dead = false;
    //public CollisionTextManager textManager; // Reference to the CollisionTextManager
    //public NPCInteractionManager interactionManager;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        health = 100;
        quest = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            dead = true;
            health = 0;
        }

        if(!dead)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            
            DisplayHealth();
            if(vertical > 0)
            {
                animator.SetBool("isMovingUp", true);
            }
            else
            {
                animator.SetBool("isMovingUp", false);
            }

            if(vertical < 0)
            {
                animator.SetBool("isMovingDown", true);
            }
            else
            {
                animator.SetBool("isMovingDown", false);
            }

            
            if(horizontal > 0)
            {
                animator.SetBool("isMovingRight", true);
            }
            else
            {
                animator.SetBool("isMovingRight", false);
            }
            if(horizontal < 0)
            {
                animator.SetBool("isMovingLeft", true);
            }
            else
            {
                animator.SetBool("isMovingLeft", false);
            }
        }
        else
        {
            //add dead logic here, like an animation
            //add an event at the end of the death animation
            //in this event show a respawn screen option
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void DisplayHealth()
    {
        Text.text = "Health: " + health;
    }
}
