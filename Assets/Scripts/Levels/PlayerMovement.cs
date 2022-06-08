using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed, jumpPower;
    private bool isGrounded;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(transform.right * horizontal * moveSpeed);
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (obj.CompareTag("Planet"))
        {
            body.drag = 5f;

            float distance = Mathf.Abs(obj.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, obj.transform.position));
            if (distance < 1f)
            {
                isGrounded = distance < 0.1f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet"))
        {
            body.drag = 0.5f;
        }
    }

}
