using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public string npcName; //The name of the NPC
    public string[] dialogues0; //All the dialogue entries
    public string[] dialogues1; //Second dialogue fase, e.g. after certain event has passed
    public float maxDistance = 3f; //The max distance required to talk to the npc

    public GameObject convoBox; //The whole dialogue box object
    public GameObject player; //Player object
    public GameObject nameObject; //Text containing NPC name
    private TMPro.TextMeshProUGUI textMeshName; //The text component in the nameObject
    public GameObject textObject; //The dialogue text object
    private TMPro.TextMeshProUGUI textMeshChat; //The text component in the textObject

    public int dialogueFase = 0; //Gives the fase the dialogue is currently in, starts at 0
    public bool playerInRange;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //Sets the player object to the object named Player
        textMeshChat = textObject.GetComponent<TMPro.TextMeshProUGUI>(); //Gets the text component in textObject
        textMeshName = nameObject.GetComponent<TMPro.TextMeshProUGUI>(); //Gets the text component in nameObject

        convoBox.SetActive(false); //Confirm the convoBox is hidden
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = DistanceToPlayer(); //Set if the player is in range for starting conversation

        //If the player does not have a dialogue box open and presses , start the conversation
        if(playerInRange && Input.GetKeyDown(KeyCode.E) && convoBox.activeInHierarchy == false)
        {
            StartCoroutine(StartConversation());
        }

        //If the player has a dialogue box open and presses escape, OR the player walks out of range, stop the conversation
        if(!playerInRange)
        {
            StopConversation();
        }
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

    //Conversation
    IEnumerator StartConversation()
    {
        convoBox.SetActive(true); //Show the dialogue box
        textMeshName.text = npcName; //Set the NPC name

        switch (dialogueFase) //Set the first dialogue entry, dependent on the dialogue fase
        {
            case 1:
                textMeshChat.text = dialogues1[0];
                break;
            default:
                textMeshChat.text = dialogues0[0];
                break;
        }

        yield return new WaitForSeconds(0.25f);

        if(dialogueFase == 1)
        {
            //For every piece of text that the NPC has in string[] dialogues1,
            foreach (string entry in dialogues1)
            {
                textMeshChat.text = entry; //Show that text in the dialogue box
                while (!Input.GetKeyDown(KeyCode.E)) //Wait for button input
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            //For every piece of text that the NPC has in string[] dialogues0,
            foreach (string entry in dialogues0)
            {
                textMeshChat.text = entry; //Show that text in the dialogue box
                while (!Input.GetKeyDown(KeyCode.E)) //Wait for button input
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

        //When everything has been said;

        convoBox.SetActive(false); //Hide the dialogue box

        yield return null;
    }

    void StopConversation()
    {
        convoBox.SetActive(false); //Hide the dialogue box
        StopAllCoroutines(); //Stop the dialogue
    }

    public void SetDialogueFase(int fase)
    {
        dialogueFase = fase;
    }


}
