using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Rigidbody2D rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 5);  //โดดเหยียบเด้ง
            enemy.SetActive(false);
        }
    }

}
