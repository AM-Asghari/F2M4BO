using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text scoreTextObject;
    public GameObject mapObject;

    // Start is called before the first frame update
    void Start()
    {
        Text score = scoreTextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchMapVisibility();
        }
    }

    public void AddPoints(int amount)
    {
        scoreTextObject.text = amount.ToString();
    }

    public void SwitchMapVisibility()
    {
        if (mapObject.activeSelf == true)
        {
            mapObject.SetActive(false);
        }
        else
        {
            mapObject.SetActive(true);
        }
    }
}
