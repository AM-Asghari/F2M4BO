using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 0.035f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x, rotationSpeed, transform.rotation.z));
    }

    public void ZoomIn()
    {
        //Script is ran when player clicks on "Start Game" and the camera will zoom into space.
    }
}
