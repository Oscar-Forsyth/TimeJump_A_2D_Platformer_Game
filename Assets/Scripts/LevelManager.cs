using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;
    private bool isPlayerInFuture = true;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
    public void setPlayerStatus(bool status)
    {
        isPlayerInFuture = status;
    }
    public bool getPlayerStatus()
    {
        return isPlayerInFuture;
    }

}
