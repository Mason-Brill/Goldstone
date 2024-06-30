using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeOff : MonoBehaviour
{
    private Animator meleeAnimator;
    private SpriteRenderer meleeSprite;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        meleeAnimator = GetComponent<Animator>();
        meleeSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && collision is BoxCollider2D)
        {
            collision.transform.parent.GetComponent<EnemyTrigger>().TakeDamage(50f);
        }
    }

    public void meleeSpriteOff()
    {
        meleeSprite.enabled = false;
        boxCollider.enabled = false;
    }
}
