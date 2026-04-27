using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage inventoryUI;
    //[SerializeField] private InventorySO inventoryData;
    public int inventorySize = 10;

    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                // foreach(var item in inventoryData.GetCurrentInventoryState())
                // {
                //     inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                // }
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
}
