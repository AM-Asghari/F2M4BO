using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovingPlanet : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    //Vector3 velocity;
    float n = 0f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

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