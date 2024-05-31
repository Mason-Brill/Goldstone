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
    //public CollisionTextManager textManager; // Reference to the CollisionTextManager
    //public NPCInteractionManager interactionManager;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        health = 100;
    }

    // Update is called once per frame
    void Update()
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

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("npc"))
    //     {
    //         interactionManager.ShowInteractionText(collision.gameObject);
    //     }
    // }

    // // This method is called when the collider attached to this GameObject stays in contact with another collider
    // void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("npc"))
    //     {
    //         interactionManager.ShowInteractionText(collision.gameObject);
    //     }
    // }

    // // This method is called when the collider attached to this GameObject stops colliding with another collider
    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("npc"))
    //     {
    //         interactionManager.HideInteractionText();
    //     }
    // }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void DisplayHealth()
    {
        Text.text = "Health: " + health;
    }
}
