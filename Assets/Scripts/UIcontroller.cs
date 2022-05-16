using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text scoreTextObject;

    // Start is called before the first frame update
    void Start()
    {
        Text score = scoreTextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int amount)
    {
        scoreTextObject.text = amount.ToString();
    }
}
