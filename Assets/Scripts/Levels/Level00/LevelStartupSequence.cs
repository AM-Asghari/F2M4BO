using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartupSequence : MonoBehaviour
{
    public GameObject score;

    public GameObject walkingtext;
    public GameObject jumpingtext;
    public GameObject maptext;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); //Get components for sprite renderer so opacity can be changed
        
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

        yield return new WaitForSeconds(2);

        walkingtext.SetActive(true);

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

        yield return new WaitForSeconds(2);

        jumpingtext.SetActive(true);

        //Wait for Space
        while (!Input.GetKeyUp(KeyCode.Space))
        {
            yield return null;
        }

        yield return new WaitForSeconds(1);

        walkingtext.SetActive(false);
        jumpingtext.SetActive(false);

        while (!Input.GetKeyUp(KeyCode.M))
        {
            yield return null;
        }

        maptext.SetActive(false);

        yield return null;

    }

    

    public void RunMapTutorial()
    {
        maptext.gameObject.SetActive(true);
    }
}
