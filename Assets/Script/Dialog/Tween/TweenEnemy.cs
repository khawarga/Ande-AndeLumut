using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenEnemy : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    [SerializeField]
    private Transform startingPoint;

    [SerializeField]
    private DialogTrigger dialogTrigger;

    private void ketangkap(object sender, System.EventArgs e)
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2f).setOnComplete(pindah);
    }

    public void addListener()
    {
        dialogTrigger.OnDialogFinish += ketangkap;
    }

    private void pindah()
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerEnemy").gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().pindah(startingPoint);
        LeanTween.alphaCanvas(FadeInFadeOut, 0f, 2f);
        dialogTrigger.OnDialogFinish -= ketangkap;
    }
}
