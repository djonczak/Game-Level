using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : MonoBehaviour {

    public GameManager manager;
    public GameObject barrier;
    public GameObject text1;
    public GameObject text2;
  
    bool isOpen;

    public void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isOpen == false)
            {
                text1.SetActive(true);
               
                if (manager.FirstCrystal == true && manager.SecondCrystal == true && manager.ThirdCrystal == true)
                {
                    text1.SetActive(false);
                    text2.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        isOpen = true;
                        barrier.SetActive(false);
                        text2.SetActive(false);
                    }
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text1.SetActive(false);
            text2.SetActive(false);
        }
    }
}
