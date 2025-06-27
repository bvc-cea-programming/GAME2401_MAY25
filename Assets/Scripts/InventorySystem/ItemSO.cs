using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int itemValue;
    public Sprite itemSprite;
    public GameObject itemPrefab;
}
