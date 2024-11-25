using World_of_Zuul___3._0.domain;

namespace World_of_Zuul___3._0.data
{
    public static class ItemSetUp
    {
        public static Dictionary<string, Item> GetAllItems()
        {
            return new Dictionary<string, Item>
            {
                { "part1", new Item("part1", "description") },
                { "part2", new Item("part2", "description") },
                { "part3", new Item("part3", "description") },
                { "part4", new Item("part4", "description") },
                { "part5", new Item("part5", "description") },
                { "part6", new Item("part6", "description") },
                { "part7", new Item("part7", "description") },
                { "part8", new Item("part8", "description") }
            };
        }   
    }
}
