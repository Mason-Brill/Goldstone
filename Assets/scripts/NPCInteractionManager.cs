using UnityEngine;
using TMPro;

public class NPCInteractionManager : MonoBehaviour
{
    public TMP_Text interactionText; // Reference to the UI Text element for interaction prompt
    private bool isPlayerInRange = false;
    public Collider2D range;
    public Transform player;
    private bool canChange = false;
    private Animator animator;
    
    void Start()
    {
        interactionText.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            
        CheckPlayerPosition();
        if (isPlayerInRange)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(animator.GetBool("Idle"))
                {
                    animator.SetBool("Idle",false);
                    interactionText.gameObject.SetActive(true);
                }
                else
                {
                    canChange = true;
                    interactionText.gameObject.SetActive(false);
                    StartDialogue();
                }
            }
            else if(canChange == false)
            {
                interactionText.gameObject.SetActive(true);
                canChange = true;
            }
        }
        else
        {
            if(canChange == true)
            {
                interactionText.gameObject.SetActive(false);
                canChange = false;

                animator.SetBool("Idle",false);
            }
            interactionText.text = "Press 'E' to interact";
        }
    }
//hi mason ppokie bear i love you pookie poopie pook poopie pookie bear meow meow kitty kitty bang gang
/*
are you pooping? 
im gonna be in the car
*/
    private void StartDialogue()
    {
        //this triggers an event within the idle animation that runs a function within the npcs personal script
        animator.SetBool("Idle",true);
    }

    private void CheckPlayerPosition()
    {
        if (player != null && range != null)
        {
            //grab player position(excluding 'Z' value because 2D)
            Vector3 playerPos = new Vector3(player.position.x, player.position.y, range.bounds.center.z);
            //bool value if player is in the bounds of the box collider
            isPlayerInRange = range.bounds.Contains(playerPos);
        }
    }
    
}
