using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour
{
    public float suckSpeed = 0.5f;
    public GameObject player;
    public GameObject hiddenObj;
    public List<GameObject> exceptions = new List<GameObject>();

    private Rigidbody2D rb;
    private Collider2D coll;
    public List<Collider2D> colls = new List<Collider2D>();

    private LookAtMouse hiddenObjScr;
    private PlayerMovement playerScript;
    public Vector3 hiddenRot;
    public float degrees;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        hiddenObjScr = hiddenObj.GetComponent<LookAtMouse>();
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        GetColliders();
        hiddenRot = hiddenObj.transform.rotation.eulerAngles;
    }

    private void Suck()
    {
        Debug.Log("Suck");

        foreach (Collider2D c in colls)
        {
            if (!exceptions.Contains(c.gameObject) && c.gameObject.tag != "Planet")
            {
                rb = c.GetComponent<Rigidbody2D>();

                Vector3 targ = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
                targ.z = 0f;
                Vector3 objectPos = c.transform.position;

                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;
                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

                c.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                rb.AddRelativeForce(new Vector2(suckSpeed, 0));
            }
        }
    }

    private void Blow()
    {
        Debug.Log("Blow");

        foreach (Collider2D c in colls)
        {
            if (!exceptions.Contains(c.gameObject) && c.gameObject.tag != "Planet")
            {
                rb = c.GetComponent<Rigidbody2D>();

                Vector3 targ = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
                targ.z = 0f;
                Vector3 objectPos = c.transform.position;

                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;
                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

                c.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                rb.AddRelativeForce(new Vector2(-suckSpeed, 0));
            }
        }
    }

    private void GetColliders()
    {
        ContactFilter2D contactFilter2D = new ContactFilter2D().NoFilter();

        Physics2D.OverlapCollider(coll, contactFilter2D, colls);
    }



    public void StartAction(bool sucking) //True means the action is sucking, false means blowing
    {
        SpriteRenderer sr =  player.GetComponent<SpriteRenderer>();

        degrees = hiddenRot.z;

        Debug.Log("Current degrees: " + degrees);

        if(degrees < 45 && degrees > 0 || degrees < 360 && degrees > 315)
        {
            Debug.Log(degrees + " is between 315 and 45 degrees");
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            sr.sprite = playerScript.sprites[1]; //Set sprite to east
        }
        else if(degrees < 135 && degrees > 45)
        {
            Debug.Log(degrees + " is between 45 and 135 degrees");
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
            sr.sprite = playerScript.sprites[4]; //Set sprite to south
        }
        else if (degrees < 225 && degrees > 135)
        {
            Debug.Log(degrees + " is between 135 and 225 degrees");
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
            sr.sprite = playerScript.sprites[3]; //Set sprite to west
        }
        else if (degrees < 315 && degrees > 225)
        {
            Debug.Log(degrees + " is between 225 and 315 degrees");
            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270);
            sr.sprite = playerScript.sprites[2]; //Set sprite to north
        }
        else
        {
            Debug.Log("Nothing true");
            sr.sprite = playerScript.sprites[0]; //Set sprite to idle
        }

        if (sucking)
        {
            Suck();
        }
        else if (!sucking)
        {
            Blow();
        }
        else
        {
            Debug.Log("Not sucking or blowing");
        }
    }

    
}
