using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviourFuture : MonoBehaviour
{
    public GameObject box;
    public float speed;
    public Transform[] points;
    private bool goingUp = false;
    private bool goingDown = false;
   

    private float distance;
    void Start()
    {
        float wallLength = GetComponent<Collider2D>().bounds.size.y;
        float boxHeight = box.GetComponent<Collider2D>().bounds.size.y;
        distance = wallLength / 2 + boxHeight / 2;
    }
    public void go()
    {
        if (!goingDown && !goingUp)
        {
            if (Vector2.Distance(transform.position, points[2].position) < 0.02f )
            {
                //going down
                transform.position = points[1].position;
                Debug.Log(Vector2.Distance(transform.position, box.transform.position) +">"+ (distance + 0.5f));
                if (Vector2.Distance(transform.position, box.transform.position) > (distance + 0.55f))
                {
                    transform.position = points[0].position;
                }
              
            }
            else
            {
               
                
                    //going up
                    transform.position = points[2].position;
                
                
               
            }

        }
    }
   
  
}
