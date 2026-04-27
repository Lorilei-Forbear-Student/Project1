using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] public UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private UIInventoryDesc itemDescription;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public Image image;
    public int quantity;
    public string title, description;


    private void Awake()
    {
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

    private void HandleShowItemActions(UIInventoryItem item)
    {
        
    }

    private void HandleEndDrag(UIInventoryItem item)
    {
    }

    private void HandleSwap(UIInventoryItem item)
    {
        
    }

    private void HandleBeginDrag(UIInventoryItem item)
    {
        
    }

    private void HandleItemSelection(UIInventoryItem item)
    {
        Debug.Log(item.name);
    }
}
