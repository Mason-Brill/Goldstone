using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowSpriteOff : MonoBehaviour
{
    private Animator bowAnimator;
    private SpriteRenderer bowSprite;

    // Start is called before the first frame update
    void Start()
    {
        bowAnimator = GetComponent<Animator>();
        bowSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rangedSpriteOff()
    {
        bowSprite.enabled = false;
        bowAnimator.SetBool("on",false);
    }
}
