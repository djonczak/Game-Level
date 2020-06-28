using UnityEngine;

public class Pause : MonoBehaviour {

    [SerializeField] private GameObject _pauseCanvas;
    private bool _isPausa;

    private void Awake()
    {
        _pauseCanvas.SetActive(false);
        OnResume();
    }

    private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPausa = !_isPausa;
            if (_isPausa)
            {
                OnPause();
            }
            else
            {
                OnResume();
            }
        }
	}

    public void OnResume()
    {
        _isPausa = false;
        _pauseCanvas.SetActive(false);
        Cursor.visible = false;
        UnitySampleAssets.Characters.FirstPerson.FirstPersonController.instance.canLook = true;
        UnitySampleAssets.Characters.FirstPerson.FirstPersonController.instance.enabled = true;
    }

    public void OnPause()
    {
        _pauseCanvas.SetActive(true);
        Cursor.visible = true;
        UnitySampleAssets.Characters.FirstPerson.FirstPersonController.instance.canLook = false;
        UnitySampleAssets.Characters.FirstPerson.FirstPersonController.instance.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
