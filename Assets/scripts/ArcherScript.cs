using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : MonoBehaviour
{
    // public Transform player;
    private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Initialize rb
        rb.freezeRotation = true;
        animator.SetBool("Right", true);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        Vector2 position = rb.position;

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
}
