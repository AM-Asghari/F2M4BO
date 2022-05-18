using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    public GameObject parent;
    public Camera cam;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(parent.transform.position, new Vector3(0, 1, 0.1f), speed * Time.deltaTime);
        transform.LookAt(new Vector3(transform.position.x, transform.position.y, 1));
    }
}
