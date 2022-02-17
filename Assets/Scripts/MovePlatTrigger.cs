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
    ArrayList numberCheck = new ArrayList();

    private int i;

    void Start()
    {  
            platform.transform.position = points[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            /*
            if (Vector2.Distance(platform.transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length)
                {
                    i = 0;
                }
            }
            */
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[0].position, speed * Time.deltaTime);
        }
        else
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[1].position, speed * Time.deltaTime);
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
