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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && masuk)
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

                dialogTrigger.dialogTrigger();
                dialogTrigger.OnDialogFinish += disableDialogtrigger;
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

    private void disableDialogtrigger(object sender, System.EventArgs e)
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamJantan").gameObject.SetActive(false);
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBetina").gameObject.SetActive(false);

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

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
