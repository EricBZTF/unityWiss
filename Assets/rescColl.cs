using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rescColl : MonoBehaviour
{
    public GameObject[] woodcutter;
    int counter = 0;
    int accutalAmount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //TextMeshPro textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        woodcutter = GameObject.FindGameObjectsWithTag("woodBuild");

        foreach (GameObject woodBuild in woodcutter)
        {
            counter++;
        }

        


    }
}
