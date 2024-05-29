using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blacksmith : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Initialize rb
        rb.freezeRotation = true;
        animator.SetBool("Idle1", true);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        bool Idle1 = animator.GetBool("Idle1"); // Remove 'private'
        bool Idle2 = animator.GetBool("Idle2"); // Remove 'private'
        bool Right = animator.GetBool("Right"); // Remove 'private'
        bool Left = animator.GetBool("Left"); // Remove 'private'

        Vector2 position = rb.position;

        if (stateInfo.IsName("Idle1") || stateInfo.IsName("Idle2"))
        {
            if(animator.GetBool("Idle1"))
            {
                //rb.velocity = new Vector2(speed, rb.velocity.y);
                animator.SetBool("Right", true);
                animator.SetBool("Idle1", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else if(animator.GetBool("Idle2"))
            {
                //rb.velocity = new Vector2(-speed, rb.velocity.y);
                rb.velocity = new Vector2(0, rb.velocity.y);
                animator.SetBool("Left", true);
                animator.SetBool("Idle2", false);
            }
        }
        else
        {
            if(animator.GetBool("Right"))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                animator.SetBool("Idle2", true);
                animator.SetBool("Right", false);
            }
            else if(animator.GetBool("Left"))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                animator.SetBool("Idle1", true);
                animator.SetBool("Left", false);
            }
        }
    }
}
