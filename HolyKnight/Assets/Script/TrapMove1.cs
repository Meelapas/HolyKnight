using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove1 : MonoBehaviour
{
    bool check = false;
    public void checks()
    {
        if(!check)
        {
            moveup();
        }else movedown();
    }
    public void moveup()
    {
   
         
         transform.position = new Vector2(transform.position.x,transform.position.y+0.76f);
           
             check = true;
             
       
       
    }
    public void movedown()
    {
        
       transform.position = new Vector2(transform.position.x,transform.position.y-0.76f);
        check = false;
    }
}
