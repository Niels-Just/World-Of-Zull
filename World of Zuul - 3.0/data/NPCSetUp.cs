using World_of_Zuul___3._0.domain;

namespace World_of_Zuul___3._0.data
{
    public class NPCSetUp
    {
        public static List<NPC> InitalizeNPCs()
        {   
            var allItems = ItemSetUp.GetAllItems();
            
            //Dette er en npc uden spørgsmål
            Item temp = new Item("temp", "temp");
            NPCalien fnorkel = new NPCalien("Fnorkel", 
                "Fnorkel rumvæsnet der er stytet ned!",
                "Du kan vel ikke hjælpe mig med at samle matterialer ind til solpannelet?", false, temp);
            
            //Dette er NPCer med spørgsmål
            NPC glasmagerGlenn = new NPC(
                "Glasmager Glenn", 
                "Hej Nabo", 
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true, allItems["part1"]);
            
            NPC elektrikerErik = new NPC(
                "Elektriker Erik", 
                "Hej Nabo", 
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true, allItems["part2"]);

            
            NPC kunstKaren = new NPC(
                "Kunstneren Karen", 
                "Hej Nabo", 
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true, allItems["part3"]);
            
            NPC bilejerenBent = new NPC(
                "Bilejeren Bent", 
                "Hej Nabo", 
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true, allItems["part4"]);
            
            NPC naboBørn = new NPC(
                "Nabo Børnene", 
                "Hej Nabo", 
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true, allItems["part5"]);
            
            NPC gud = new NPC(
                "Gud", 
                "Hej Nabo", 
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true, allItems["part6"]);

            
            NPC gladNabo = new NPC(
                "Glad Nabo", 
                "Hej Nabo :)", 
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2),
                    new Question("Hvad er det andet spørgsmål!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true, allItems["part7"]);

            
            NPC surNabo = new NPC(
                "Sur Nabo",
                "Hej Nabo ):<",
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)

                },
                true, allItems["part8"]);
            
            return new List<NPC>
            {
                glasmagerGlenn,
                elektrikerErik,
                kunstKaren,
                bilejerenBent,
                naboBørn,
                gud,
                gladNabo,
                surNabo,
                fnorkel
            };
        } 
    }
}