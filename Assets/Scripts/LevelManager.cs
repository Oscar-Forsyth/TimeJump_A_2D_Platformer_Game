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
        //Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        playerPrefab.transform.position = respawnPoint.position;
    }
    public void setPlayerStatus(bool status)
    {
        isPlayerInFuture = status;
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
    public Vector3 getPlayerPosition()
    {
        return playerPrefab.transform.position;
    }

}
