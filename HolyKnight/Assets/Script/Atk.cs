using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk : MonoBehaviour
{
    [SerializeField] Ultbar Ult;
   
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            Ult.Ult++;
        }
    }
   
}
