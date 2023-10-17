using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jendela : MonoBehaviour
{
    private bool open;

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
                    player.GetComponent<PlayerMovement>().enabled = false;
                    benar.dialogTrigger();
                }
                else
                {
                    player.GetComponent<PlayerMovement>().enabled = false;
                    salah.dialogTrigger();
                    player.GetComponent<PlayerMovement>().enabled = true;
                }
            }
        }
    }
}
