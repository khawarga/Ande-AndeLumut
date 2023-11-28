using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jendela : MonoBehaviour
{
    private bool open;

    public CanvasGroup FadeInFadeOut;

    [SerializeField]
    private DialogTrigger benar;

    [SerializeField]
    private DialogTrigger salah;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            checkItem(collision.gameObject);
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            player = null;
        }
    }

    private void checkItem(GameObject player)
    {
        PlayerObject playerObject = player.GetComponent<PlayerObject>();

        if (playerObject.getRope() == true && playerObject.getPenPaper() == true)
        {
            open = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(player != null)
            {
                if (open)
                {
                    GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerJendelaBener").gameObject.SetActive(true);
                    player.GetComponent<PlayerMovement>().enabled = false;
                    benar.OnDialogFinish += jendela;
                    benar.dialogTrigger();
                }
                else
                {
                    GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerJendelaSalah").gameObject.SetActive(true);
                    player.GetComponent<PlayerMovement>().enabled = false;
                    salah.OnDialogFinish += jendela;
                    salah.dialogTrigger();
                }
            }
        }
    }

    private void jendela(object sender, System.EventArgs e)
    {
        if (open)
        {
            Debug.Log("benar");
            LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2.2f).setOnComplete(changeScene);
        }
        else if (!open)
        {
            Debug.Log("salah");
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        benar.OnDialogFinish -= jendela;
    }

    private void changeScene()
    {
        GameObject.Find("BGM").GetComponent<BGM>().setBGM("BGMVN");

        SceneManager.LoadScene("VisualNovel2-DiluarPenjara");
    }
}
