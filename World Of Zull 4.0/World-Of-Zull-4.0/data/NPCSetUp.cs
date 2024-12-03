using World_Of_Zull_4._0.domain;
using System;
using System.Collections.Generic;
using System.IO;
namespace World_Of_Zull_4._0.data
{
    public class NpcSetUp
    {
        public static List<Npc?> InitalizeNpCs()
        {   
            var allItems = ItemSetUp.GetAllItems();
            
            //hjælp metode til at indlæse tekst
            string GetInfomrationNpc(string filename)
            {
                try
                {
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string filePath = Path.Combine(currentDirectory, "Sample", filename);
                    return File.ReadAllText(filePath);
                    
                }
                catch
                {
                    return "Der opstod en fejl!";
                }
            }
            
            //Indlæs beskrivelser fra filer
            string fnorkelDesc = GetInfomrationNpc("fnorkel.txt");
            string gleenDesc = GetInfomrationNpc("gleen.txt");
            string erikDesc = GetInfomrationNpc("erik.txt");
            string karenDesc = GetInfomrationNpc("karen.txt");
            string bentDesc = GetInfomrationNpc("bent.txt");
            string naboBørnDesc = GetInfomrationNpc("naboBørn.txt");
            string gudDesc = GetInfomrationNpc("gud.txt");
            string gladNaboDesc = GetInfomrationNpc("gladNabo.txt");
            string surNaboDesc = GetInfomrationNpc("surNabo.txt");
            
            
            //Dette er en npc uden spørgsmål
            Item temp = new Item("temp", "temp");
            NpCalien? fnorkel = new NpCalien("Fnorkel", 
                fnorkelDesc,
                "Du kan vel ikke hjælpe mig med at samle materialer ind til solpanelet?", false, temp);
            
            //Dette er NPCer med spørgsmål
            Npc glasmagerGlenn = new Npc(
                "Glasmager Glenn", 
                gleenDesc, 
                new List<Question>
                {
                    new Question("»Hvilken vigtig rolle spiller glasset i et solcellepanel for dens funktionalitet?« \n",
                        new string[] { 
                            "»Det forstærker solens stråler for at øge panelernes energikraft.«",
                            "»Det beskytter de skrøbelige solceller mod vejr og vind, mens det lader solens lys passere uhindret.«", 
                            "»Det holder solcellerne kølige ved at reflektere overskydende varme væk.«" },
                        2),
                    new Question("»Hvorfor skal glasset i et solpanel være så krystalklart og gennemsigtigt som muligt?« \n",
                        new string[] { 
                            "»For at gøre solcellepanelet smukt og lade det falde harmonisk ind i omgivelserne.«", 
                            "»For at lade skadelige UV-stråler rense solcellerne og holde dem klare.«", 
                            "»For at lade solens stråler passere frit og fylde solcellerne med kraft til at skabe energi.«" },
                        3)
                },
                true, allItems["glasmagerGlenn"]);
            
            Npc? elektrikerErik = new Npc(
                "Elektriker Erik", 
                erikDesc, 
                new List<Question>
                {
                    new Question("»Hvilken kraft besidder inverteren i et solcellesystem?« \n",
                        new string[] { 
                            "»Den omdanner solens energi fra panelerne til kraftfuld strøm, som dit hjem kan bruge.«", 
                            "»Den fanger energien fra solens lys og opbevarer den til fremtidige tider.«", 
                            "»Den forstærker solens energi og skaber mere elektricitet end panelerne selv kan levere.«" },
                        1),
                    new Question("»Hvorfor betragtes solpaneler som en kraftfuld og pålidelig kilde til elektricitet?« \n",
                        new string[] {
                            "»De udnytter solens vedvarende stråler og skaber elektricitet uden at forurene vores verden.«",
                            "»De opsamler elektricitet om dagen og opbevarer den til natten, så batterier ikke er nødvendige.«",
                            "»De leverer uendelige mængder gratis energi uden nogensinde at skulle kobles til elnettet.«" },
                        1)
                },
                true, allItems["elektrikerErik"]);

            
            Npc? kunstKaren = new Npc(
                "Kunstneren Karen", 
                karenDesc, 
                new List<Question>
                {
                    new Question(" »Hvad skaber det elektriske felt i en solcelle, der genererer elektricitet?« \n",
                        new string[] { 
                            "»Glaslaget, der beskytter solcellen.«", 
                            "»Lag af silicium med positiv og negativ ladning.«", 
                            "»»Metalgitteret, der leder strømmen væk.««" },
                        2),
                    new Question("»Hvad er den primære fordel ved tyndfilmssolceller?« \n",
                        new string[] { 
                            "»Fleksibilitet og bærbarhed.«", 
                            "»Høj effektivitet.«", 
                            "»Lang levetid.«" },
                        1)
                },
                true, allItems["kunstKaren"]);
            
            Npc? bilejerenBent = new Npc(
                "Bilejeren Bent", 
                bentDesc, 
                new List<Question>
                {
                    new Question("»Hvordan kan solpaneler bruges til at lade en elektrisk vogn og samtidig tjene som et symbol på solens magt?« \n",
                        new string[] { 
                            "»Ved at installere solpaneler på taget af bilen, som samler energien fra solens stråler til direkte opladning.«", 
                            "»Ved at oprette en forbindelse mellem bilen og en solcelledrevet ladestation, der udstråler ren energi fra solen.«", 
                            "»Ved at placere solpaneler rundt om hjulene, så de genererer energi, mens bilen kører på solbestrålede veje.«" },
                        2),
                    new Question("»Hvorfor er det vigtigt at have et batterilagringssystem, når du oplader et elektrisk køretøj med solceller?« \n",
                        new string[]
                        {
                            "»For at sikre, at al solens kraft straks kanaliseres til køretøjet uden spild, som om lysets energi aldrig standses.«", 
                            "»For at samle overskydende solenergi i et lager, klar til at give liv til køretøjet om natten eller på dystre, overskyede dage.«", 
                            "»For at beskytte køretøjets hjerte mod den farlige kraft fra overopladning og absorbere enhver rest af solens stråler.«"
                        },
                        2)
                },
                true, allItems["bilejerenBent"]);
            
            Npc? naboBørn = new Npc(
                "Nabo Børnene", 
                naboBørnDesc, 
                new List<Question>
                {
                    new Question("»Hvorfor bruger de solceller på legetøjsdyrene solens kraft til at bevæge sig?« \n",
                        new string[]
                        {
                            "»De indsamler solens stråler og omdanner dem til energi, som giver dem liv og får dem til at danse eller gå.«", 
                            "»Solcellerne opsamler solkraft til at skabe små vindstød, som skubber dyrene fremad.«", 
                            "»De bruger solens energi til at oplade krystaller, der giver dem magiske kræfter til at bevæge sig selv.«"
                        },
                        1),
                    new Question("»Hvorfor er det sjovt og godt for verden at lege med solcelledrevet legetøj?« \n",
                        new string[]
                        {
                            "»De omdanner sollys til små gnister, der får legetøjet til at lyse op i mørket.«", 
                            "»De bruger solens kraft til at skabe regnbuer, som gør alting smukkere og sjovere at lege med.«", 
                            "»De lærer os, hvordan solens stråler kan skabe energi uden at forurene.«"
                        },
                        3)
                },
                true, allItems["naboBørn"]);
            
            Npc? gud = new Npc(
                "Gud", 
                gudDesc, 
                new List<Question>
                {
                    new Question("»Hvorfor er solen, som omfavner jorden med lys og varme, en så kraftfuld kilde til energi?« \n",
                        new string[]
                        {
                            "»Fordi solen udsender en uendelig strøm af lys, som kan oplyse selv de mørkeste nattehimmeler.«", 
                            "»Fordi den udsender enorme mængder energi som lys og varme, som vi kan udnytte.«", 
                            "»Fordi dens kraft ligger gemt i dens kerne og kan frigives ved vores innovative værktøjer.«"
                        },
                        2),
                    new Question("»Hvilken videnskabelig påstand gemmer sig bag, at solen er en uendelig kilde til energi?« \n",
                        new string[]
                        {
                            "»At solen vil skinne i utallige tidsaldre og fortsat forsyne Jorden med sin kraft.«", 
                            "»At solen genoplader fra stjernernes energi hver nat og bliver stærkere for hver dag, der går.«", 
                            "»At solen genskaber sin kraft ved hjælp af universets æter og derfor aldrig løber tør for energi.«"
                        },
                        1)
                },
                true, allItems["gud"]);

            
            Npc? gladNabo = new Npc(
                "Glad Nabo", 
                gladNaboDesc, 
                new List<Question>
                {
                    new Question("»Hvor meget kan man typisk spare på elregningen ved at installere solpaneler på sit hus?« \n",
                        new string[]
                        {
                            "»Man kan reducere elregningen med op til 50% ved at generere sin egen elektricitet.«", 
                            "»Solpaneler kan eliminere elregningen fuldstændigt, så man aldrig betaler for strøm igen.«", 
                            "»Besparelserne er minimale; solpaneler har ingen væsentlig indvirkning på elregningen.«"
                        },
                        1),
                    new Question("»Hvad betyder det, at jeg producerer mere strøm, end jeg bruger, og kan sælge det tilbage til nettet?« \n",
                        new string[]
                        {
                            "»Det betyder, at du kan opbevare den overskydende strøm i dit solcelleanlæg til senere brug.«", 
                            "»Det betyder, at du kan tjene penge ved at sælge din overskydende elektricitet til elnettet.«", 
                            "»Det betyder, at du kan bruge den overskydende strøm til at opvarme dit hjem uden ekstra omkostninger.«"
                        },
                        2)
                },
                true, allItems["gladNabo"]);

            
            Npc? surNabo = new Npc(
                "Sur Nabo",
                surNaboDesc,
                new List<Question>
                {
                    new Question("»Hvordan kan det være, at naboens hus er blevet mere værd med solpaneler, mens mit hus bare bliver ældre og dyrere at vedligeholde?« \n",
                        new string[]
                        {
                            "»Solpaneler fungerer som et skjold, der beskytter huset mod alderdom ved at reflektere solen væk og forhindre, at taget slides.«", 
                            "»Fordi solpaneler tiltrækker solens energi direkte ind i husets vægge, som gør dem stærkere og mere modstandsdygtige over tid.«", 
                            "»Solpaneler gør huset mere attraktivt for købere, fordi de lover lavere energiomkostninger og en bæredygtig livsstil – som en investering i både fremtid og værdighed.«"
                        },
                        3),
                    new Question("»Hvordan undgår naboen strømafbrydelser, fordi hans solpaneler giver ham backup, mens jeg sidder i mørket?« \n",
                        new string[]
                        {
                            "»Naboens solpaneler oplader batterier i løbet af dagen, som kan lagre energi til at drive huset under en strømafbrydelse – en energikilde uafhængig af elnettet.«", 
                            "»Solpanelerne skaber et magnetisk felt, som stabiliserer strømforsyningen, selv når der er problemer på elnettet.«", 
                            "»Panelernes energi bliver automatisk ledt ind i naboens vægge, som opbygger en naturlig reserve af elektricitet i strukturen.«"
                        },
                        1)

                },
                true, allItems["surNabo"]);
            
            return new List<Npc?>
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