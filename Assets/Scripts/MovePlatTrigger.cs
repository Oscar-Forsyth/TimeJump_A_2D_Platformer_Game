using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatTrigger : MonoBehaviour
{
    public GameObject platform;
    public float speed;
    public Transform[] points;
    private int count = 0;


    void Start()
    {  
            platform.transform.position = points[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.instance.getPlayerStatus() ) 
        {
            if(count == 0)
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[1].position, speed * Time.deltaTime);
            }
            else
            {
                platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[0].position, speed * Time.deltaTime);
            }
            
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        count++;
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        count--;
        
    }
    

  
   
}
