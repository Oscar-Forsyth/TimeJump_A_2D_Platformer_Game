using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimelineManager : MonoBehaviour
{

    [SerializeField]
    GameObject FutureCanvas;

    [SerializeField]
    GameObject PastCanvas;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FutureRoom"))
        {
            LevelManager.instance.setPlayerStatus(true);
            FutureCanvas.SetActive(true);
            PastCanvas.SetActive(false);
        }
        else if (col.gameObject.CompareTag("PastRoom"))
        {
            LevelManager.instance.setPlayerStatus(false);
            FutureCanvas.SetActive(false);
            PastCanvas.SetActive(true);
        }

    }
}
