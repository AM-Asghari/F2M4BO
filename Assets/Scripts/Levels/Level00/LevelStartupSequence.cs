using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartupSequence : MonoBehaviour
{
    public GameObject score;
    public GameObject faseNPC;
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
        tutorialText = textObject.GetComponent<TMPro.TextMeshProUGUI>();

        tutorialGroup.SetActive(false);
        
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

        yield return new WaitForSeconds(textDelay / 3);

        //Player jumping info
        tutorialText.text = texts[2];

        //Wait for Space
        while (!Input.GetKeyUp(KeyCode.Space))
        {
            yield return null;
        }

        yield return new WaitForSeconds(textDelay);

        //Playerjump to planet info
        tutorialText.text = texts[3];

        yield return new WaitForSeconds(textDelay + 5);

        //Player talk to NPC info
        tutorialText.text = texts[4];

        //Wait for E
        while (!Input.GetKeyUp(KeyCode.E))
        {
            yield return null;
        }

        //Wait for A
        while (!Input.GetKeyUp(KeyCode.A))
        {
            yield return null;
        }

        //Player boost to planet info
        tutorialText.text = texts[5];

        //Wait for Right Mouse
        while (!Input.GetMouseButtonDown(1))
        {
            yield return null;
        }

        yield return new WaitForSeconds(textDelay);

        //Player suck info
        tutorialText.text = texts[6];

        //Wait for Left Mouse
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        yield return new WaitForSeconds(textDelay);

        tutorialText.text = texts[7];
        faseNPC.SendMessage("SetDialogueFase", 1);

        //Wait for E
        while (!Input.GetKeyUp(KeyCode.E))
        {
            yield return null;
        }

        //Wait for A
        while (!Input.GetKeyUp(KeyCode.A))
        {
            yield return null;
        }

        tutorialText.text = texts[8];

        //Wait for M
        while (!Input.GetKeyDown(KeyCode.M))
        {
            yield return null;
        }

        tutorialGroup.SetActive(false);

        yield return null;

    }

    

    
}
