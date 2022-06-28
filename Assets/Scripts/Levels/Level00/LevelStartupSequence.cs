using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartupSequence : MonoBehaviour
{
    public GameObject score;
    public Text scoreText;
    public GameObject faseNPC;
    private NPCController npcc;
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
        scoreText = score.GetComponent<Text>();
        npcc = faseNPC.GetComponent<NPCController>();

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

        tutorialText.text = texts[2];

        //Wait for Space press
        while (!Input.GetKeyUp(KeyCode.Space))
        {
            yield return null;
        }

        yield return new WaitForSeconds(textDelay);

        tutorialText.text = texts[3];

        //Wait for interact
        while (!Input.GetKeyUp(KeyCode.E))
        {
            yield return null;
        }
        while (!Input.GetKeyUp(KeyCode.E))
        {
            yield return null;
        }
        while (!Input.GetKeyUp(KeyCode.E))
        {
            yield return null;
        }

        //Transition to black screen again
        for (float i = 0.01f; i < 1f; i = i + 0.01f)
        {
            sr.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.025f);
        }

        //Enable vacuum
        pc.vacuumEnabled = true;

        //Black screen transition
        for (float i = 1f; i > 0.01f; i = i - 0.01f)
        {
            sr.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.025f);
        }

        tutorialText.text = texts[4];

        //Wait for star pickup
        while (!scoreText.text.Equals("1"))
        {
            yield return null;
        }

        //npcc.SetDialogueFase(1);

        tutorialText.text = texts[5];

        //Wait for E press
        while (!Input.GetKeyUp(KeyCode.E))
        {
            yield return null;
        }

        scoreText.text = "0";

        //Wait for star dropoff
        while (!scoreText.text.Equals("0"))
        {
            yield return null;
        }

        tutorialText.text = texts[6];

        yield return new WaitForSeconds(textDelay * 1.5f);

        tutorialText.text = texts[7];

        //Wait for M press
        while (!Input.GetKeyUp(KeyCode.E))
        {
            yield return null;
        }

        tutorialGroup.SetActive(false);

        yield return null;

    }

    

    
}
