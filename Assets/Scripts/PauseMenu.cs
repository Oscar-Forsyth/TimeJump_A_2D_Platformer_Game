using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool escPressLastFrame = false;
    bool canMoveLastState = true;
    [SerializeField]
    GameObject holder;
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Update()
    {
        bool tmp = Input.GetKeyDown(KeyCode.Escape);
        if (tmp && !escPressLastFrame)
        {
            Debug.Log("Escape pressed.");
            holder.SetActive(true);
            canMoveLastState = LevelManager.instance.getCanMove();
            LevelManager.instance.setCanMove(false);
        }
        escPressLastFrame = tmp;
    }
    public void BackToGame()
    {
        LevelManager.instance.setCanMove(canMoveLastState);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
