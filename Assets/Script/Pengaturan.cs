using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pengaturan : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] GameObject mainmenuObject, pauseObject;
    Resolution[] resolutions;


    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        options.Add("1920 x 1080");
        options.Add("1600 x 900");
        options.Add("1280 x 720");
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
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


    public void Back()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Main Menu")
        {
            mainmenuObject.SetActive(true);
        }
        else
        {
            pauseObject.SetActive(true);
        }
    }
}
