using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartupSequence : MonoBehaviour
{
    public GameObject interfaces;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        StartCoroutine(ChangeTransparency());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeTransparency()
    {
        for (float i = 1; i > 0.01; i = i - 0.01f)
        {
            Debug.Log(i);
            sr.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.025f);
        }
        gameObject.SetActive(false);
    }
}
