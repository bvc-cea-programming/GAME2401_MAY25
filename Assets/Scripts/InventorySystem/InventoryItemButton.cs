using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemButton : MonoBehaviour
{
    [SerializeField] private Image imgItemSprite;
    [SerializeField] private TMP_Text txtItemCount;
    [SerializeField] private Button button;

    public void SetButton(Sprite itemSprite, int itemCount)
    {
        // remove button listners
        button.onClick.RemoveAllListeners();

        imgItemSprite.sprite = itemSprite;
        txtItemCount.text = $"x {itemCount}";  // .text = "x" + itemCount;
    }
}
