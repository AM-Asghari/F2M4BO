using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetGravity : MonoBehaviour
{
    public float gravityRadius = 3f;
    public float gravityStrength = 1f;

    private Vector3 planetPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        planetPos = transform.position;
        Collider2D[] objectsInRadius = GetObjectsInRadius();
        
        foreach (Collider2D obj in objectsInRadius)
        {
            if (obj.gameObject.name != "Planet" && obj.gameObject.tag != "onPlanet")
            {
                //Make object fall towards gravitational mass

                Rigidbody2D crb = obj.GetComponent<Rigidbody2D>();

                float distance = Vector3.Distance(planetPos, obj.transform.position);

                Vector3 v = planetPos - obj.transform.position;

                crb.AddForce(v.normalized * (1.0f - distance / gravityRadius) * gravityStrength);

                //Make object face gravitational mass

                Vector3 lookDirection = planetPos - obj.transform.position;
                float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90;

                obj.transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);

                /*Vector3 objPos = obj.transform.position;
                planetPos = new Vector3(planetPos.x, planetPos.y, 0);

                planetPos.x = planetPos.x - objPos.x;
                planetPos.y = planetPos.y - objPos.y;

                float angle = Mathf.Atan2(planetPos.y, planetPos.x) * Mathf.Rad2Deg;
                obj.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));*/
            }
        }
    }

    internal Collider2D[] GetObjectsInRadius()
    {
        Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(new Vector2(0, 0), gravityRadius);

        return objectsInRadius;
    }

}
