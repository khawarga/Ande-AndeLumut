using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints1;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject sprite;
    [SerializeField] private Animator anim;

    private int waypointIndex = 0;
    private int tanda = 0;
    private int waypointIndexTemp;
    [SerializeField]private bool loop;

    // Update is called once per frame
    void Update()
    {
        if (tanda == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints1[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (gameObject.transform.position.x == waypoints1[waypointIndex].transform.position.x && gameObject.transform.position.y == waypoints1[waypointIndex].transform.position.y)
            {
                if (waypointIndex != waypoints1.Length - 1)
                {
                    waypointIndex++;
                    ubahArah(waypointIndex - 1, waypointIndex);
                }
                else
                {
                    if(loop == true)
                    {
                        waypointIndex = 0;
                        ubahArah(waypoints1.Length-1, waypointIndex);
                    }
                    else
                    {
                        tanda = 1;
                        waypointIndex--;
                        ubahArah(waypointIndex + 1, waypointIndex);
                    }
                }
            }
        }
        else if(tanda == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints1[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            if (gameObject.transform.position.x == waypoints1[waypointIndex].transform.position.x && gameObject.transform.position.y == waypoints1[waypointIndex].transform.position.y)
            {
                if (waypointIndex != 0)
                {
                    waypointIndex--;
                    ubahArah(waypointIndex + 1, waypointIndex);
                }
                else
                {
                    tanda = 0;
                    waypointIndex++;
                    ubahArah(waypointIndex - 1, waypointIndex);
                }
            }
        }
    }

    private void ubahArah(int index1, int index2)
    {
        anim.SetFloat("Speed", 1);
        if (waypoints1[index1].transform.position.y > waypoints1[index2].transform.position.y)//bawah
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            sprite.transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetFloat("Vertical", -1);
            anim.SetFloat("Horizontal", 0);
            return;
        }
        else if(waypoints1[index1].transform.position.y < waypoints1[index2].transform.position.y)//atas
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            sprite.transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetFloat("Vertical", 1);
            anim.SetFloat("Horizontal", 0);
            return;
        }
        else if (waypoints1[index1].transform.position.x > waypoints1[index2].transform.position.x)//kiri
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            sprite.transform.eulerAngles = new Vector3(180, 0, 180);
            anim.SetFloat("Horizontal", 1);
            anim.SetFloat("Vertical", 0);
            return;
        }
        else if (waypoints1[index1].transform.position.x < waypoints1[index2].transform.position.x)//kanan
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            sprite.transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetFloat("Horizontal", -1);
            anim.SetFloat("Vertical", 0);
            return;
        }
    }
}
