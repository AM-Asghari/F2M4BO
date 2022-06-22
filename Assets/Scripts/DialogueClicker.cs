using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueClicker : MonoBehaviour
{
    public GameObject dialogueCanvas;
    private DialogueTextController dialogueController;

    public string dialogueName;
    public string[] dialogue;

    public bool canTalk = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas = GameObject.FindGameObjectWithTag("dialogue_cv");
        dialogueController = dialogueCanvas.GetComponent<DialogueTextController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Interact") && canTalk)
        {
            canTalk = false;

            StartCoroutine(Conversation());
        }
    }

    IEnumerator Conversation()
    {
        dialogueController.dialogue_active = true;

        for (int i = 0; i < dialogue.Length; i++) //For every dialogue entry:
        {
            //Set dialogue text to entry;
            dialogueController.SetText(dialogue[i], dialogueName);

            yield return new WaitForSeconds(dialogue[i].Length * 0.025f);

            //Wait for Interact input;
            while (!Input.GetButtonUp("Interact"))
            {
                yield return null;
            }
        }

        canTalk = true;

        dialogueController.dialogue_active = false;

        yield break;
    }
}
