using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] public UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] public UIInventoryDesc itemDescription;
    public bool invUp;
    [SerializeField] private MouseFollower mouseFollower;
    public List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public Sprite image, image2;
    public int quantity;
    public string title, description;

    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }
    public void InitializeInventoryUI(int inventorySize)
    {
        for(int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;

        }
    }

    internal void ResetAllItems()
    {
        foreach(var item in listOfUIItems)
        {
            item.ResetData();
            item.Deselect();
        }
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
    {
        itemDescription.SetDescription(itemImage, name, description);
        DeselectAllItems();
        listOfUIItems[itemIndex].Select();
    }

    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if(listOfUIItems.Count > itemIndex)
        {
            listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }
    private void HandleShowItemActions(UIInventoryItem item)
    {
        int index = listOfUIItems.IndexOf(item);
        if(index == -1)
        {
            return;
        }
        //OnItemActionRequested?.Invoke(index);
    }

    private void HandleEndDrag(UIInventoryItem item)
    {
        mouseFollower.Toggle(false);
        //ResetDraggedItem();
    }

    private void HandleSwap(UIInventoryItem item)
    {
        int index = listOfUIItems.IndexOf(item);
        if(index == -1)
        {
            return;
        }
        //OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(item);
    }

    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        //currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(UIInventoryItem item)
    {
        int index = listOfUIItems.IndexOf(item);
        if(index == -1)
        {
            return;
        }
        //currentlyDraggedItemIndex = index;
        HandleItemSelection(item);
        //OnStartDragging?.invoke(index);

        mouseFollower.Toggle(true);
        mouseFollower.SetData(image, quantity);

    }

    public void CreateDraggeditem(Sprite sprite, int quantity)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite, quantity);
    }

    private void HandleItemSelection(UIInventoryItem item)
    {
        itemDescription.SetDescription(image, title, description);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ResetSelection();
        invUp = true;

        listOfUIItems[0].SetData(image, quantity);
        listOfUIItems[1].SetData(image2, quantity);
    }

    private void ResetSelection()
    {
        itemDescription.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        
    }

    public void Hide()
    {
        //actionPanel.Toggle(false);
        gameObject.SetActive(false);
        //ResetDraggedItem();
        invUp = false;
    }
}
