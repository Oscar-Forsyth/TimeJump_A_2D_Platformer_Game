using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;
    private bool isPlayerInFuture = true;
    private bool canMove = true;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        setPlayerStatus(true); // OBS must respawn in future
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
    public void setPlayerStatus(bool status)
    {
        isPlayerInFuture = status;
        Debug.Log(status);
    }
    public bool getPlayerStatus()
    {
        return isPlayerInFuture;
    }
    public void setCanMove(bool b)
    {
        canMove = b;
    }
    public bool getCanMove()
    {
        return canMove;
    }

}
