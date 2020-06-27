using UnityEngine;

public class PickUpItem :  ItemInteraction
{
    [SerializeField] private int _itemNumber;
    [SerializeField] Animator _textAnimation;
    [SerializeField] private Highlighter _higlight;

    public override void ShowInteraction()
    {
        _textAnimation.SetTrigger("Show");
    }

    public override void Interact()
    {
        CementeryManager.instance.TakeItem(_itemNumber);
        gameObject.SetActive(false);
    }
}
