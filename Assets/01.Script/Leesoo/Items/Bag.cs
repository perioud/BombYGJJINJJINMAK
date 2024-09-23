using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public GameObject NotesScreen;
    public GameObject Slot;
    int slotIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (Slot == null || NotesScreen == null)
        {
            Debug.LogError("Slot or NotesScreen is not assigned!");
            return;
        }

        if (slotIndex >= Slot.transform.childCount)
        {
            Debug.LogError("Slot index is out of range!");
            return;
        }

        if (other.CompareTag("Item"))
        {
            Image imageComponent = Slot.transform.GetChild(slotIndex).GetChild(0).GetComponent<Image>();
            if (imageComponent == null)
            {
                Debug.LogError("Image component is missing!");
                return;
            }

            ItemProperty itemProperty = other.gameObject.GetComponent<ItemProperty>();
            if (itemProperty == null)
            {
                Debug.LogError("ItemProperty component is missing on the item!");
                return;
            }

            imageComponent.sprite = itemProperty.itemImage;

            GetItemName slotItemNameComponent = Slot.transform.GetChild(slotIndex).GetChild(0).GetComponent<GetItemName>();
            if (slotItemNameComponent == null)
            {
                Debug.LogError("GetItemName component is missing!");
                return;
            }

            slotItemNameComponent.inSlotItemName = itemProperty.itemName;

            Color color = imageComponent.color;
            color.a = 1f;
            imageComponent.color = color;

            CompareItemCheckList(slotItemNameComponent.inSlotItemName);

            slotIndex++;
            other.gameObject.SetActive(false);
        }
    }

    private void CompareItemCheckList(string inSlotItemName)
    {
        for (int i = 1; i < NotesScreen.transform.childCount; i++)
        {
            GetItemName checkListItemNameComponent = NotesScreen.transform.GetChild(i).GetComponent<GetItemName>();
            if (checkListItemNameComponent == null)
            {
                Debug.LogError("GetItemName component is missing on NotesScreen child!");
                continue;
            }

            string checkListItemName = checkListItemNameComponent.inSlotItemName;
            if (checkListItemName == inSlotItemName)
            {
                NotesScreen.transform.GetChild(i).GetComponent<Toggle>().isOn = true;
                break;
            }
        }
    }
}
