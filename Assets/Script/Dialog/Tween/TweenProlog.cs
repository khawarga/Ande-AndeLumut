using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenProlog : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    private DialogTrigger dialogTrigger;

    private void Awake()
    {
        dialogTrigger = FindObjectOfType<DialogTrigger>();
        dialogTrigger.OnDialogFinish += changeScene;
    }

    private void Start()
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 0f, 2.2f).setOnComplete(dialog);
    }

    private void dialog()
    {
        dialogTrigger.dialogTrigger();
    }

    private void changeScene(object sender, System.EventArgs e)
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2.2f).setOnComplete(pindah);
    }

    private void pindah()
    {
        GameObject.Find("BGM").GetComponent<BGM>().setBGM("BGMLevel1");

        SceneManager.LoadScene("Level1-Penjara");
    }
}
