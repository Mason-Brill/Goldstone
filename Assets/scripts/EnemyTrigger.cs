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

    void Start()
    {
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }
    void Update()
    {
       CheckPlayerPosition();

        if (isPlayerInOuterRange && !isPlayerInInnerRange)
        {
            animator.SetBool("attack",false);
            MoveTowardsPlayer();
        }
        else
        {
            // Reset animator parameters when the player is out of range
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            if(isPlayerInInnerRange)
            {
                animator.SetBool("attack", true);
                
            }
            else
            {
                animator.SetBool("attack",false);
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // Calculate the direction to move towards the player
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

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
            if(!stateInfo.IsName("attack"))
            {
                transform.position += direction * speed * Time.deltaTime;
            }
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
}
