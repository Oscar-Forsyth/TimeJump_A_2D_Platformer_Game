using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimelineManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FutureRoom"))
        {
            LevelManager.instance.setPlayerStatus(true);
        }
        else if (col.gameObject.CompareTag("PastRoom"))
        {
            LevelManager.instance.setPlayerStatus(false);
        }

    }
}
