using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyamInteraksi : MonoBehaviour
{
    public bool jantan;

    private bool masuk;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && masuk)
        {
            if (jantan.Equals(true))
            {
                Debug.Log("dapat tai");
            }
            else
            {
                Debug.Log("zonk");
            }
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
