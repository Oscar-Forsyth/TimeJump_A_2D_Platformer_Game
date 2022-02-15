using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject destinationPortal;
    private KeyCode teleportKey = KeyCode.E;
    
    public bool portNow = false;
    public bool canPort = true;
    
    private int count = 0;
    private int delay = 100;

    private void Update()
    {

        if (!canPort)
        {
            if (count > delay)
            {
                count = 0;
                canPort = true;
            }
            count++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(teleportKey) && canPort)
        {
            portNow = true;
            canPort = false;
        }
        if (collision.gameObject.tag.Equals("Player") && portNow)
        {
            Vector3 offset = transform.position - collision.gameObject.transform.position;
            destinationPortal.GetComponent<TeleportScript>().canPort = false;
            destinationPortal.GetComponent<TeleportScript>().portNow = false;
            portNow = false;
            collision.gameObject.transform.position = destinationPortal.gameObject.transform.position - offset;
        }
    }
}
