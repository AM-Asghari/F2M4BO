using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartupSequence : MonoBehaviour
{
    public GameObject score;
    public GameObject faseNPC;
    public GameObject player;
    private PlayerMovement pc;
    public GameObject tutorialGroup;
    public GameObject textObject;
    private TMPro.TextMeshProUGUI tutorialText;
    public string[] texts;
    public float textDelay = 2.5f;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); //Get components for sprite renderer so opacity can be changed
        pc = player.GetComponent<PlayerMovement>(); //Get the vacuum controller so variables can be changed

        tutorialText = textObject.GetComponent<TMPro.TextMeshProUGUI>();

        tutorialGroup.SetActive(false);

        pc.vacuumEnabled = false;
        
        StartCoroutine(Level()); //Start level mechanics

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Level()
    {
        //Black screen transition
        for (float i = 1f; i > 0.01f; i = i - 0.01f)
        {
            sr.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.025f);
        }
        //gameObject.SetActive(false); //Turn off black screen

        tutorialGroup.SetActive(true);

        //Player welcome text
        tutorialText.text = texts[0];

        yield return new WaitForSeconds(textDelay);

        //Player walking info
        tutorialText.text = texts[1];

        //Wait for A press
        while (!Input.GetKeyUp(KeyCode.A))
        {
            yield return null;
        }
        //Wait for D press
        while (!Input.GetKeyUp(KeyCode.D))
        {
            yield return null;
        }

        yield return new WaitForSeconds(textDelay);

        //Player jumping info
        tutorialText.text = texts[2];

        //Wait for Jump
        while (!Input.GetButtonUp("Jump"))
        {
            yield return null;
        }

        yield return new WaitForSeconds(textDelay * 2);

        //NPC info
        tutorialText.text = texts[3];

        //Wait for interact
        while (!Input.GetButtonUp("Interact"))
        {
            yield return null;
        }
        while (!Input.GetButtonUp("Interact"))
        {
            yield return null;
        }
        while (!Input.GetButtonUp("Interact"))
        {
            yield return null;
        }

        pc.vacuumEnabled = false;

        tutorialText.text = texts[4];

        //Wait for sucking
        while (!Input.GetButtonUp("Suck"))
        {
            yield return null;
        }

        tutorialText.text = texts[5];

        //Wait for interact
        while (!Input.GetButtonUp("Interact"))
        {
            yield return null;
        }
        while (!Input.GetButtonUp("Interact"))
        {
            yield return null;
        }
        while (!Input.GetButtonUp("Interact"))
        {
            yield return null;
        }

        tutorialText.text = texts[6];

        yield return new WaitForSeconds(textDelay * 1.5f);

        tutorialText.text = texts[7];

        //Wait for map
        while (!Input.GetButtonUp("Map"))
        {
            yield return null;
        }

        tutorialGroup.SetActive(false);

        yield return null;

    }

    

    
}
