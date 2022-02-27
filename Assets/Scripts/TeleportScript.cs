using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject destinationPortal;
    private KeyCode teleportKey = KeyCode.C;
    
    public bool portNow = false;
    public bool inRange = false;
    
    private GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(teleportKey))
        {
            portNow = true;
        }
        if (Input.GetKeyUp(teleportKey))
        {
            portNow = false;
        }

        if (portNow)
        {
            if (inRange)
            {
                portNow = false;
                Vector3 offset = transform.position - player.transform.position;
                destinationPortal.GetComponent<TeleportScript>().portNow = false;
                player.transform.position = destinationPortal.gameObject.transform.position - offset;
            }
            else
            {
                portNow = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player = collision.gameObject;
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            inRange = false;
        }
    }
}
