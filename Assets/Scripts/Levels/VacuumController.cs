using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour
{
    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Make vacuum look at mouse position
        LookAtMouse();

        //Controls
    }

    private void LookAtMouse()
    {
        //Get screen to world position
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z =  mousePosition.z - transform.position.z;

        Debug.Log(mousePosition.ToString());

        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
