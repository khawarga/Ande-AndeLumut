using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObject : MonoBehaviour
{
    public bool greenKey = false;
    public bool yellowKey = false;
    public bool rope = false;
    public bool penPaper = false;
    public bool ayam = false;
    public bool kotoranAyam = false;
    public Text objective;
    public GameObject UI;
    private AudioSource pickUp;
    public AudioClip pickUpSound;

    private void Start()
    {
        pickUp = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ayam) return;

        if (collision.gameObject.tag.Equals("GreenKey"))
        {
            greenKey = true;
            collision.gameObject.SetActive(false);
            pickUp.PlayOneShot(pickUpSound);
        }
        else if (collision.gameObject.tag.Equals("YellowKey"))
        {
            yellowKey = true;
            collision.gameObject.SetActive(false);
            pickUp.PlayOneShot(pickUpSound);
        }
        else if (collision.gameObject.tag.Equals("Rope"))
        {
            rope = true;
            collision.gameObject.SetActive(false);
            pickUp.PlayOneShot(pickUpSound);
        }
        else if (collision.gameObject.tag.Equals("PenPaper"))
        {
            penPaper = true;
            collision.gameObject.SetActive(false);
            pickUp.PlayOneShot(pickUpSound);
        }
        updateUI();
    }

    private void OnEnable()
    {
        UI.SetActive(true);
        updateUI();
    }

    private void updateUI()
    {
        if (ayam)
        {
            objective.text = (kotoranAyam == true) ? "Pergi ke Yuyu Kangkang\n\n\nKotoran Ayam" + " 1 / 1\n" : "Carilah Kotoran Ayam\n\n\nKotoran Ayam" + " 0 / 1\n";
        }
        else
        {
            bool[] all = { greenKey, yellowKey, rope, penPaper };
            string[] all2 = { "Kunci Hijau", "Kunci Kuning", "Tali", "Kertas dan Pena" };
            int temp = 0;
            int bener = 0;

            objective.text = "Carilah Barang Penting\n\n";

            foreach (bool x in all)
            {
                objective.text += (x == true) ? all2[temp] + " 1 / 1\n" : all2[temp] + " 0 / 1\n";
                temp++;
                if (x == true) bener++;
            }

            if(bener == 4)
            {
                temp = 0;
                objective.text = "Kaburlah melalui jendela\n\n";
                foreach (bool x in all)
                {
                    objective.text += (x == true) ? all2[temp] + " 1 / 1\n" : all2[temp] + " 0 / 1\n";
                    temp++;
                }
            }
        }
    }

    public bool getGreenKey()
    {
        return greenKey;
    }

    public bool getYellowKey()
    {
        return yellowKey;
    }

    public bool getRope()
    {
        return rope;
    }

    public bool getPenPaper()
    {
        return penPaper;
    }

    public bool getKotoranAyam()
    {
        return kotoranAyam;
    }

    public void setKotoranAyam(bool value)
    {
        kotoranAyam = value;
        updateUI();
    }
}