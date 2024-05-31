using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public Collider2D outer;
    public Collider2D inner;
    public Transform player;
    private Animator animator;
    public float speed = 2.0f;

    private bool isPlayerInOuterRange = false;
    private bool isPlayerInInnerRange = false;
    public GameObject playerObject;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;

        // Ensure initial Animator parameters
        animator.SetBool("attack", false);
        animator.SetBool("walkRight", false);
        animator.SetBool("walkLeft", false);
    }

    void Update()
    {
        CheckPlayerPosition();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (isPlayerInOuterRange && !isPlayerInInnerRange)
        {
            animator.SetBool("attack", false);
            MoveTowardsPlayer();
        }
        else if (isPlayerInInnerRange)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("attack", false);
        }

    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // Calculate the direction to move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            if (direction.x > 0)
            {
                animator.SetBool("walkRight", true);
                animator.SetBool("walkLeft", false);
            }
            else
            {
                animator.SetBool("walkRight", false);
                animator.SetBool("walkLeft", true);
            }
            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void CheckPlayerPosition()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            isPlayerInOuterRange = outer.bounds.Contains(playerPosition);
            isPlayerInInnerRange = inner.bounds.Contains(playerPosition);
        }
    }

    // Method to be called by the animation event
    public void Damage()
    {
        playermovement playerMovement = playerObject.GetComponent<playermovement>();
        if (isPlayerInInnerRange)
        {
            playerMovement.health -= 1; // Decrement player health by one
        }
    }
}
