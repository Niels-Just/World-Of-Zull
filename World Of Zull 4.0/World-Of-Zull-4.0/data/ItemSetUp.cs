using World_Of_Zull_4._0.domain;
namespace World_Of_Zull_4._0.data
{
    public static class ItemSetUp
    {
        public static Dictionary<string, Item> GetAllItems()
        {
            return new Dictionary<string, Item>
            {
                { "glasmagerGlenn", new Item("Glasplade", "description") },
                { "elektrikerErik", new Item("Inverter", "description") },
                { "kunstKaren", new Item("Æstetisk solfilm", "description") },
                { "bilejerenBent", new Item("Energiomformer", "description") },
                { "naboBørn", new Item("Energikrystal", "description") },
                { "gud", new Item("Sollys", "description") },
                { "gladNabo", new Item("Energioptimeringschip", "description") },
                { "surNabo", new Item("Energiregulator", "description") }
            };
        }   
    }
}
