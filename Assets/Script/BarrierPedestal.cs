using UnityEngine;

public class BarrierPedestal : ItemInteraction
{
    [SerializeField] private GameObject _barrier;
    [SerializeField] private Animator _text1;
    [SerializeField] private Animator _text2;
  
    private bool _isOpen;

    public override void ShowInteraction()
    {
        if (_isOpen == false)
        {
            if (CementeryManager.instance.ReturnFirstCrystal() && CementeryManager.instance.ReturnSecondCrystal() && CementeryManager.instance.ReturnThirdCrystal())
            {
                _text1.SetTrigger("Hide");
                _text2.SetTrigger("Show");
            }
            else
            {
                _text1.SetTrigger("Show");
            }
        }
    }

    public override void Interact()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _isOpen = true;
            _barrier.SetActive(false);
            _text1.SetTrigger("Hide");
            _text2.SetTrigger("Hide");
        }
    }
}
