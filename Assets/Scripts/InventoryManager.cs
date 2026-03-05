using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> container;
    List<GameObject> inventory = new List<GameObject>();
    public UISlotHandler currentSlot;
    public Item item;

    void Awake()
    {
        EstablishInventory();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item"))
        {
            
            //when available slot (to come) == currentSlot
            //how to get item?
            PlaceInInventory(currentSlot, item);
        }
    }
    public List<GameObject> EstablishInventory()
    {
        
        foreach(GameObject slot in container)
        {
            inventory.Add(slot);
            Debug.Log("slot added");
        }
        return inventory;
    }
    public void StackInInventory(UISlotHandler currentSlot, Item item)
    {
        if(currentSlot.item.itemId != item.itemId) { return; }

        currentSlot.item.itemCount += item.itemCount;
        currentSlot.itemCountText.text = currentSlot.item.itemCount.ToString();
    }
    public void PlaceInInventory(UISlotHandler currentSlot, Item item)
    {
        currentSlot.item = item;
        currentSlot.icon.sprite = item.itemIcon;
        currentSlot.itemCountText.text = item.itemCount.ToString();
        currentSlot.icon.gameObject.SetActive(true);
    }
    public void ClearItemSlot(UISlotHandler currentSlot)
    {
        currentSlot.item = null;
        currentSlot.icon.sprite = null;
        currentSlot.itemCountText.text = string.Empty;
        currentSlot.icon.gameObject.SetActive(false);
    }
}
