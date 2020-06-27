using System.Collections;
using UnityEngine;

public class CementeryManager : MonoBehaviour
{
    public static CementeryManager instance;

    private bool _hasTeleportationStone;
    private bool _hasTeleported;
    private bool _hasFirstCrystal;
    private bool _hasSecondCrystal;
    private bool _hasThirdCrystal;

    public GameObject teleportCrystal;
    public GameObject bloodCrystal1;
    public GameObject bloodCrystal2;
    public GameObject bloodCrystal3;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        Cursor.visible = false;
        CheckItem();
    }

    public void TakeItem(int index)
    {
        if (index == 1)
        {
            _hasTeleportationStone = true;
        }
        if (index == 2)
        {
            _hasFirstCrystal = true;
        }
        if (index == 3)
        {
            _hasSecondCrystal = true;
        }
        if (index == 4)
        {
            _hasThirdCrystal = true;
        }
    }

    private void CheckItem()
    {
        if (_hasFirstCrystal)
        {
            bloodCrystal1.SetActive(false);
        }
        if (_hasSecondCrystal)
        {
            bloodCrystal2.SetActive(false);
        }
        if (_hasThirdCrystal)
        {
            bloodCrystal3.SetActive(false);
        }
        if (_hasTeleported || _hasTeleportationStone)
        {
            teleportCrystal.SetActive(false);
        }
    }

    public void SetItemFirstCrystal(bool active)
    {
        _hasFirstCrystal = active;
    }

    public void SetItemSecondCrystal(bool active)
    {
        _hasSecondCrystal = active;
    }

    public void SetItemThirdCrystal(bool active)
    {
        _hasThirdCrystal = active;
    }

    public void SetItemTeleportStone(bool active)
    {
        _hasTeleportationStone = active;
    }

    public void SetIfTeleported(bool active)
    {
        _hasTeleported = active;
    }

    public bool ReturnFirstCrystal()
    {
        return _hasFirstCrystal;
    }

    public bool ReturnSecondCrystal()
    {
        return _hasSecondCrystal;
    }

    public bool ReturnThirdCrystal()
    {
        return _hasThirdCrystal;
    }

    public bool ReturnTeleportStone()
    {
        return _hasTeleportationStone;
    }

    public bool ReturnIfTeleported()
    {
        return _hasTeleported;
    }
}
