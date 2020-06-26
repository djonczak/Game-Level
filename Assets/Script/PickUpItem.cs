using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour {

    public GameManager manager;
    public int itemNumber;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                manager.SendMessage("TakeItem", itemNumber);
                gameObject.SetActive(false);
            }
        }
    } 
}
