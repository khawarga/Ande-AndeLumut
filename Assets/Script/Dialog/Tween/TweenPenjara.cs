using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    private async void dialog()
    {
        dialogTrigger.dialogTrigger();

        await Task.Delay(7000);

        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerObject>().enabled = true;
    }

    /*private void aktif(object sender, System.EventArgs e)
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerObject>().enabled = true;
        //dialogTrigger.OnDialogFinish -= aktif;
    }*/
}
