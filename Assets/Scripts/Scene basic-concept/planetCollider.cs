using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Planet")
        {
            gameObject.tag = "onPlanet";        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(unTag());

        IEnumerator unTag()
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.tag = "Untagged";
        }
    }
}
