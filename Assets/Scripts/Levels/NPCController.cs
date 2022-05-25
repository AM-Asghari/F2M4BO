using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject player;

    public GameObject convoBox;
    public GameObject textObject;

    public string[] dialogues;

    private TMPro.TextMeshProUGUI textMesh;

    public float minDistance = 2f;

    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        textMesh = textObject.GetComponent<TMPro.TextMeshProUGUI>();

        convoBox.SetActive(false);

        Debug.Log(convoBox.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = DistanceToPlayer();

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
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < minDistance)
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
        textMesh.text = dialogues[0]; //Set the first dialogue entry

        yield return new WaitForSeconds(0.25f);

        //For every piece of text that the NPC has in string[] dialogues,
        foreach (string entry in dialogues)
        {
            textMesh.text = entry; //Show that text in the dialogue box
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
