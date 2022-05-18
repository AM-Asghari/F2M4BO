using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.W))
            transform.Rotate(_rotation * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.up * Time.deltaTime;
    }
}
