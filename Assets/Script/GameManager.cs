using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool hasTeleportationStone;
    public bool teleported;
    public bool FirstCrystal;
    public bool SecondCrystal;
    public bool ThirdCrystal;
    public GameObject itemText1Pop;
    public GameObject itemText2Pop;

    //
    public GameObject teleportCrystal;
    public GameObject bloodCrystal1;
    public GameObject bloodCrystal2;
    public GameObject bloodCrystal3;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        itemText1Pop.SetActive(false);
        itemText2Pop.SetActive(false);
        CheckItem();
    }

    public void TakeItem(int index)
    {
        if (index == 1)
        {
            StartCoroutine("ShowItem1", 3f);
            hasTeleportationStone = true;
        }
        if (index == 2)
        {
            StartCoroutine("ShowItem2", 3f);
            FirstCrystal = true;
        }
        if (index == 3)
        {
            StartCoroutine("ShowItem2", 3f);
            SecondCrystal = true;
        }
        if (index == 4)
        {
            StartCoroutine("ShowItem2", 3f);
            ThirdCrystal = true;
        }
    }


    IEnumerator ShowItem1(float time)
    {
        itemText1Pop.SetActive(true);
        yield return new WaitForSeconds(time);
        itemText1Pop.SetActive(false);
    }

    IEnumerator ShowItem2(float time)
    {
        itemText2Pop.SetActive(true);
        yield return new WaitForSeconds(time);
        itemText2Pop.SetActive(false);
    }

    void CheckItem()
    {
        if (FirstCrystal)
        {
            bloodCrystal1.SetActive(false);
        }
        if (SecondCrystal)
        {
            bloodCrystal2.SetActive(false);
        }
        if (ThirdCrystal)
        {
            bloodCrystal3.SetActive(false);
        }
        if (teleported || hasTeleportationStone)
        {
            teleportCrystal.SetActive(false);
        }
    }
}
