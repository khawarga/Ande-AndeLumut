using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyamInteraksi : MonoBehaviour
{
    [SerializeField]
    private DialogTrigger dialogTriggerJantan;

    [SerializeField]
    private DialogTrigger dialogTriggerBetina;

    public bool jantan;

    private bool masuk;

    public GameObject[] ayamList;

    public GameObject player;

    public Transform location;

    public Transform parent;

    public GameObject kotoranAyam;

    public GameObject telurAyam;

    GameObject handholding;

    public AudioSource audioSource;

    public AudioClip clip;

    private void Start()
    {
        PauseMenu temp = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenu>();

        temp.setEnemy(ayamList);

        handholding = GameObject.Find("DialogCanvas").transform.Find("Handholding").gameObject;
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

                    audioSource.PlayOneShot(clip);
                    //Debug.Log("dapat tai");
                    /*GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamJantan").gameObject.SetActive(true);

                    foreach (GameObject x in ayamList)
                    {
                        x.GetComponent<EnemyMovement>().enabled = false;
                    }

                    player.GetComponent<PlayerMovement>().enabled = false;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                    dialogTrigger.dialogTrigger();
                    dialogTrigger.OnDialogFinish += disableDialogtrigger;

                    player.GetComponent<PlayerObject>().setKotoranAyam(true);*/

                    GameObject drop = Instantiate(kotoranAyam, location);
                    drop.transform.SetParent(parent);

                    drop.GetComponent<Drop>().kotoranAyam = true;
                    drop.GetComponent<Drop>().player = player.GetComponent<PlayerObject>();
                    drop.GetComponent<Drop>().ayam = gameObject.GetComponent<AyamInteraksi>();
                }
                else
                {
                    audioSource.PlayOneShot(clip);
                    //Debug.Log("zonk");

                    /*GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBetina").gameObject.SetActive(true);

                    foreach (GameObject x in ayamList)
                    {
                        x.GetComponent<EnemyMovement>().enabled = false;
                    }

                    player.GetComponent<PlayerMovement>().enabled = false;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                    dialogTrigger.dialogTrigger();
                    dialogTrigger.OnDialogFinish += disableDialogtrigger;*/

                    int rng = Random.Range(0, 2);
                    GameObject drop;
                    Debug.Log("RNG : " + rng);
                    if (rng == 0)
                    {
                        drop = Instantiate(telurAyam, location);
                        drop.transform.SetParent(parent);
                        drop.GetComponent<Drop>().kotoranAyam = false;
                    }
                    else
                    {
                        drop = Instantiate(kotoranAyam, location);
                        drop.transform.SetParent(parent);
                        drop.GetComponent<Drop>().kotoranAyam = true;
                    }

                    drop.GetComponent<Drop>().player = player.GetComponent<PlayerObject>();
                    drop.GetComponent<Drop>().ayam = gameObject.GetComponent<AyamInteraksi>();
                }
            }
        }
    }

    public void getKotoranAyam()
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamJantan").gameObject.SetActive(true);

        foreach (GameObject x in ayamList)
        {
            x.GetComponent<EnemyMovement>().enabled = false;
        }

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        dialogTriggerJantan.dialogTrigger();
        dialogTriggerJantan.OnDialogFinish += disableDialogtrigger;

        player.GetComponent<PlayerObject>().setKotoranAyam(true);
    }

    public void getTelurAyam()
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBetina").gameObject.SetActive(true);

        foreach (GameObject x in ayamList)
        {
            x.GetComponent<EnemyMovement>().enabled = false;
        }

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        dialogTriggerBetina.dialogTrigger();
        dialogTriggerBetina.OnDialogFinish += disableDialogtrigger;
    }

    private void disableDialogtrigger(object sender, System.EventArgs e)
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamJantan").gameObject.SetActive(false);
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBetina").gameObject.SetActive(false);
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerAyamBeres").gameObject.SetActive(false);

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        dialogTriggerBetina.OnDialogFinish -= disableDialogtrigger;
        dialogTriggerJantan.OnDialogFinish -= disableDialogtrigger;

        foreach (GameObject x in ayamList)
        {
            x.GetComponent<EnemyMovement>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        handholding.SetActive(true);
        masuk = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        handholding.SetActive(false);
        masuk = false;
    }
}
