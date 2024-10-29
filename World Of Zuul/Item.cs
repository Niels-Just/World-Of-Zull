namespace World_Of_Zuul;

public class Item
{
   public string ItemName { get; set; }
   public string ItemDescription { get; set; }

   public Item(string itemName, string itemDescription)
   {
      ItemName = itemName;
      ItemDescription = itemDescription;
   }

   public override string ToString()
   {
      return$"{ItemName} - {ItemDescription}";
   }
}