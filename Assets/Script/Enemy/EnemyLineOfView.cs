using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfView : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GetComponentInParent<EnemyMovement>().enabled = false;
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Debug.Log("jalan");
        }
    }
}
