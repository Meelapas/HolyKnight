using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] Ultbar ultbar;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            {
                if(ultbar.Ult<4)
                {
                    ultbar.Ult = 3;
                    gameObject.SetActive(false);
                }
               
            }

    }
}
