using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltAc : MonoBehaviour
{
    [SerializeField] GameObject effect;
   
    private void Start() {
         effect.SetActive(false);
        
    }
     public void UltAct()
    {
        for (int i = 0; i < 6; i++)
        {
            effect.SetActive(true);
          
        }
    }
     public void UltNonAct()
    {
       effect.SetActive(false);
      
    }
}
