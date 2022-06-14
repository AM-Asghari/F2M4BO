using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Level1PushPlanet : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    //Vector3 velocity;
    float n = 0f;
    public float speed;
    float xAxisSpeed = -0.009f;
    float zAxisSpeed = 0.007f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position += new Vector3(xAxisSpeed, zAxisSpeed);
        }
        //transform.position = B.transform.position + n * (A.transform.position - B.transform.position);

        //n += speed;
        //if (n > 1)
        //{
        //    speed = -Mathf.Abs(speed);
        //}

        //if (n < 0)
        //{
        //    speed = Mathf.Abs(speed);
        //}

    }
}