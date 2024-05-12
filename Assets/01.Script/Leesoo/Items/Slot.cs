using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool _isGetItem;
    private Sprite _slotSprite;

    public Sprite SlotSprite
    {
        get { return _slotSprite; }
        set
        {
            if (_slotSprite != value)
            {
                _slotSprite = value;
                GetComponent<Image>().sprite = _slotSprite;
            }
        }
    }
    [SerializeField]
    private Sprite EmptySlot;


    private void Start()
    {
        EmptySlot = GetComponent<Image>().sprite;
    }
}
