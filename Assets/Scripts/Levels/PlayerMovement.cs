using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed, jumpPower;
    public GameObject vacuum;
    private VacuumController vc;
    private bool isGrounded;
    private float horizontal;
    public List<Sprite> sprites;
    private bool isIdle = true;

    public bool vacuumEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        vc = vacuum.GetComponent<VacuumController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }

        if (Input.GetButton("Suck") && vacuumEnabled)
        {
            vc.StartAction(true);
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }

        if (Input.GetButton("Blow") && vacuumEnabled)
        {
            vc.StartAction(false);
            isIdle = false;
        }
        else
        {
            isIdle = true;
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(transform.right * horizontal * moveSpeed);

        if (isIdle)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = sprites[0]; //Set sprite to idle
        }
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (obj.CompareTag("Planet"))
        {
            body.drag = 1.5f;

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
