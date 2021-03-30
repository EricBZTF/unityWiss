using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toCopy : MonoBehaviour  
{
    public GameObject sPrefab;
    public Vector2 clonePos;
    // Start is called before the first frame update
    void Start()
    {
        clonePos.y = 0;
        clonePos.x = 160;
        sPrefab = GameObject.Find("SquarePrefab");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("click");
        GameObject newGO = GameObject.Instantiate(sPrefab, transform.position, transform.rotation) as GameObject;
        
    }
}
