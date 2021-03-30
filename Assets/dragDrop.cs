using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    private bool isDragging;
    private bool build = true;
    private bool isOnFree = false;
    Renderer rend;
    public GameObject[] fSpaces;
    public GameObject freeObject;

    //get position of free Space
    private Vector2 freeSpace;
    private Vector2 thisFreeSpace;

    //get Edgews of free Space
    private Vector2 freeSpaceCopyTop;
    private Vector2 freeSpaceCopyLeft;
    private Vector2 freeSpaceCopyRight;

    //Get original Location
    private Vector3 originalLoc;


    void Start()
    {
        rend = GetComponent<Renderer>();
        fSpaces = GameObject.FindGameObjectsWithTag("FreeSpace");
        //freeSpace = GameObject.FindWithTag("FreeSpace").transform.position;
        originalLoc = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        for (int i = 0; i < fSpaces.Length; i++)
        {
            freeSpace = fSpaces[i].transform.position;

            //left edge
            freeSpaceCopyLeft = freeSpace;
            freeSpaceCopyLeft.y += 5;
            freeSpaceCopyLeft.x -= 10;

            //right edge
            freeSpaceCopyRight = freeSpace;
            freeSpaceCopyRight.y += 5;
            freeSpaceCopyRight.x += 10;

            //Top Edge
            freeSpaceCopyTop = freeSpace;
            freeSpaceCopyTop.y += 10;
            

            if (build)
            {
                //Check if mouse is pressed and move the object accordingly
                if (isDragging)
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
                    transform.Translate(mousePosition);
                }

                //Check if Object is in area to be build upon
                if (Vector2.Distance(freeSpace, this.transform.position) < 5.5 && Vector2.Distance(freeSpaceCopyTop, this.transform.position) < 5.5)
                {
                    Debug.Log(freeSpaceCopyTop);
                    Debug.Log(freeSpace);
                    rend.material.color = Color.green;
                    thisFreeSpace = fSpaces[i].transform.position;
                    isOnFree = true;
                    
                }

                //check if Objekt is not on a freespace when mouse stops being clicked
                else if (isDragging == false && Vector2.Distance(freeSpace, transform.position) > 1 && isOnFree == false)
                {
                    //Yeet it back to its starting position
                    this.transform.position = originalLoc;
                    rend.material.color = Color.white;

                }

                //Check if Object is not on a free Space and change color to white
                else if (isDragging == true && Vector2.Distance(thisFreeSpace, transform.position) < 4 || Vector2.Distance(freeSpaceCopyTop, this.transform.position) < 4 || Vector2.Distance(freeSpaceCopyLeft, this.transform.position) < 4 || Vector2.Distance(freeSpaceCopyRight, this.transform.position) < 4)
                {
                   rend.material.color = Color.white;
                    isOnFree = false;
                }

                //check if Object is build on a free space
                if (isDragging == false && Vector2.Distance(freeSpace, transform.position) < 1)
                {
                    build = true;
                }

            }

        }
    }
}

