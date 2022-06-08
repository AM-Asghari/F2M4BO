using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovingPlanet : MonoBehaviour
{
    GameObject A;
    GameObject B;
    //Vector3 velocity;
    float n = 0f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        A = GameObject.Find("A");
        B = GameObject.Find("B");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = B.transform.position + n * (A.transform.position - B.transform.position);

        n += speed;
        if (n > 1)
        {
            speed = -Mathf.Abs(speed);
        }

        if (n < 0)
        {
            speed = Mathf.Abs(speed);
        }

    }
}