using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicOff : MonoBehaviour
{
    private Animator magicAnimator;
    private SpriteRenderer magicSprite;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        magicAnimator = GetComponent<Animator>();
        magicSprite = GetComponent<SpriteRenderer>();
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
            collision.transform.parent.GetComponent<EnemyTrigger>().TakeDamage(40f);
        }
    }

    public void magicSpriteOff()
    {
        magicSprite.enabled = false;
        boxCollider.enabled = false;
    }
}
