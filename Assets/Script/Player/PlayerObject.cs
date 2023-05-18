using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    private bool greenKey = false;
    private bool yellowKey = false;
    private bool rope = false;
    private bool penPaper = false;

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
