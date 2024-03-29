using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyLineOfView : MonoBehaviour
{
    [SerializeField]
    private DialogTrigger dialogTrigger;

    [SerializeField]
    private TweenEnemy tweenEnemy;

    private GameObject[] enemylist;

    private void Start()
    {
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");

        PauseMenu temp = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenu>();

        temp.setEnemy(enemylist);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("DialogManager").GetComponent<Transform>().Find("DialogTriggerEnemy").gameObject.SetActive(true);
        if (collision.gameObject.tag.Equals("Player"))
        {
            foreach(GameObject x in enemylist)
            {
                x.GetComponent<EnemyMovement>().enabled = false;
            }
            //GetComponentInParent<EnemyMovement>().enabled = false;
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            dialogTrigger.dialogTrigger();
            tweenEnemy.addListener();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject x in enemylist)
        {
            x.GetComponent<EnemyMovement>().enabled = true;
        }
        collision.gameObject.GetComponent<PlayerMovement>().enabled = true;
        collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
