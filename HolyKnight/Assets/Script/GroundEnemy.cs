using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
public float enemySpeed = 2f;
private Rigidbody2D rb;
private int Direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(enemySpeed* Direction, rb.velocity.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            FilpSprite();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground")&&(!collision.CompareTag("Player")) )
        {
            FilpSprite();
        }
    }
    void FilpSprite()
    {
            Direction *= -1;
            transform.localScale = new Vector2(Direction, 1f);
    }


}
