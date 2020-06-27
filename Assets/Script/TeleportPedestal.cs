using UnityEngine;

public class TeleportPedestal : ItemInteraction
{
    public Transform Player;

    [SerializeField] private Transform _endPosition;
    [SerializeField] private GameObject _teleportEffect;
    [SerializeField] private Animator _text1;
    [SerializeField] private Animator _text2;

    private void Start()
    {
        if (CementeryManager.instance.ReturnIfTeleported())
        {
            _teleportEffect.SetActive(true);
        }
        else
        {
            _teleportEffect.SetActive(false);
        }
    }

    public override void ShowInteraction()
    {
        if (CementeryManager.instance.ReturnTeleportStone())
        {
            _text1.SetTrigger("Hide");
            _text2.SetTrigger("Show");
            _teleportEffect.SetActive(false);
        }
        else
        {
            _text1.SetTrigger("Show");
        }
    }

    public override void Interact()
    {
        _text1.SetTrigger("Hide");
        _text2.SetTrigger("Hide");
        Teleport();
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        _text1.SetActive(false);
    //        _text2.SetActive(false);
    //    }
    //}

    private void Teleport()
    {
        CementeryManager.instance.SetIfTeleported(true);
        Player.transform.position = _endPosition.position;
    }
}
