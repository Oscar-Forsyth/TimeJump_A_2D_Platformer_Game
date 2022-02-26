using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool escPressLastFrame = false;
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
        }
        escPressLastFrame = tmp;
    }
}
