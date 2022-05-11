using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float jumpThrust = 2f;
    public float speed = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        //Movement mechanics

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }


        /*if (gameObject.tag == "onPlanet")
        {
            rb.velocity = new Vector2(0, 0);
        }*/

    }
}
