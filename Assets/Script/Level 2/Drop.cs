using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public bool kotoranAyam;

    public AyamInteraksi ayam;

    public PlayerObject player;

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.getKotoranAyam().Equals(true)) return;

        if (kotoranAyam)
        {
            ayam.getKotoranAyam();
        }
        else
        {
            ayam.getTelurAyam();
        }

        await Task.Delay(1000);
        Destroy(gameObject);
    }
}