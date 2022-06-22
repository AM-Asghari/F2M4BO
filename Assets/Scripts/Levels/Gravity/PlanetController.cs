using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public float gravityScale = 12f;
    public float planetRadius = 2f;
    public float gravityMinRange = 1f;
    public float gravityMaxRange = 2f;
    public GameObject planet;
    public GameObject minRS;
    public GameObject maxRS;

    // Start is called before the first frame update
    void Update()
    {
        minRS.transform.localScale = new Vector3((planetRadius + gravityMinRange) * 2, (planetRadius + gravityMinRange) * 2, 1);
        maxRS.transform.localScale = new Vector3((planetRadius + gravityMinRange + gravityMaxRange) * 2, (planetRadius + gravityMinRange + gravityMaxRange) * 2, 1);
        GetComponent<CircleCollider2D>().radius = gravityMaxRange;
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        float gravitationalPower = gravityScale / planetRadius;
        float dist = Vector2.Distance(obj.transform.position, transform.position);

        if (dist > (planetRadius + gravityMinRange))
        {
            float min = planetRadius + gravityMinRange + 0.5f;
            gravitationalPower = gravitationalPower * ((min + gravityMaxRange - dist) / gravityMaxRange);
        }

        Vector3 dir = (transform.position - obj.transform.position) * gravitationalPower;
        obj.GetComponent<Rigidbody2D>().AddForce(dir);

        if (obj.CompareTag("Player"))
        {
            obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravitationalPower * Time.deltaTime * 5f);
        }
    }
}