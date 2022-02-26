using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{

    
    public GameObject box;
    public float speed;
    public Transform[] points;
    private bool goingUp = false;
    private bool goingDown = false;
    private bool isMoving = false;

    public WallBehaviourFuture wallBehaviourFuture;


    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Box")
        {
            goingDown = false;
            isMoving = false;

        }
       
    }
 
    void Start()
    {
        
    }
   
    public void go()
    {
        if (!isMoving)
        {
            wallBehaviourFuture.go();
        }
       
        if (!goingDown && !goingUp)
        {
            if (Vector2.Distance(transform.position, points[1].position) < 0.02f)
            {
                isMoving = true;
                goingDown = true;
            }
            else
            {
                isMoving = true;
                goingUp = true;
            }

        }
    }
   
    void Update()
    {
  
        if (!LevelManager.instance.getPlayerStatus()) 
        {


            if (goingUp)
            { 
                transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, points[1].position) < 0.02f)
                {
                    goingUp = false;
                    isMoving = false;
                }
            }


            if (goingDown)
            {
               
                transform.position = Vector2.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, points[0].position) < 0.02f)
                {
                    goingDown = false;
                    isMoving = false;
                }
            }
        }
    }
}
