using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndBuild : MonoBehaviour
{

    private bool isDragging;
    private bool build = false;
    private bool isOnFree = false;
    Renderer rend;

    //Arrays for all the freeSpaces
    public GameObject[] fSpaces;
    public GameObject freeObject;

    //Used to destroy 
    private bool yeetThatBitch = false;

    //Variables for Free Spaces
    private Vector2 freeSpace;
    private Vector2 thisFreeSpace;

    //Variabels for Edges of Free Spaces
    private Vector2 freeSpaceCopyTop;
    private Vector2 freeSpaceCopyLeft;
    private Vector2 freeSpaceCopyRight;

    // Used for Copyying
    public GameObject sPrefab;
    public GameObject sPrefabeClone;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        fSpaces = GameObject.FindGameObjectsWithTag("FreeSpace");
        sPrefab = GameObject.Find("SquarePrefab");
    }

    // Sets draggin to true and makes a copy of gameObject
    void OnMouseDown()
    {
        isDragging = true;
        if (build == false)
        {
            sPrefab = GameObject.Find("SquarePrefab");
            GameObject newGO = GameObject.Instantiate(sPrefab, transform.position, transform.rotation) as GameObject;
            newGO.name = "SquarePrefab";
        }
    }

    // Sets draggin to false and yeetThatBitch to true
    void OnMouseUp()
    {
        isDragging = false;
        yeetThatBitch = true;
    }

    // Update is called once per frame
    // Checks if Object is on a freeSpace or not
    void Update()
    {
        for (int i = 0; i < fSpaces.Length; i++)
        {
            freeSpace = fSpaces[i].transform.position;
            freeObject = fSpaces[i];

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


            if (build == false && fSpaces[i].tag != "usedSpace")
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
                    rend.material.color = Color.green;
                    thisFreeSpace = fSpaces[i].transform.position;
                    isOnFree = true;
                    Debug.Log(freeObject);
                }

                //check if Objekt is not on a freespace when mouse stops being clicked
                else if (isDragging == false && Vector2.Distance(freeSpace, transform.position) > 1 && isOnFree == false)
                {
                    //Destroys Object if it is not on a free Space
                    if (yeetThatBitch)
                    {
                        Destroy(gameObject);
                    }
                }

                //Check if Object is not on a free Space and change color to white
                else if (isDragging == true && Vector2.Distance(thisFreeSpace, transform.position) < 4 || Vector2.Distance(freeSpaceCopyTop, this.transform.position) < 4 || Vector2.Distance(freeSpaceCopyLeft, this.transform.position) < 4 || Vector2.Distance(freeSpaceCopyRight, this.transform.position) < 4)
                {
                    rend.material.color = Color.white;
                    isOnFree = false;
                }

                //check if Object is build on a free space
                if (isDragging == false && Vector2.Distance(freeSpace, this.transform.position) < 6 && Vector2.Distance(freeSpaceCopyTop, this.transform.position) < 6)
                {
                    build = true;
                    freeObject.tag = "usedSpace";
                    
                }

            }

        }
        //changes name if it is build
        if (build)
        {
            transform.gameObject.name = "buildWood";
            gameObject.layer = freeObject.layer;

            rend = GetComponent<SpriteRenderer>();
            rend.sortingLayerName = "Background4";
        }
    }
}