namespace TurnBasedChoiceRPG.Models;

public class Item
{
    public Item(string itemName, float itemPrice, int itemQuantity, int itemRarity)
    {
        ItemName = itemName;
        ItemPrice = itemPrice;
        ItemQuantity = itemQuantity;
        ItemRarity = itemRarity;
    }
    
    public string ItemName { get; set; }
    public float ItemPrice { get; set; }
    public int ItemQuantity { get; set; }
    public int ItemRarity { get; set; }
}