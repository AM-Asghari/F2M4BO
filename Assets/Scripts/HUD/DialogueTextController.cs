using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTextController : MonoBehaviour
{
    public GameObject txtObject;
    public TextMeshProUGUI txt;

    public GameObject bg;

    public GameObject nameObject;
    public TextMeshProUGUI nametxt;

    public bool dialogue_active = false;

    // Start is called before the first frame update
    void Start()
    {
        txtObject = GameObject.FindGameObjectWithTag("dialogue_txt");
        bg = GameObject.FindGameObjectWithTag("dialogue_bg");
        nameObject = GameObject.FindGameObjectWithTag("dialogue_name");

        txt = txtObject.GetComponent<TextMeshProUGUI>();
        nametxt = nameObject.GetComponent<TextMeshProUGUI>();

        //Empty text
        txt.text = "";
        nametxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (Transform child in transform)
        {
            if (dialogue_active == false)
            {
                child.gameObject.SetActive(false);
            }
            else if(dialogue_active == true)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    public void SetText(string text, string name)
    {
        //Split the dialogue into seperate words into an array
        string[] splitText = text.Split(' ');

        StartCoroutine(DisplayText(splitText, name, 0.025f));
    }

    IEnumerator DisplayText(string[] text, string name, float delay)
    {

        txt.text = "";
        nametxt.text = name;

        for (int i = 0; i < text.Length; i++) //For each word:
        {
            foreach (char ch in text[i]) //For each character in the word:
            {
                txt.text += ch; //Add the character to the text
                yield return new WaitForSeconds(delay); //Wait delay
            }
            txt.text += " "; //Add a space after a word is finished
        }


        yield break;
    }

    
}
