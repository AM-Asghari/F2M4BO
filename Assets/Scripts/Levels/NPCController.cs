using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCController : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public DialogueTextController cont;

    public string npcName;
    public string[] dialogue_1;
    public string[] dialogue_2;

    public int fase;

    public float maxDistance;

    public bool canTalk;
    public bool inRange;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas = GameObject.FindGameObjectWithTag("dialogue_cv");
        cont = dialogueCanvas.GetComponent<DialogueTextController>();
        canTalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        inRange = DistanceToPlayer();

        if (Input.GetButtonUp("Interact") && canTalk && inRange)
        {
            canTalk = false;

            StartCoroutine(Conversation());
        }
    }

    IEnumerator Conversation()
    {
        cont.dialogue_active = true;

        if (fase == 0)
        {
            for (int i = 0; i < dialogue_1.Length; i++) //For every dialogue entry:
            {
                //Set dialogue text to entry;
                cont.SetText(dialogue_1[i], npcName);

                yield return new WaitForSeconds(dialogue_1[i].Length * 0.025f);

                //Wait for Interact input;
                while (!Input.GetButtonUp("Interact"))
                {
                    yield return null;
                }
            }
        }
        else if (fase == 1)
        {
            for (int i = 0; i < dialogue_2.Length; i++) //For every dialogue entry:
            {
                //Set dialogue text to entry;
                cont.SetText(dialogue_2[i], npcName);

                yield return new WaitForSeconds(dialogue_2[i].Length * 0.025f);

                //Wait for Interact input;
                while (!Input.GetButtonUp("Interact"))
                {
                    yield return null;
                }
            }
        }


        canTalk = true;

        cont.dialogue_active = false;

        yield break;
    }

    private bool DistanceToPlayer()
    {
        distance = Vector2.Distance(GameObject.Find("Player").transform.position, transform.position);
        if(distance > maxDistance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
