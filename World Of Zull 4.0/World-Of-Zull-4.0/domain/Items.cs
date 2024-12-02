namespace World_Of_Zull_4._0.domain;

public class Item
{
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }

    public Item(string itemName, string itemDescription)
    {
        ItemName = itemName;
        ItemDescription = itemDescription;
    }

    public string GetItemName()
    {
        return ItemName;
    }

    // ToString is reusable when you want to get item name and item description
    public override string ToString()
    {
        return$"{ItemName} - {ItemDescription}";
    }
}
