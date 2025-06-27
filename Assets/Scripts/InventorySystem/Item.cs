using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO itemData;

    void Start()
    {
        if (!itemData) return;

        // if we have a data asset, we create a visual of the item
        var objVisual = Instantiate(itemData.itemPrefab, transform);
        objVisual.transform.position = transform.position;
        objVisual.transform.rotation = transform.rotation;
    }

    public ItemSO ItemData => itemData;

    public void Interact()
    {
        if (ServiceLocator.instance.GetService<InventoryService>().AddToInventory(itemData))
        {
            Debug.Log($"{itemData.name} collected!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"Cannot collect more {itemData.name}s!");
        }
    }

    
}
