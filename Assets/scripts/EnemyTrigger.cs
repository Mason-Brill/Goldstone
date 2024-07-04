using UnityEngine;
using TMPro;

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
    public GameObject enemyObject;
    public int enemyDamage = 0;
    private float waitTime;
    private float health = 100f;
    private AudioSource audioSource;
    public AudioClip[] damageSounds;
    public TMP_Text Text;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        audioSource = GetComponent<AudioSource>();

        // Ensure initial Animator parameters
        animator.SetBool("attack", false);
        animator.SetBool("walkRight", false);
        animator.SetBool("walkLeft", false);
    }

    void Update()
    {
        if(health <= 0)
        {
            Text.text = "Health: 0";
        }
        else
        {
            Text.text = "Health: " + health;
        }

        CheckPlayerPosition();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if(health <= 0)
        {
            animator.SetBool("dead",true);
        }

        if (isPlayerInOuterRange && !isPlayerInInnerRange)
        {
            if(animator.GetBool("attack"))
            {
                if(Time.time > waitTime +1.0f)
                {
                    animator.SetBool("attack", false);
                }
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
        else if (isPlayerInInnerRange)
        {
            animator.SetBool("attack", true);
            waitTime = Time.time;
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
        if (isPlayerInInnerRange)
        {
            globalVars.health -= enemyDamage;
            
            int randomIndex = Random.Range(0, damageSounds.Length);
            audioSource.clip = damageSounds[randomIndex];
            audioSource.Play();
        }
    }

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
    }

    public void Dead()
    {
        Destroy(enemyObject);
    }
}
