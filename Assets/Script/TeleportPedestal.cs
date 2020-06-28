using UnityEngine;

public class TeleportPedestal : ItemInteraction
{
    [SerializeField] private GameObject _teleportEffect;
    [SerializeField] private GameObject _teleportCollider;
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
        _teleportEffect.SetActive(true);
        _text1.SetTrigger("Hide");
        _text2.SetTrigger("Hide");
        _teleportCollider.SetActive(true);
    }

    public override void HideInteraction()
    {
        if (CementeryManager.instance.ReturnTeleportStone())
        {
            _text2.SetTrigger("Hide");
        }
        else
        {
            _text1.SetTrigger("Hide");
        }
    }
}
