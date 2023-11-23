using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;

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


    public void StartGame()
    {
       SceneManager.LoadScene("VisualNovel1-Prolog");
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetResolution(int resolutionIndex)
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
    }
}
