using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintu : MonoBehaviour
{
    [SerializeField] private GameObject pintu;
    [SerializeField] private string ID;
    private bool canUnclock = false;

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

        if(ID.Equals("Green"))
        {
            if (inventory.getGreenKey().Equals(true))
            {
                canUnclock = true;
            }
        }
    }
}
