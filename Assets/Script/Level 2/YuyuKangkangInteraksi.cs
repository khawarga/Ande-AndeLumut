using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YuyuKangkangInteraksi : MonoBehaviour
{
    private GameObject player;

    public CanvasGroup FadeInFadeOut;

    GameObject handholding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        handholding = GameObject.Find("DialogCanvas").transform.Find("Handholding").gameObject;

        handholding.SetActive(true);

        player = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        handholding.SetActive(false);
        player = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player == null) return;
            if (player.GetComponent<PlayerObject>().getKotoranAyam().Equals(true))
            {
                GameObject temp = GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogYuyuKangkangBener").gameObject;

                temp.SetActive(true);

                DialogTrigger temp2 = temp.GetComponent<DialogTrigger>();

                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                temp2.dialogTrigger();
                temp2.OnDialogFinish += nextScene;
            }
            else if(player.GetComponent<PlayerObject>().getKotoranAyam().Equals(false))
            {
                GameObject temp = GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogYuyuKangkangSalah").gameObject;

                temp.SetActive(true);

                DialogTrigger temp2 = temp.GetComponent<DialogTrigger>();

                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                temp2.dialogTrigger();
                temp2.OnDialogFinish += disableDialogtrigger;
            }
        }
    }

    private void disableDialogtrigger(object sender, System.EventArgs e)
    {
        GameObject temp = GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogYuyuKangkangSalah").gameObject;

        temp.SetActive(false);

        DialogTrigger temp2 = temp.GetComponent<DialogTrigger>();

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        temp2.OnDialogFinish -= disableDialogtrigger;
    }

    private void nextScene(object sender, System.EventArgs e)
    {
        GameObject temp = GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogYuyuKangkangBener").gameObject;

        temp.SetActive(false);

        DialogTrigger temp2 = temp.GetComponent<DialogTrigger>();

        LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2.2f).setOnComplete(changeScene);
    }

    private void changeScene()
    {
        GameObject.Find("BGM").GetComponent<BGM>().setBGM("BGMMainMenu");

        SceneManager.LoadScene("VisualNovel6-DisebrangSungai");
    }
}
