using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterDungeon : MonoBehaviour {

    public GameObject text;
    public Text textInfo;
    bool isDone;
    private void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isDone == false)
            {
                text.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    isDone = true;
                    StartCoroutine("NextScene", 3f);
                }
            }
        }
    }

    IEnumerator NextScene(float time)
    {
        textInfo.text = "DLC 399$";
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Menu");
    }
}
