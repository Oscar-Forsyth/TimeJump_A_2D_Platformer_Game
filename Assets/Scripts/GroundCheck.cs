using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") == true || collision.gameObject.tag.Equals("Box") == true || collision.gameObject.tag.Equals("FutureBox") == true)
        {
            player.GetComponent<PlayerMovement>().touchedGround();
        }
    }
}
