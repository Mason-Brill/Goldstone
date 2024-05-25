using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    //variables
    // private float horizontal = 0;
    // private float vertical = 0;
    // private float speed = 3f;

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Rigidbody2D mainCamera;


    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        // horizontal = Input.GetAxisRaw("Horizontal");
        // vertical = Input.GetAxisRaw("Vertical");
        mainCamera.position = new Vector2(player.position.x, player.position.y);
        
    }

    // private void FixedUpdate()
    // {
    //     rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    // }
}
