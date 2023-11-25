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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ayam) return;

        if (collision.gameObject.tag.Equals("GreenKey"))
        {
            greenKey = true;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("YellowKey"))
        {
            yellowKey = true;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("Rope"))
        {
            rope = true;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("PenPaper"))
        {
            penPaper = true;
            collision.gameObject.SetActive(false);
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
            objective.text = "Carilah Kotoran Ayam\n\n";

            objective.text += (kotoranAyam == true) ? "Kotoran Ayam" + " 1 / 1\n" : "Kotoran Ayam" + " 0 / 1\n";
        }
        else
        {
            bool[] all = { greenKey, yellowKey, rope, penPaper };
            string[] all2 = { "Kunci Hijau", "Kunci Kuning", "Tali", "Kertas dan Pena" };
            int temp = 0;

            objective.text = "Kumpulkan Barang Penting\n\n";

            foreach (bool x in all)
            {
                objective.text += (x == true) ? all2[temp] + " 1 / 1\n" : all2[temp] + " 0 / 1\n";
                temp++;
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