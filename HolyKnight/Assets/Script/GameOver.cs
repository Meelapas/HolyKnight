using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int scene;
    public GameObject ui;
   public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     public void Win()
    {
        for (int i = 0; i < 3; i++)
        {
            ui.SetActive(true);
        }
        
        SceneManager.LoadScene(scene+1);
       
    }
       
      private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.gameObject.CompareTag("Die"))
            {
                gameOver();
            }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Win"))
            {
                 Win();
               
            }

    }
}

