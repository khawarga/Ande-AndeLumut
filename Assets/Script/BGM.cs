using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    public static BGM Instance;

    public Slider setVolume;

    private AudioSource source;

    private void Awake()
    {
        // initialize singleton
        if (Instance == null) Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(setVolume != null)
        {
            source.volume = setVolume.value;
        }
        else if (setVolume == null)
        {
           setVolume = FindObjectOfType<Slider>();
        }
    }

    public void setBGM(string newBGM)
    {
        source.clip = Resources.Load<AudioClip>(newBGM);
        source.enabled = false;
        source.enabled = true;
    }
}
