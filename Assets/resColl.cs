using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resColl : MonoBehaviour {

    public GameObject[] woodcuter;
    int counter = 30;
    bool isCoroutineExecuting = false;

    public TMP_Text resCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodcuter = GameObject.FindGameObjectsWithTag("buildWood");

        StartCoroutine(delay());

        resCounter.text = counter.ToString();
    }


    IEnumerator delay()
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(5);
        for (int i = 0; i < woodcuter.Length; i++)
        {
            counter++;
        }

        isCoroutineExecuting = false;
        Debug.Log(counter);

    }

    public void pay()
    {
        counter -= 10;
    }
  }

