using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenEpilog : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    private DialogTrigger dialogTrigger;

    [SerializeField]
    private GameObject Text;
    [SerializeField]
    private GameObject Button;

    private void Awake()
    {
        dialogTrigger = FindObjectOfType<DialogTrigger>();
        dialogTrigger.OnDialogFinish += Ending;
    }

    private void Start()
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 0f, 2.2f).setOnComplete(dialog);
    }

    private void dialog()
    {
        dialogTrigger.dialogTrigger();
    }

    private void Ending(object sender, System.EventArgs e)
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2.2f).setOnComplete(Ending2);
    }

    private async void Ending2()
    {
        LeanTween.moveLocalX(Text, 0, 1f).setEase(LeanTweenType.easeInOutBounce);

        await Task.Delay(1100);

        LeanTween.moveLocalX(Button, 0, 1f).setEase(LeanTweenType.easeInOutBounce);
    }

    public async void backToMainMenu()
    {
        LeanTween.moveLocalY(Text, -899, 1f).setEase(LeanTweenType.easeInElastic);

        LeanTween.moveLocalY(Button, -899, 1f).setEase(LeanTweenType.easeInElastic);
        
        await Task.Delay(1100);

        GameObject.Find("BGM").GetComponent<BGM>().setBGM("BGMMainMenu");

        SceneManager.LoadScene(0);
    }
}
