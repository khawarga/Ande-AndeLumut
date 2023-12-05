using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenSungai : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    private DialogTrigger dialogTrigger;

    private int move;

    public GameObject YuyuKangkang;

    private void Awake()
    {
        dialogTrigger = GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogMulai").GetComponent<DialogTrigger>();
        dialogTrigger.OnDialogFinish += aktif;
    }

    private void FixedUpdate()
    {
        if (move == 2)
        {
            LeanTween.moveLocalX(YuyuKangkang, -691, 1f);
            move++;
        }
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
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogMulai").gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerObject>().enabled = true;
        dialogTrigger.OnDialogFinish -= aktif;
    }

    public void setMove()
    {
        move++;
        Debug.Log(move);
    }
}
