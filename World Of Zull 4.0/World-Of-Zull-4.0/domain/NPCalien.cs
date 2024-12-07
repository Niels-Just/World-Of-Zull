using World_Of_Zull_4._0.presentation;
namespace World_Of_Zull_4._0.domain


{
    //NPCalien arver fra NPC så også NPCalien kan bruge add metoden
    public class NpCalien : Npc
    {
        public string Information;

        public NpCalien(string name, string description, string information, bool hasPart, Item part)
            : base(name, description, new List<Question>(), hasPart, part)
        {
            Information = information;
        }

        public void TalkFnorkel(Room currentRoom)
        {
            Console.Clear();
            TextEffect.TxtEffectNpc($"{Name}: {Description}\n", 40);
            
            TextEffect.TxtEffectNpc($"{Information}\n", 40);
        }
    }
}
    