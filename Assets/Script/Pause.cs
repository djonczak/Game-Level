using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseCanvas;
    public bool isPausa;
    public static Pause instance;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPausa = !isPausa;
        }

        if (isPausa)
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            Cursor.visible = true;
            UnitySampleAssets.Characters.FirstPerson.FirstPersonController.instance.canLook = false;
        }

        if (!isPausa )
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
            Cursor.visible = false;
            UnitySampleAssets.Characters.FirstPerson.FirstPersonController.instance.canLook = true;
        }

	}

    public void OnResume()
    {
        isPausa = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
