using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public GameObject dialogueCanvas;
    private DialogueTextController txt;

    public string dialogueName;
    public string[] dialogue;
    public string[] dialogue2;

    public bool canTalk = true;

    public int dialogueFase = 0; //Gives the fase the dialogue is currently in, starts at 0

    private GameObject player;
    public bool playerInRange;
    public float maxDistance;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //Sets the player object to the object named Player
        dialogueCanvas = GameObject.FindGameObjectWithTag("dialogue_cv");
        txt = dialogueCanvas.GetComponent<DialogueTextController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = DistanceToPlayer(); //Set if the player is in range for starting conversation

        //If the player does not have a dialogue box open and presses , start the conversation
        if(playerInRange && Input.GetKeyDown(KeyCode.E) && canTalk)
        {
            canTalk = false;

            StartCoroutine(Conversation());
        }

        /*//If the player has a dialogue box open and presses escape, OR the player walks out of range, stop the conversation
        if (!playerInRange || Input.GetKeyUp(KeyCode.Escape))
        {

        }*/
    }

    IEnumerator Conversation()
    {
        //txt.bg.gameObject.SetActive(true);

        for (int i = 0; i < dialogue.Length; i++) //For every dialogue entry:
        {
            //Set dialogue text to entry;
            txt.SetText(dialogue[i], dialogueName);

            yield return new WaitForSeconds(dialogue[i].Length * 0.025f);

            //Wait for Interact input;
            while (!Input.GetButtonUp("Interact"))
            {
                yield return null;
            }
        }

        canTalk = true;

        //txt.bg.gameObject.SetActive(false);

        yield break;
    }

    //Will check if the distance to the player is under a certain amount, if so return true
    internal bool DistanceToPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position); //Check the distance between npc and player

        if (distance < maxDistance) //If the distance is under the max distance;
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    

    public void SetDialogueFase(int fase)
    {
        dialogueFase = fase;
    }


}
