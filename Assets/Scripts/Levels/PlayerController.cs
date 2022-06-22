using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f, jumpPower = 10f;
    public SpriteRenderer sprite;

    Rigidbody2D body;
    public bool isGrounded;
    public float horizontal;
    public float distance;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            StartCoroutine(TurnOffMovement());
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            body.AddForce(transform.right * horizontal * moveSpeed);
        }
        sprite.flipX = horizontal > 0 ? false : (horizontal < 0 ? true : sprite.flipX);
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet"))
        {
            body.drag = 1f;

            distance = Mathf.Abs(obj.gameObject.GetComponent<PlanetController>().planetRadius - Vector2.Distance(transform.position, obj.transform.position));
            if (distance < 1f)
            {
                isGrounded = distance < 0.55f;
            }
        }
    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Surface"))
        {
            canMove = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet"))
        {
            body.drag = 0.2f;
        }
    }

    IEnumerator TurnOffMovement()
    {
        yield return new WaitForSeconds(2f);

        canMove = false;

        yield return null;
    }
}