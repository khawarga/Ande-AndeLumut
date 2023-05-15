using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenEnemy : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    [SerializeField]
    private Transform startingPoint;

    private DialogTrigger dialogTrigger;

    private void Awake()
    {
        dialogTrigger = FindObjectOfType<DialogTrigger>();
        dialogTrigger.OnDialogFinish += ketangkap;
    }

    private void ketangkap(object sender, System.EventArgs e)
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2f).setOnComplete(pindah);
    }

    private void pindah()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().pindah(startingPoint);
        LeanTween.alphaCanvas(FadeInFadeOut, 0f, 2f);
    }
}
