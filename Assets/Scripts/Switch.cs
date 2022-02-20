using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject wall;
    public GameObject futureWall; 
    public GameObject box;
    public float speed;
    public Transform[] points;
    private bool goingUp = false;
    private bool goingDown = false;


    private float distance;

    void Start()
    {
        wall.transform.position = points[0].position;

        float wallLength = wall.GetComponent<Collider2D>().bounds.size.y;
        float boxHeight = box.GetComponent<Collider2D>().bounds.size.y;
        distance = wallLength/2 + boxHeight/2;
     
    }
    void Update()
    {
        if (!LevelManager.instance.getPlayerStatus()) //makes sure player is in past
        {
 
            //checks if box is too close,then stop moving
            if (Vector2.Distance(wall.transform.position, box.transform.position) < distance)
            {
                goingDown = false;
            }
            if (goingUp)
            {
                futureWall.transform.position = points[3].position; //moves the futurewall up
                if (Vector2.Distance(wall.transform.position, points[1].position) < 0.02f)
                {
                    goingUp = false;
                }
                wall.transform.position = Vector2.MoveTowards(wall.transform.position, points[1].position, speed * Time.deltaTime);
            }
            if (goingDown)
            {
                futureWall.transform.position = points[2].position; //moves the futurewall down
                if (Vector2.Distance(wall.transform.position, points[0].position) < 0.02f)
                {
                    goingDown = false;
                }
                wall.transform.position = Vector2.MoveTowards(wall.transform.position, points[0].position, speed * Time.deltaTime);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!goingDown && !goingUp)
        {
            
            if (Vector2.Distance(wall.transform.position, points[1].position) < 0.02f)
            {
                goingDown = true;
            }
            else
            {
                goingUp = true;
            }

        }
        
    }



}
