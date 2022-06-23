using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            animator.SetBool("running", true);
            if( Input.GetKey("d"))
            {
                //flip the character rightside
                transform.localScale = new Vector3(-1,1,1);
            }
            else
            {
                //flip the character leftside
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        { 
            animator.SetBool("running", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", true);
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", false);
        }
    }
}
