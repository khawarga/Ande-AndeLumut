using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    [SerializeField]
    private CanvasGroup blur;

    [SerializeField]
    private GameObject pauseMenu;

    private GameObject[] enemylist;

    private bool pauseState;

    private void Awake()
    {
        // initialize singleton
        if (instance == null) instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().Equals("Main Menu")) return;

            if (pauseState)
            {
                resume();
            }
            else if (!pauseState)
            {
                pause();
            }
        }
    }

    private async void pause()
    {
        pauseState = true;

        if (SceneManager.GetActiveScene().Equals("Level1-Penjara"))
        {
            foreach (GameObject x in enemylist)
            {
                x.GetComponent<EnemyMovement>().enabled = false;
            }
        }

        LeanTween.alphaCanvas(blur, 0.7f, 2f);

        await Task.Delay(2000);

        LeanTween.moveLocalY(pauseMenu, 0f, 1f);
    }

    public async void resume()
    {
        pauseState = false;

        if (SceneManager.GetActiveScene().Equals("Level1-Penjara"))
        {
            foreach (GameObject x in enemylist)
            {
                x.GetComponent<EnemyMovement>().enabled = true;
            }
        }
        LeanTween.moveLocalY(pauseMenu, -2000f, 1f);

        await Task.Delay(1000);

        LeanTween.alphaCanvas(blur, 0f, 2f);
    }

    public async void restart()
    {
        LeanTween.alphaCanvas(blur, 1f, 2f);

        await Task.Delay(2000);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        LeanTween.alphaCanvas(blur, 0f, 2f);
    }

    public async void backToMainMenu()
    {
        LeanTween.moveLocalY(pauseMenu, -2000f, 1f);
        LeanTween.alphaCanvas(blur, 1f, 2f);

        await Task.Delay(2000);

        SceneManager.LoadScene("Main Menu");

        LeanTween.alphaCanvas(blur, 0f, 2f);
    }

    public void setEnemy(GameObject[] enemy)
    {
        enemylist = enemy;
    }
}