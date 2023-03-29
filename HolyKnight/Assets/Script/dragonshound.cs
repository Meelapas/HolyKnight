using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonshound : MonoBehaviour
{

  public bool isFire = false;
  public GameObject fire;
  bool check = false;
  private Animator Anime;
  private void Awake() {
    Anime= GetComponent<Animator>(); 
  }
    public void checks()
    {
        if(!check)
        {
            Onfire();
        }else NoOnfire();
    }
    public void Onfire()
    {
   
        isFire = true;
        Anime.SetBool("isFire", isFire);
           
             check = true;
             
       
       
    }
    public void NoOnfire()
    {
        
       isFire = false;
       Anime.SetBool("isFire", isFire);
        check = false;
    }
    public void shorund()
    {
        fire.SetActive(true);
    }
    public void Noshorund()
    {
        fire.SetActive(false);
    }
}
