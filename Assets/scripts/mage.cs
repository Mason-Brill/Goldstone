using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mage : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Rigidbody2D rb;
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        animator.SetBool("Down", true);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

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
}
