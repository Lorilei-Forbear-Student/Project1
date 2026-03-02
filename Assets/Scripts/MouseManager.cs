using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;
    public Item heldItem;
    public Item getHeldItem {get {return heldItem;}}

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHeldItem(UISlotHandler currentSlot)
    {
        var activeItem = currentSlot.item;
        
        if(heldItem != null && activeItem != null && heldItem.itemId == activeItem.itemId)
        {
            currentSlot.inventoryManager.StackInInventory(currentSlot, heldItem);
            heldItem = null;
            return;
        }

        if(currentSlot.item != null)
        {
            currentSlot.inventoryManager.ClearItemSlot(currentSlot);
        }

        if(heldItem != null)
        {
            currentSlot.inventoryManager.PlaceInInventory(currentSlot, heldItem);
        }

        heldItem = activeItem;
    }

    public void PickupFromStack(UISlotHandler currentSlot)
    {
        if(heldItem != null && heldItem.itemId != currentSlot.item.itemId)
        {
            return;
        }

        if(heldItem == null)
        {
            heldItem = currentSlot.item.Clone();
            heldItem.itemCount = default;
        }

        heldItem.itemCount++;
        currentSlot.item.itemCount--;
        currentSlot.itemCountText.text = currentSlot.item.itemCount.ToString();

        if(currentSlot.item.itemCount <= 0)
        {
            currentSlot.inventoryManager.ClearItemSlot(currentSlot);
        }
    }
}
