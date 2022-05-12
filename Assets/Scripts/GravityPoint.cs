using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    public float gravityScale, planetRadius, gravityMinRange, gravityMaxRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        float gravitationalPower = gravityScale;
        float dist = Vector2.Distance(obj.transform.position, transform.position);

        if (dist > (planetRadius + gravityMinRange))
        {
            float min = planetRadius + gravityMinRange;
            gravitationalPower = (((min + gravityMinRange) - dist) / gravityMaxRange) * gravitationalPower;
        }

        Vector3 dir = (transform.position - obj.transform.position) * gravitationalPower;
        obj.GetComponent<Rigidbody2D>().AddForce(dir);

        if (obj.CompareTag("Player"))
        {
            obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravityScale * Time.deltaTime);
        }
    }

}
