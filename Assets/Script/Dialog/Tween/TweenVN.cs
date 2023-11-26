using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenVN : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    private DialogTrigger dialogTrigger;

    public string NextScene;

    public GameObject potraitMove;

    private int move;

    public int max;

    public float x;

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (potraitMove == null) return;

            move++;

            if (move == max)
            {
                LeanTween.moveLocalX(potraitMove, x, 1f);
            }
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
        SceneManager.LoadScene(NextScene);
    }
}
