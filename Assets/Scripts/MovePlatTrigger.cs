using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatTrigger : MonoBehaviour
{
    public GameObject platform;
    private bool on = false;

    public float speed;
    public int startingPoint;
    public Transform[] points;
   

    private int i;

    void Start()
    {  
            platform.transform.position = points[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.instance.getPlayerStatus()) //makes sure player is in past
        {
            if (on)
            {

                platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[0].position, speed  * Time.deltaTime);
            }
            else
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[1].position, speed * Time.deltaTime);
            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        on = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        on = false;

    }
   
}
