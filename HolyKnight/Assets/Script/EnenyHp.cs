using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyHp : MonoBehaviour
{
     public int maxHealth;
     private int curHealth;
     float hp;
     public bool isDie = false;

     private Animator Anime;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        hp = maxHealth;
         Anime = GetComponent<Animator>(); 
        
    }

    private void OnTriggerEnter2D(Collider2D other)  
     {
        if(other.gameObject.tag == "PlayerHit")
        {
          
           TakeDamage(10);
           //AudioManager.instance.playenemyHit();
        }
        if(other.gameObject.tag == "Ult")
        {
         
           TakeDamage(110);
           //AudioManager.instance.playenemyHit();
        }
    }
      public void TakeDamage(int damage)
    {
        
        curHealth -= damage;

        hp = maxHealth/curHealth;
        
        
        if(hp <= 0)
        {
            isDie = true;
             //AudioManager.instance.playDie();
             // Destroy(this.gameObject);
            Anime.SetBool("isDie", isDie);
        }
    }
    public void Death()
    {
        Destroy(this.gameObject);
    }

   
}
