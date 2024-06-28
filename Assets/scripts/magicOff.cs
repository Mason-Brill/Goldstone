using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicOff : MonoBehaviour
{
    private Animator magicAnimator;
    private SpriteRenderer magicSprite;

    // Start is called before the first frame update
    void Start()
    {
        magicAnimator = GetComponent<Animator>();
        magicSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void magicSpriteOff()
    {
        magicSprite.enabled = false;
    }
}
