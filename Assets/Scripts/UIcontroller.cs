using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public Text scoreTextObject;
    public GameObject mapObject;
    public GameObject LevelController;
    public bool mapEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        Text score = scoreTextObject.GetComponent<Text>();
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name != "Level00")
        {
            Debug.Log(scene.name);
            mapEnabled = true;
        }
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
        else if(mapObject.activeSelf == false && mapEnabled == true)
        {
            mapObject.SetActive(true);
        }
    }

    public void UnlockMap()
    {
        mapEnabled = true;
        LevelController.SendMessage("RunMapTutorial", null, SendMessageOptions.DontRequireReceiver);
    }

    
}
