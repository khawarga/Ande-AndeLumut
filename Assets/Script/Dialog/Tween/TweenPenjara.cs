using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;

public class TweenPenjara : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    private DialogTrigger dialogTrigger;

    private void Awake()
    {
        dialogTrigger = GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerMulai").GetComponent<DialogTrigger>();
        dialogTrigger.OnDialogFinish += aktif;
    }

    private void Start()
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 0f, 2.2f).setOnComplete(dialog);
    }

    private void dialog()
    {
        dialogTrigger.dialogTrigger();
    }

    private void aktif(object sender, System.EventArgs e)
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerMulai").gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerObject>().enabled = true;
        dialogTrigger.OnDialogFinish -= aktif;
    }
}
