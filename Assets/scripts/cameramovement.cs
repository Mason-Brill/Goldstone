using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Rigidbody2D mainCamera;


    // Update is called once per frame
    void Update()
    {
        mainCamera.position = new Vector2(player.position.x, player.position.y);
        
    }
}
