using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;

    [SerializeField]
    

    public float Area;
    [SerializeField]
    private Transform target;
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public void run()
    {
        LookatTarket();


        float distance = Vector2.Distance(transform.position, player.transform.position);
       // Debug.Log(distance);

        if(distance < Area)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
               
                
            }
        }

        if (distance > Area)
        {
            timer = Time.deltaTime;
            
            if (timer > 2)
            {
                timer = 0;
                
            }
        }


    }
    public void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

     void LookatTarket()
    {
        if(transform.position.x < target.position.x)
        {
           
            //     direction *= -1;
            //      transform.localScale = new Vector2(direction, 1f);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
           
            transform.localScale = new Vector2(1, 1);
        }
    }
}
