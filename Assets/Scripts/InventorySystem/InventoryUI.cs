using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryService inventoryService;

    [Header("UI Refs - item list")]
    [SerializeField] private Transform inventoryItemContainer;
    [SerializeField] private InventoryItemButton inventoryItemButton;

    [Header("UI Refs - Item info")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text txtItemName;
    [SerializeField] private TMP_Text txtItemDescription;
    [SerializeField] private TMP_Text txtItemValue;


    void OnEnable()
    {
        inventoryService.OnInventorySystemLoaded += OnInventoryLoaded;
    }

    void OnDisable()
    {
        inventoryService.OnInventorySystemLoaded -= OnInventoryLoaded;
    }

    private void OnInventoryLoaded(Dictionary<ItemSO, int> items)
    {
        //clear the list
        foreach (Transform item in inventoryItemContainer)
        {
            Destroy(item);
        }

        // populate the list with items
        foreach (var item in items.Keys)
        {
            //create a button
            var button = Instantiate(inventoryItemButton, inventoryItemContainer);
            button.SetButton(item.itemSprite, items[item]);

            // set the lisener.
        }

    }



}
