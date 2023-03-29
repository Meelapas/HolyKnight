using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultbar : MonoBehaviour
{
    [SerializeField]Player player;
    public GameObject[] UltBar;
    public int Ult = 0;
    // Start is called before the first frame update
    void Start()
    {
        UltBar[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Ult>3)
        {
            Ult = 3;
        }
        switch (Ult)
        {
            case 0:
                UltBar[0].SetActive(true);
                UltBar[1].SetActive(false);
                UltBar[2].SetActive(false);
                UltBar[3].SetActive(false);
            break;
            case 1:
                UltBar[1].SetActive(true);
                UltBar[0].SetActive(false);
                UltBar[2].SetActive(false);
                UltBar[3].SetActive(false);
            break;
            case 2:
                UltBar[2].SetActive(true);
                UltBar[0].SetActive(false);
                UltBar[1].SetActive(false);
                UltBar[3].SetActive(false);
            break;
            case 3:
                UltBar[3].SetActive(true);
                UltBar[0].SetActive(false);
                UltBar[1].SetActive(false);
                UltBar[2].SetActive(false); 
            break;
        }
    }
}
