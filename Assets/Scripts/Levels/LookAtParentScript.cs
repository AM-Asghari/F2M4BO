using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtParentScript : MonoBehaviour
{
    //This script is used by the vacuum object to have the same rotation as its parent

    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtParent();
    }

    private void LookAtParent()
    {
        transform.rotation = parent.transform.rotation;
    }
}
