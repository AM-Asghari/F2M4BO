using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartupSequence : MonoBehaviour
{
    public GameObject interfaces;
    public GameObject map;

    private SpriteRenderer sr;
    private Rigidbody2D mrb;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        mrb = map.GetComponent<Rigidbody2D>();
        interfaces.SetActive(false);
        mrb.gravityScale = 0;

        StartCoroutine(Level());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Level()
    {
        for (float i = 1; i > 0.01; i = i - 0.01f)
        {
            Debug.Log(i);
            sr.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.025f);
        }
        gameObject.SetActive(false);
        interfaces.SetActive(true);

        mrb.gravityScale = 1;
    }
}
