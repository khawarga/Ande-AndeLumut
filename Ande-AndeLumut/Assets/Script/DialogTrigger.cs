using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    private bool aktif;

    public GameObject UI;

    public void dialogTrigger()
    {
        if (aktif)
        {
            FindObjectOfType<DialogManager>().nextKalimat();
        }
        else
        {
            aktif = true;
            UI.SetActive(true);
            FindObjectOfType<DialogManager>().startDialog(dialog);
        }
    }

    private void FixedUpdate()
    {
        if (aktif)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                FindObjectOfType<DialogManager>().nextKalimat();
            }
        }
    }

    public void beres()
    {
        aktif = false;
        UI.SetActive(false);
    }
}
