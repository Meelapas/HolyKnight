using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public int scene;
   public void gamestart()
   {
    SceneManager.LoadScene(scene+1);
   }
}
