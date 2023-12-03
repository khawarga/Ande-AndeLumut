using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyamInteraksi : MonoBehaviour
{
    [SerializeField]
    private DialogTrigger dialogTrigger;

    public bool jantan;

    private bool masuk;

    public GameObject[] ayamList;

    public GameObject player;

    private void Start()
    {
        PauseMenu temp = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenu>();

        temp.setEnemy(ayamList);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && masuk)
        {
            if (player.GetComponent<PlayerObject>().getKotoranAyam().Equals(true))
            {
                GameObject temp = GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBeres").gameObject;

                temp.SetActive(true);

                DialogTrigger temp2 = temp.GetComponent<DialogTrigger>();

                foreach (GameObject x in ayamList)
                {
                    x.GetComponent<EnemyMovement>().enabled = false;
                }

                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                temp2.dialogTrigger();
                temp2.OnDialogFinish += disableDialogtrigger;
            }
            else
            {
                if (jantan.Equals(true))
                {
                    Debug.Log("dapat tai");
                    GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamJantan").gameObject.SetActive(true);

                    foreach (GameObject x in ayamList)
                    {
                        x.GetComponent<EnemyMovement>().enabled = false;
                    }

                    player.GetComponent<PlayerMovement>().enabled = false;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                    dialogTrigger.dialogTrigger();
                    dialogTrigger.OnDialogFinish += disableDialogtrigger;

                    player.GetComponent<PlayerObject>().setKotoranAyam(true);
                }
                else
                {
                    Debug.Log("zonk");

                    GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBetina").gameObject.SetActive(true);

                    foreach (GameObject x in ayamList)
                    {
                        x.GetComponent<EnemyMovement>().enabled = false;
                    }

                    player.GetComponent<PlayerMovement>().enabled = false;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                    dialogTrigger.dialogTrigger();
                    dialogTrigger.OnDialogFinish += disableDialogtrigger;
                }
            }
        }
    }

    private void disableDialogtrigger(object sender, System.EventArgs e)
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamJantan").gameObject.SetActive(false);
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBetina").gameObject.SetActive(false);
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBeres").gameObject.SetActive(false);

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        dialogTrigger.OnDialogFinish -= disableDialogtrigger;

        foreach (GameObject x in ayamList)
        {
            x.GetComponent<EnemyMovement>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        masuk = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        masuk = false;
    }
}
