using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
       SceneManager.LoadScene("VisualNovel1-Prolog");
    }

    public void Setting()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
