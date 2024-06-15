using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dwarf : MonoBehaviour
{
    public string[] quests = new string[3];
    public GameObject panel;
    public TMP_Text questText;
    public GameObject player;
    private bool canChange = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        quests = new string[] {
            "Hello traveler, my name is Hogginsworth the dwarf. I could use your help with some things, I will reward you handsomely. Go speak with the elder in the town hall first and then return to me.",
            "edef",
            "aefaef"};
    }

    // Update is called once per frame
    void Update()
    {
        if(!animator.GetBool("Idle"))
        {
            if(canChange == true)
            {
                questText.gameObject.SetActive(false);
                panel.SetActive(false);
                canChange = false;
            }
        }
    }

    public void Dialogue()
    {
        canChange = true;

        questText.text = quests[globalVars.quest];
        questText.gameObject.SetActive(true);
        panel.SetActive(true);
    }
}
