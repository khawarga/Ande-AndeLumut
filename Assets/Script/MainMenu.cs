using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MainMenu : MonoBehaviour
{
    //public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    [SerializeField] private GameObject pengaturan;

    [SerializeField]
    private CanvasGroup Blur;

    [SerializeField]
    private Image feedbackCantSave;

    public AudioClip[] demung;

    private AudioSource audioS;

    [SerializeField]
    private GameObject tutorial;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        if(PlayerPrefs.GetString("scene") == null)
        {
            PlayerPrefs.SetString("scene", "");
        }
        LeanTween.alphaCanvas(Blur, 0f, 2.2f).setOnComplete(enableMainMenu);

        /*resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        options.Add("1920 x 1080");
        options.Add("1600 x 900");
        options.Add("1280 x 720");
        resolutionDropdown.AddOptions(options);

        /* int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        */
    }

    public async void melanjutkan()
    {
        audioS.PlayOneShot(demung[1]);
        Debug.Log("Click");
        if (PlayerPrefs.GetString("scene") == "")
        {
            LeanTween.alphaCanvas(Blur, 1f, 2.2f);

            await Task.Delay(2300);

            LeanTween.moveLocalY(feedbackCantSave.gameObject, 0, 1f).setEase(LeanTweenType.easeSpring);
            await Task.Delay(2000);

            LeanTween.moveLocalY(feedbackCantSave.gameObject, -980, 1f).setEase(LeanTweenType.easeSpring);
            await Task.Delay(1100);
            LeanTween.alphaCanvas(Blur, 0f, 2.2f);
            return;
        }
        
        
        LeanTween.alphaCanvas(Blur, 1f, 2.2f);
        await Task.Delay(2300);
        SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
    }

    private void enableMainMenu()
    {
        GameObject.Find("Canvas").GetComponent<Transform>().Find("MainMenu").gameObject.SetActive(true);
    }


    public async void StartGame()
    {
        audioS.PlayOneShot(demung[2]);
        LeanTween.alphaCanvas(Blur, 1f, 2.2f);

        await Task.Delay(2300);

        LeanTween.moveLocalY(tutorial, 0, 1f).setEase(LeanTweenType.easeSpring);
    }

    public async void goToGame()
    {
        LeanTween.moveLocalY(tutorial, 1500f, 1f);

        await Task.Delay(1100);

        SceneManager.LoadScene("VisualNovel1-Prolog");
    }

    public async void goToPengaturan()
    {
        pengaturan.SetActive(true);
        audioS.PlayOneShot(demung[1]);
    }


    public async void ExitGame()
    {
        audioS.PlayOneShot(demung[0]);
        LeanTween.alphaCanvas(Blur, 1f, 2.2f);

        await Task.Delay(2500);

        Application.Quit();
    }

    /*public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
            Debug.Log("1920 x 1080");
        }
        if (val == 1)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
            Debug.Log("1600 x 900");
        }
        if (val == 2)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
            Debug.Log("1280 x 720");
        }
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }*/
}
