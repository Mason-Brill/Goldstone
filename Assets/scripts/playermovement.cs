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
    private bool dead = false;
    private float lastMagic = 0.0f;


    private Transform magicUp;
    private Transform magicUpRight;
    private Transform magicUpLeft;
    private Transform magicRight;
    private Transform magicLeft;
    private Transform magicDown;
    private Transform magicDownRight;
    private Transform magicDownLeft;

    private Animator magicUpAnimator;
    private Animator magicUpRightAnimator;
    private Animator magicUpLeftAnimator;
    private Animator magicRightAnimator;
    private Animator magicLeftAnimator;
    private Animator magicDownAnimator;
    private Animator magicDownRightAnimator;
    private Animator magicDownLeftAnimator;

    
    private SpriteRenderer magicUpSprite;
    private SpriteRenderer magicUpRightSprite;
    private SpriteRenderer magicUpLeftSprite;
    private SpriteRenderer magicRightSprite;
    private SpriteRenderer magicLeftSprite;
    private SpriteRenderer magicDownSprite;
    private SpriteRenderer magicDownRightSprite;
    private SpriteRenderer magicDownLeftSprite;

    private AudioSource magicSound;
    //public CollisionTextManager textManager; // Reference to the CollisionTextManager
    //public NPCInteractionManager interactionManager;



    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        magicSound = GetComponent<AudioSource>();
        rb.freezeRotation = true;
        magicUp = transform.Find("magicUp");
        magicUpRight = transform.Find("magicUpRight");
        magicUpLeft = transform.Find("magicUpLeft");
        magicRight = transform.Find("magicRight");
        magicLeft = transform.Find("magicLeft");
        magicDown = transform.Find("magicDown");
        magicDownRight = transform.Find("magicDownRight");
        magicDownLeft = transform.Find("magicDownLeft");

        magicUpAnimator = magicUp.GetComponent<Animator>();
        magicUpRightAnimator = magicUpRight.GetComponent<Animator>();
        magicUpLeftAnimator = magicUpLeft.GetComponent<Animator>();
        magicRightAnimator = magicRight.GetComponent<Animator>();
        magicLeftAnimator = magicLeft.GetComponent<Animator>();
        magicDownAnimator = magicDown.GetComponent<Animator>();
        magicDownRightAnimator = magicDownRight.GetComponent<Animator>();
        magicDownLeftAnimator = magicDownLeft.GetComponent<Animator>();

        magicUpSprite = magicUp.GetComponent<SpriteRenderer>();
        magicUpRightSprite = magicUpRight.GetComponent<SpriteRenderer>();
        magicUpLeftSprite = magicUpLeft.GetComponent<SpriteRenderer>();
        magicRightSprite = magicRight.GetComponent<SpriteRenderer>();
        magicLeftSprite = magicLeft.GetComponent<SpriteRenderer>();
        magicDownSprite = magicDown.GetComponent<SpriteRenderer>();
        magicDownRightSprite = magicDownRight.GetComponent<SpriteRenderer>();
        magicDownLeftSprite = magicDownLeft.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(globalVars.health <= 0)
        {
            dead = true;
            globalVars.health = 0;
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

            //attacks

            //melee
            if(Input.GetKeyDown(KeyCode.J) && globalVars.melee != "")
            {
                animator.SetBool("melee",true);
            }

            //ranged
            if(Input.GetKeyDown(KeyCode.L) && globalVars.ranged != "")
            {
                animator.SetBool("ranged",true);
            }


            
            //checking if magic is on
            if(Input.GetKeyDown(KeyCode.K) && Time.time - lastMagic > 2.0f && globalVars.magic != "")
            {
                animator.SetBool("magic", true);
                magicSound.Play();
                lastMagic = Time.time;
                Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
                
                if(vertical > 0 || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standUp")
                {
                    
                    if(horizontal > 0)
                    {
                        magicUpRightAnimator.SetBool("on",true);
                        magicUpRightSprite.enabled = true;
                    }
                    else if(horizontal < 0)
                    {
                        magicUpLeftAnimator.SetBool("on",true);
                        magicUpLeftSprite.enabled = true;
                    }
                    else
                    {
                        magicUpAnimator.SetBool("on",true);
                        magicUpSprite.enabled = true;
                    }
                }
                else if(vertical < 0)
                {
                    if(horizontal > 0)
                    {
                        magicDownRightAnimator.SetBool("on",true);
                        magicDownRightSprite.enabled = true;
                    }
                    else if(horizontal < 0)
                    {
                        magicDownLeftAnimator.SetBool("on",true);
                        magicDownLeftSprite.enabled = true;
                    }
                    else
                    {
                        magicDownAnimator.SetBool("on",true);
                        magicDownSprite.enabled = true;
                    }
                }
                else
                {
                    
                    if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standRight") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingRight" || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "magicRight")
                    {
                        magicRightAnimator.SetBool("on",true);
                        magicRightSprite.enabled = true;
                    }
                    else if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standLeft") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingLeft" || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "magicLeft")
                    {
                        magicLeftAnimator.SetBool("on",true);
                        magicLeftSprite.enabled = true;
                    }
                    else if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "still")
                    {
                        magicDownAnimator.SetBool("on",true);
                        magicDownSprite.enabled = true;
                    }
                }
            }
            else
            {
                magicLeftAnimator.SetBool("on",false);
                magicRightAnimator.SetBool("on",false);
                magicUpAnimator.SetBool("on",false);
                magicDownAnimator.SetBool("on",false);
                magicUpRightAnimator.SetBool("on",false);
                magicUpLeftAnimator.SetBool("on",false);
                magicDownRightAnimator.SetBool("on",false);
                magicDownLeftAnimator.SetBool("on",false);
                animator.SetBool("magic",false);
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
        Text.text = "Health: " + globalVars.health;
    }
}
