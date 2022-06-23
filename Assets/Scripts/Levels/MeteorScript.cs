using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    float timer = 0.0f;
    public float delay = 100.0f;
    public GameObject Meteor;


    float xAxisSpeed = 0.1f;
    float zAxisSpeed = -0.05f;
    bool movingRight = true;
    //float sinInd = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector3(Mathf.Cos(sinInd) * 10, 0, 0);
        //sinInd += Time.deltaTime * 0.5f; 
        if(movingRight == true)
        {
            transform.position += new Vector3(xAxisSpeed, zAxisSpeed);
        }
    }
}

