namespace World_of_Zuul___3._0.domain;

public class Item
{
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }

    public Item(string itemName, string itemDescription)
    {
        ItemName = itemName;
        ItemDescription = itemDescription;
    }

    public string getItemName()
    {
        return ItemName;
    }

    // ToString is reusable when you want to get item name and item description
    public override string ToString()
    {
        return$"{ItemName} - {ItemDescription}";
    }
}
