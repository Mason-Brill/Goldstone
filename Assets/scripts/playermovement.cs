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
    private float lastMelee = 0.0f;
    private float lastBow = 0.0f;

    private Transform meleeLeft;
    private Transform meleeRight;
    private Transform meleeDown;
    private Transform meleeUp;

    private Animator meleeUpAnimator;
    private Animator meleeRightAnimator;
    private Animator meleeLeftAnimator;
    private Animator meleeDownAnimator;

    private SpriteRenderer meleeUpSprite;
    private SpriteRenderer meleeRightSprite;
    private SpriteRenderer meleeLeftSprite;
    private SpriteRenderer meleeDownSprite;

    private BoxCollider2D meleeUpBox;
    private BoxCollider2D meleeRightBox ;
    private BoxCollider2D meleeLeftBox ;
    private BoxCollider2D meleeDownBox ;


    private Transform bowRight;
    private Transform bowLeft;
    private Rigidbody2D arrow;
    public Transform arrowDir;
    private SpriteRenderer arrowSprite;

    private Animator bowLeftAnimator;
    private Animator bowRightAnimator;

    private SpriteRenderer bowLeftSprite;
    private SpriteRenderer bowRightSprite;



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

    private BoxCollider2D magicUpBox;
    private BoxCollider2D magicUpRightBox ;
    private BoxCollider2D magicUpLeftBox ;
    private BoxCollider2D magicRightBox ;
    private BoxCollider2D magicLeftBox ;
    private BoxCollider2D magicDownBox ;
    private BoxCollider2D magicDownRightBox ;
    private BoxCollider2D magicDownLeftBox ;

    public AudioSource magicSound;
    public AudioSource meleeSound;
    public AudioSource bowSound;
    private AudioSource walkingSound;



    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        walkingSound = GetComponent<AudioSource>();

        meleeLeft = transform.Find("meleeLeft");
        meleeRight = transform.Find("meleeRight");
        meleeDown = transform.Find("meleeDown");
        meleeUp = transform.Find("meleeUp");

        meleeUpAnimator = meleeUp.GetComponent<Animator>();
        meleeLeftAnimator = meleeLeft.GetComponent<Animator>();
        meleeRightAnimator = meleeRight.GetComponent<Animator>();
        meleeDownAnimator = meleeDown.GetComponent<Animator>();

        meleeUpSprite = meleeUp.GetComponent<SpriteRenderer>();
        meleeLeftSprite = meleeLeft.GetComponent<SpriteRenderer>();
        meleeRightSprite = meleeRight.GetComponent<SpriteRenderer>();
        meleeDownSprite = meleeDown.GetComponent<SpriteRenderer>();

        meleeUpBox = meleeUp.GetComponent<BoxCollider2D>();
        meleeLeftBox = meleeLeft.GetComponent<BoxCollider2D>();
        meleeRightBox = meleeRight.GetComponent<BoxCollider2D>();
        meleeDownBox = meleeDown.GetComponent<BoxCollider2D>();

        arrow = arrowDir.GetComponent<Rigidbody2D>();
        arrowSprite = arrowDir.GetComponent<SpriteRenderer>();

        bowLeft = transform.Find("bowLeft");
        bowRight = transform.Find("bowRight");

        bowLeftAnimator = bowLeft.GetComponent<Animator>();
        bowRightAnimator = bowRight.GetComponent<Animator>();

        bowLeftSprite = bowLeft.GetComponent<SpriteRenderer>();
        bowRightSprite = bowRight.GetComponent<SpriteRenderer>();


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
        
        magicUpBox = magicUp.GetComponent<BoxCollider2D>();
        magicUpRightBox = magicUpRight.GetComponent<BoxCollider2D>();
        magicUpLeftBox = magicUpLeft.GetComponent<BoxCollider2D>();
        magicRightBox = magicRight.GetComponent<BoxCollider2D>();
        magicLeftBox = magicLeft.GetComponent<BoxCollider2D>();
        magicDownBox = magicDown.GetComponent<BoxCollider2D>();
        magicDownRightBox = magicDownRight.GetComponent<BoxCollider2D>();
        magicDownLeftBox = magicDownLeft.GetComponent<BoxCollider2D>();

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
            if((horizontal != 0 || vertical != 0) && !walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
            else if(horizontal == 0 && vertical == 0)
            {
                walkingSound.Stop();
            }

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
            if(Input.GetKeyDown(KeyCode.J) && Time.time - lastMelee > 2.0f && globalVars.melee != "")
            {
                
                lastMelee = Time.time;
                meleeSound.Play();
                animator.SetBool("melee", true);
                
                if(vertical > 0 || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standUp")
                {
                    if(horizontal > 0)
                    {
                        meleeRightAnimator.SetBool("on",true);
                        meleeRightSprite.enabled = true;
                        meleeRightBox.enabled = true;
                    }
                    else if(horizontal < 0)
                    {
                        meleeLeftAnimator.SetBool("on",true);
                        meleeLeftSprite.enabled = true;
                        meleeLeftBox.enabled = true;
                    }
                    else
                    {
                        meleeUpAnimator.SetBool("on",true);
                        meleeUpSprite.enabled = true;
                        meleeUpBox.enabled = true;
                    }
                }
                else if(vertical < 0)
                {
                    if(horizontal > 0)
                    {
                        meleeRightAnimator.SetBool("on",true);
                        meleeRightSprite.enabled = true;
                        meleeRightBox.enabled = true;
                    }
                    else if(horizontal < 0)
                    {
                        meleeLeftAnimator.SetBool("on",true);
                        meleeLeftSprite.enabled = true;
                        meleeLeftBox.enabled = true;
                    }
                    else
                    {
                        meleeDownAnimator.SetBool("on",true);
                        meleeDownSprite.enabled = true;
                        meleeDownBox.enabled = true;
                    }
                }
                else
                {
                    
                    if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standRight") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingRight")
                    {
                        meleeRightAnimator.SetBool("on",true);
                        meleeRightSprite.enabled = true;
                        meleeRightBox.enabled = true;
                    }
                    else if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standLeft") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingLeft")
                    {
                        meleeLeftAnimator.SetBool("on",true);
                        meleeLeftSprite.enabled = true;
                        meleeLeftBox.enabled = true;
                    }
                    else if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "still")
                    {
                        meleeDownAnimator.SetBool("on",true);
                        meleeDownSprite.enabled = true;
                        meleeDownBox.enabled = true;
                    }
                }
            }
            else
            {
                meleeLeftAnimator.SetBool("on",false);
                meleeRightAnimator.SetBool("on",false);
                meleeUpAnimator.SetBool("on",false);
                meleeDownAnimator.SetBool("on",false);

                animator.SetBool("melee",false);
            }

            if(Time.time > lastBow + 1.2f)
            {
                arrowSprite.enabled = false;
                if(arrow.position != rb.position)
                {
                    arrow.position = rb.position;
                    arrow.velocity = new Vector2(0,0).normalized;
                }
            }

            //ranged
            if(Input.GetKeyDown(KeyCode.L) && Time.time - lastBow > 2.0f && globalVars.ranged != "")
            {
                arrowDir.position = rb.position;
                arrowSprite.enabled = true;
                lastBow = Time.time;
                bowSound.Play();
                animator.SetBool("bow", true);
                
                if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standLeft") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingLeft")
                {
                    if(vertical > 0)
                    {
                        bowLeftAnimator.SetBool("on",true);
                        bowLeftSprite.enabled = true;

                        arrowDir.eulerAngles = new Vector3(0, 0, 135);
                        arrow.velocity = new Vector2(-1, 1).normalized * 4.0f;
                    }
                    else if(vertical < 0)
                    {
                        bowLeftAnimator.SetBool("on",true);
                        bowLeftSprite.enabled = true;

                        arrowDir.eulerAngles = new Vector3(0, 0, 225);
                        arrow.velocity = new Vector2(-1, -1).normalized * 4.0f;

                    }
                    else
                    {
                        bowLeftAnimator.SetBool("on",true);
                        bowLeftSprite.enabled = true;

                        arrowDir.eulerAngles = new Vector3(0, 0, 180);
                        arrow.velocity = new Vector2(-1, 0).normalized * 4.0f;
                    }
                }
                else if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standRight") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingRight")
                {
                    if(vertical > 0)
                    {
                        arrowDir.eulerAngles = new Vector3(0, 0, 45);
                        arrow.velocity = new Vector2(1, 1).normalized * 4.0f;
                    }
                    else if(vertical < 0)
                    {
                        arrowDir.eulerAngles = new Vector3(0, 0, -45);
                        arrow.velocity = new Vector2(1, -1).normalized * 4.0f;
                    }
                    else
                    {
                        arrowDir.eulerAngles = new Vector3(0, 0, 0);
                        arrow.velocity = new Vector2(1, 0).normalized * 4.0f;
                    }

                    bowRightAnimator.SetBool("on",true);
                    bowRightSprite.enabled = true;
                }
                else if(vertical > 0)
                {
                    if(horizontal < 0)
                    {
                        bowRightAnimator.SetBool("on",true);
                        bowRightSprite.enabled = true;

                        arrowDir.eulerAngles = new Vector3(0, 0, 135);
                        arrow.velocity = new Vector2(-1, 1).normalized * 4.0f;
                    }
                    else if(horizontal > 0)
                    {
                        arrowDir.eulerAngles = new Vector3(0, 0, 45);
                        arrow.velocity = new Vector2(1, 1).normalized * 4.0f;
                    }
                    else
                    {
                        bowRightAnimator.SetBool("on",true);
                        bowRightSprite.enabled = true;

                        arrowDir.eulerAngles = new Vector3(0, 0, 90);
                        arrow.velocity = new Vector2(0, 1).normalized * 4.0f;
                    }
                }
                else if(vertical < 0)
                {
                    
                    if(horizontal < 0)
                    {
                        
                        bowLeftAnimator.SetBool("on",true);
                        bowLeftSprite.enabled = true;

                        arrowDir.eulerAngles = new Vector3(0, 0, 225);
                        arrow.velocity = new Vector2(-1, -1).normalized * 4.0f;
                    }
                    else if(horizontal > 0)
                    {
                        arrowDir.eulerAngles = new Vector3(0, 0, -45);
                        arrow.velocity = new Vector2(1, -1).normalized * 4.0f;
                    }
                    else
                    {

                        arrowDir.eulerAngles = new Vector3(0, 0, -90);
                        arrow.velocity = new Vector2(0, -1).normalized * 4.0f;
                    }
                    bowLeftAnimator.SetBool("on",true);
                    bowLeftSprite.enabled = true;
                }
                else
                {
                    
                    bowLeftAnimator.SetBool("on",true);
                    bowLeftSprite.enabled = true;

                    arrowDir.eulerAngles = new Vector3(0, 0, 90);
                    arrow.velocity = new Vector2(0, 1).normalized * 4.0f;
                }

            }
            else
            {

                animator.SetBool("bow",false);
            }


            
            //checking if magic is on
            if(Input.GetKeyDown(KeyCode.K) && Time.time - lastMagic > 2.0f && globalVars.magic != "")
            {
                animator.SetBool("magic", true);
                magicSound.Play();
                lastMagic = Time.time;

                if(vertical > 0 || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standUp")
                {
                    
                    if(horizontal > 0)
                    {
                        magicUpRightAnimator.SetBool("on",true);
                        magicUpRightSprite.enabled = true;
                        magicUpRightBox.enabled = true;
                    }
                    else if(horizontal < 0)
                    {
                        magicUpLeftAnimator.SetBool("on",true);
                        magicUpLeftSprite.enabled = true;
                        magicUpLeftBox.enabled = true;
                    }
                    else
                    {
                        magicUpAnimator.SetBool("on",true);
                        magicUpSprite.enabled = true;
                        magicUpBox.enabled = true;
                    }
                }
                else if(vertical < 0)
                {
                    if(horizontal > 0)
                    {
                        magicDownRightAnimator.SetBool("on",true);
                        magicDownRightSprite.enabled = true;
                        magicDownRightBox.enabled = true;
                    }
                    else if(horizontal < 0)
                    {
                        magicDownLeftAnimator.SetBool("on",true);
                        magicDownLeftSprite.enabled = true;
                        magicDownLeftBox.enabled = true;
                    }
                    else
                    {
                        magicDownAnimator.SetBool("on",true);
                        magicDownSprite.enabled = true;
                        magicDownBox.enabled = true;
                    }
                }
                else
                {
                    
                    if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standRight") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingRight" || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "magicRight")
                    {
                        magicRightAnimator.SetBool("on",true);
                        magicRightSprite.enabled = true;
                        magicRightBox.enabled = true;
                    }
                    else if((animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "standLeft") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkingLeft" || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "magicLeft")
                    {
                        magicLeftAnimator.SetBool("on",true);
                        magicLeftSprite.enabled = true;
                        magicLeftBox.enabled = true;
                    }
                    else if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "still")
                    {
                        magicDownAnimator.SetBool("on",true);
                        magicDownSprite.enabled = true;
                        magicDownBox.enabled = true;
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
