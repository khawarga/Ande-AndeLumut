using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPenjara : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    [SerializeField]
    private DialogTrigger dialogTrigger;

    private void Start()
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 0f, 2.2f).setOnComplete(dialog);
    }

    private void dialog()
    {
        dialogTrigger.dialogTrigger();
        Debug.Log("jalan");
    }
}
