using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            {
                if(Player.instance.Hp < 5)
                {
                    Player.instance.AddHp();
                    gameObject.SetActive(false);
                }
               
            }

    }
}
