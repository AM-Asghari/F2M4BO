using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public string npcName; //The name of the NPC
    public string[] dialogues; //All the dialogue entries
    public float maxDistance = 3f; //The max distance required to talk to the npc

    public GameObject convoBox; //The whole dialogue box object
    public GameObject player; //Player object
    public GameObject nameObject; //Text containing NPC name
    private TMPro.TextMeshProUGUI textMeshName; //The text component in the nameObject
    public GameObject textObject; //The dialogue text object
    private TMPro.TextMeshProUGUI textMeshChat; //The text component in the textObject

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
        textMeshChat.text = dialogues[0]; //Set the first dialogue entry

        yield return new WaitForSeconds(0.25f);

        //For every piece of text that the NPC has in string[] dialogues,
        foreach (string entry in dialogues)
        {
            textMeshChat.text = entry; //Show that text in the dialogue box
            while (!Input.GetKeyDown(KeyCode.E)) //Wait for button input
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.05f);
        } //When everything has been said,

        convoBox.SetActive(false); //Hide the dialogue box

        yield return null;
    }

    void StopConversation()
    {
        convoBox.SetActive(false); //Hide the dialogue box
        StopCoroutine(StartConversation()); //Stop the dialogue
    }


}
