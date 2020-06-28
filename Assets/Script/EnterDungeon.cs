using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterDungeon : ItemInteraction {

    [SerializeField] private Animator _text;
    [SerializeField] private Text _textInfo;

    private bool IsDone;

    public override void ShowInteraction()
    {
        if (IsDone == false)
        {
            _text.SetTrigger("Show");
        }
    }

    public override void Interact()
    {
        if (Input.GetKey(KeyCode.E) && IsDone == false)
        {
            StartCoroutine(NextScene(3f));
            IsDone = true;
        }
    }

    private IEnumerator NextScene(float time)
    {
        _textInfo.text = "DLC 399$";
        yield return new WaitForSeconds(time);
        _text.SetTrigger("Hide");
        SceneManager.LoadScene("Menu");
    }
}
