using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionTextManager : MonoBehaviour
{
    public TMP_Text collisionText; // Reference to the Text UI element

    private void Start()
    {
        collisionText.gameObject.SetActive(false); // Initially hide the text
    }

    public void ShowCollisionText(string message)
    {
        collisionText.text = message;
        collisionText.gameObject.SetActive(true); // Show the text
    }

    public void HideCollisionText()
    {
        collisionText.gameObject.SetActive(false); // Hide the text
    }
}
