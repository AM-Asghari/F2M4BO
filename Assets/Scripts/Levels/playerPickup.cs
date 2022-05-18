using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPickup : MonoBehaviour
{
    public Canvas canvas;

    public UIcontroller ui;

    // Start is called before the first frame update
    void Start()
    {
        UIcontroller ui = canvas.GetComponent<UIcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Star")) //If the thing the player collides with is an object with the "Star" tag
        {
            Debug.Log("Picking up star...");

            Destroy(collision.gameObject); //Destroy star
            ui.AddPoints(1);
        }

        if (collision.gameObject.CompareTag("Map"))
        {
            Debug.Log("Picking up map...");

            ui.UnlockMap();
        }
    }

}
