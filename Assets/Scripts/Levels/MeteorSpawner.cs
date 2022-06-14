using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner: MonoBehaviour
{
    float timer = 0.0f;
    public float delay = 100.0f;
    public GameObject Meteor;

    //float sinInd = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > delay)
        {
            GameObject obj = Instantiate(Meteor);
            obj.transform.position = new Vector3(-6.22f, -2.34f, 0);
            timer = 0.0f;
        }


    }
}

