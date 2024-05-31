using UnityEngine;
using TMPro;

public class NPCInteractionManager : MonoBehaviour
{
    public TMP_Text interactionText; // Reference to the UI Text element for interaction prompt

    private bool isPlayerInRange = false;
    private GameObject currentNPC;
    public Collider2D range;
    public Transform player;
    private bool canChange = false;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
            
        CheckPlayerPosition();
        if (isPlayerInRange)
        {
            interactionText.gameObject.SetActive(true);
            canChange = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        else
        {
            if(canChange == true)
            {
                interactionText.gameObject.SetActive(false);
                canChange = false;
            }
        }
    }

    private void StartDialogue()
    {
        Debug.Log("convo started");
    }

    private void CheckPlayerPosition()
    {
        if (player != null && range != null)
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y, range.bounds.center.z);
            isPlayerInRange = range.bounds.Contains(playerPos);
        }
    }
    
}
