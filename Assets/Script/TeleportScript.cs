using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour {

    public Transform player;
    public Transform teleportationPointPosition;
    public GameObject teleportEffect;
    public GameObject text1;
    public GameObject text2;
    public GameManager manager;

    // Use this for initialization

    private void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        if (manager.teleported)
        {
            teleportEffect.SetActive(true);
        }
        else
        {
            teleportEffect.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            text1.SetActive(true);
            if (manager.hasTeleportationStone == true) {
                text1.SetActive(false);
                text2.SetActive(true);
                teleportEffect.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    Teleport();
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            text1.SetActive(false);
            text2.SetActive(false);
        }
    }

    void Teleport()
    {
        manager.teleported = true;
        player.transform.position = teleportationPointPosition.position;
    }
}
