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
    
    [SerializeField]
    private GameObject settingMenu;

    private GameObject[] enemylist;

    private bool pauseState = false;

    private void Awake()
    {
        // initialize singleton
        if (instance == null) instance = this;

        DontDestroyOnLoad(this.gameObject);

        settingMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Kepencet");
            if (SceneManager.GetActiveScene().Equals("Main Menu")) return;

            pauseMenu.SetActive(true);

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

        blur.blocksRaycasts = true;

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level1-Penjara")
        {
            foreach (GameObject x in enemylist)
            {
                x.GetComponent<EnemyMovement>().enabled = false;
            }
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }
        if (scene.name == "Level2-TepiSungai")
        {
            //ayam
            foreach (GameObject x in enemylist)
            {
                x.GetComponent<EnemyMovement>().enabled = false;
            }
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }

        LeanTween.alphaCanvas(blur, 0.7f, 0.5f);

        await Task.Delay(500);

        LeanTween.moveLocalY(pauseMenu, 0f, 0.5f);
    }

    public async void resume()
    {
        pauseState = false;

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level1-Penjara")
        {
            foreach (GameObject x in enemylist)
            {
                x.GetComponent<EnemyMovement>().enabled = true;
            }
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        }
        if (scene.name == "Level2-TepiSungai")
        {
            foreach (GameObject x in enemylist)
            {
                x.GetComponent<EnemyMovement>().enabled = true;
            }
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        }

        LeanTween.moveLocalY(pauseMenu, -2000f, 0.5f);

        await Task.Delay(500);

        LeanTween.alphaCanvas(blur, 0f, 0.5f);
        blur.blocksRaycasts = false;
        pauseMenu.SetActive(false);
    }

    public async void restart()
    {
        Debug.Log("press res");
        LeanTween.moveLocalY(pauseMenu, -2000f, 0.5f);
        LeanTween.alphaCanvas(blur, 1f, 0.5f);

        await Task.Delay(500);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        LeanTween.alphaCanvas(blur, 0f, 0.5f);

        blur.blocksRaycasts = false;
        pauseState = false;
        pauseMenu.SetActive(false);
    }

    public async void backToMainMenu()
    {
        Debug.Log("press back");
        LeanTween.moveLocalY(pauseMenu, -2000f, 0.5f);
        LeanTween.alphaCanvas(blur, 1f, 0.5f);

        await Task.Delay(2000);

        SceneManager.LoadScene("Main Menu");

        LeanTween.alphaCanvas(blur, 0f, 0.5f);
        blur.blocksRaycasts = false;
        pauseState = false;
        pauseMenu.SetActive(false);
    }

    public void SettingGame()
    {
        settingMenu.SetActive(true);
    }

    public void setEnemy(GameObject[] enemy)
    {
        enemylist = enemy;
    }

    public bool getPauseState()
    {
        return pauseState;
    }
}
