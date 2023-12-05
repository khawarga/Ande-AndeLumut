using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintu : MonoBehaviour
{
    [SerializeField] private GameObject pintu;
    [SerializeField] private string ID;
    private bool canUnclock = false;
    GameObject handholding;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canUnclock)
        {
            pintu.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerObject inventory = collision.GetComponent<PlayerObject>();

        handholding = GameObject.Find("Canvas").transform.Find("Handholding").gameObject;

        handholding.SetActive(true);

        switch (ID)
        {
            case "Green":
                if (inventory.getGreenKey().Equals(true))
                {
                    canUnclock = true;
                }
                break;
            case "Yellow":
                if (inventory.getYellowKey().Equals(true))
                {
                    canUnclock = true;
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        handholding.SetActive(false);
    }
}
