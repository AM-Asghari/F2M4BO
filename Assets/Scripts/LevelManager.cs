using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel; //Level 0, 1, 2

    private GameObject hud;
    private GameObject dialogueCanvas;
    private GameObject playerObj;
    private GameObject vacuum;

    private Coroutine level;

    public string[] dialogues;

    private bool moveDialogue;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("hud");
        dialogueCanvas = GameObject.FindGameObjectWithTag("dialogue_cv");
        playerObj = GameObject.Find("Player");
        vacuum = GameObject.Find("vacuum");


        //Call level "Story"
        if(currentLevel == 0)
        {
            level = StartCoroutine(Tutorial());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tutorial()
    {
        NPCController guide = GameObject.Find("NPC_Guide").GetComponent<NPCController>();
        playerObj.GetComponent<PlayerMovement>().vacuumEnabled = false; //Disable vacuum


        StartCoroutine(SetText(dialogues[0], "Tutorial")); //Set text

        while (!moveDialogue) { yield return null; } //Wait for green light of dialogue finished

        while (!Input.GetKeyUp(KeyCode.D)) { yield return null; } //Wait for input


        StartCoroutine(SetText(dialogues[1], "Tutorial")); //Set text

        while (!moveDialogue) { yield return null; } //Wait for green light of dialogue finished

        while (!Input.GetButtonUp("Jump")) { yield return null; } //Wait for input


        StartCoroutine(SetText(dialogues[2], "Tutorial")); //Set text

        while (!moveDialogue) { yield return null; } //Wait for green light of dialogue finished

        while (!Input.GetButtonUp("Interact")) { yield return null; } //Wait for input


        playerObj.GetComponent<PlayerMovement>().vacuumEnabled = true; //Enable vacuum


        StartCoroutine(SetText(dialogues[3], "Tutorial")); //Set text

        while (!moveDialogue) { yield return null; } //Wait for green light of dialogue finished

        //Wait for star = 1


        StartCoroutine(SetText(dialogues[4], "Tutorial")); //Set text

        while (!moveDialogue) { yield return null; } //Wait for green light of dialogue finished

        //Wait for star = 0


        StartCoroutine(SetText(dialogues[5], "Tutorial")); //Set text

        while (!moveDialogue) { yield return null; } //Wait for green light of dialogue finished


        StartCoroutine(SetText(dialogues[6], "Tutorial")); //Set text

        while (!moveDialogue) { yield return null; } //Wait for green light of dialogue finished
        

        yield return null;
    }

    IEnumerator SetText(string dialogue, string name)
    {
        DialogueTextController dc = dialogueCanvas.GetComponent<DialogueTextController>(); //Get the text controller

        moveDialogue = false;

        dc.dialogue_active = true;

        //Set dialogue text to entry;
        dc.SetText(dialogue, name);

        yield return new WaitForSeconds(dialogue.Length * 0.025f);

        //Wait for Interact input;
        while (!Input.GetButtonUp("Interact"))
        {
            yield return null;
        }

        dc.dialogue_active = false;

        moveDialogue = true;

        yield return null;
    }

}
