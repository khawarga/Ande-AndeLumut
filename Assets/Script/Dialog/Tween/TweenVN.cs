using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class TweenVN : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    private DialogTrigger dialogTrigger;

    public string NextScene;

    public GameObject potraitMove;

    private int move;

    public int max;

    public float x;

    public bool toLevel2;

    private void Awake()
    {
        dialogTrigger = FindObjectOfType<DialogTrigger>();
        dialogTrigger.OnDialogFinish += changeScene;
    }

    private void Start()
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 0f, 2.2f).setOnComplete(dialog);
    }

    private void Update()
    {
        if (potraitMove == null) return;

        if (move == max)
        {
            LeanTween.moveLocalX(potraitMove, x, 1f);
            move++;
        }
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
        if (toLevel2)
        {
            GameObject.Find("BGM").GetComponent<BGM>().setBGM("BGMLevel2");
        }

        SceneManager.LoadScene(NextScene);
    }

    public void setMove()
    {
        move++;
    }
}
