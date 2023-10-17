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
    public Text objective;

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        updateUI();
    }

    private void updateUI()
    {
        bool[] all = {greenKey, yellowKey, rope, penPaper };
        string[] all2 = {"greenKey", "yellowKey", "rope", "penPaper"};
        int temp = 0;

        objective.text = "Kumpulkan Barang Penting \n\n";

        foreach(bool x in all)
        {
            objective.text += (x == true) ? all2[temp] + " 1 / 1\n" : all2[temp] + " 0 / 1\n";
            temp++;
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
}