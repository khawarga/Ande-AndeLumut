using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    private bool aktif;

    public GameObject UI;

    public CanvasGroup dialogBox;

    public event EventHandler OnDialogFinish;

    private void Start()
    {
        //dialogBox = UI.GetComponentInChildren<CanvasGroup>();
    }

    public void dialogTrigger()
    {
        if (aktif)
        {
            if (dialog.nama.Length.Equals(0))
            {
                FindObjectOfType<DialogManager>().nextKalimatDialogOnly();
            }
            else
            {
                FindObjectOfType<DialogManager>().nextKalimat();
            }
        }
        else
        {
            aktif = true;
            UI.SetActive(true);
            LeanTween.alphaCanvas(dialogBox, 1f, 1f);
            FindObjectOfType<DialogManager>().startDialog(dialog);
        }
    }

    private void Update()
    {
        if (aktif)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (dialog.nama.Length.Equals(0))
                {
                    FindObjectOfType<DialogManager>().nextKalimatDialogOnly();
                }
                else
                {
                    FindObjectOfType<DialogManager>().nextKalimat();
                }
            }
        }
    }

    public void beres()
    {
        LeanTween.alphaCanvas(dialogBox, 0f, 1f);
        aktif = false;
        UI.SetActive(false);

        if(OnDialogFinish != null)
        {
            OnDialogFinish?.Invoke(this, EventArgs.Empty);
        }
    }
}
