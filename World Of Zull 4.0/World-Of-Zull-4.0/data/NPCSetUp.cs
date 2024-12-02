using World_Of_Zull_4._0.domain;
using System;
using System.Collections.Generic;
using System.IO;
namespace World_Of_Zull_4._0.data
{
    public class NPCSetUp
    {
        public static List<NPC> InitalizeNPCs()
        {   
            var allItems = ItemSetUp.GetAllItems();
            
            //hjælp metode til at indlæse tekst
            string GetInfomrationNPC(string filename)
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
            string fnorkelDesc = GetInfomrationNPC("fnorkel.txt");
            string gleenDesc = GetInfomrationNPC("gleen.txt");
            string erikDesc = GetInfomrationNPC("erik.txt");
            string karenDesc = GetInfomrationNPC("karen.txt");
            string bentDesc = GetInfomrationNPC("bent.txt");
            string naboBørnDesc = GetInfomrationNPC("naboBørn.txt");
            string gudDesc = GetInfomrationNPC("gud.txt");
            string gladNaboDesc = GetInfomrationNPC("gladNabo.txt");
            string surNaboDesc = GetInfomrationNPC("surNabo.txt");
            
            //Indlæs spørgsmål fra filer
            string glasmagerGlennQ1 = GetInfomrationNPC("glasmagerGlennQ1.txt"); 
            string glasmagerGlennQ2 = GetInfomrationNPC("glasmagerGlennQ2.txt"); 
            string elektrikerErikQ1 = GetInfomrationNPC("elektrikerErikQ1.txt");
            string elektrikerErikQ2 = GetInfomrationNPC("elektrikerErikQ2.txt");
            string kunstKarenQ1 = GetInfomrationNPC("kunstKarenQ1.txt");
            string kunstKarenQ2 = GetInfomrationNPC("kunstKarenQ2.txt");
            string bilBentQ1 = GetInfomrationNPC("bilBentQ1.txt");
            string bilBentQ2 = GetInfomrationNPC("bilbentQ2.txt");
            string naboBørnQ1 = GetInfomrationNPC("naboBørnQ1.txt");
            string naboBørnQ2 = GetInfomrationNPC("naboBørnQ2.txt");
            string gudQ1 = GetInfomrationNPC("gudQ1.txt");
            string gudQ2 = GetInfomrationNPC("gudQ2.txt");
            string gladNaboQ1 = GetInfomrationNPC("gladNaboQ1.txt");
            string gladNaboQ2 = GetInfomrationNPC("gladNaboQ2.txt");
            string surNaboQ1 = GetInfomrationNPC("surNaboQ1.txt");
            string surNaboQ2 = GetInfomrationNPC("surNaboQ2.txt");
            
            //Dette er en npc uden spørgsmål
            Item temp = new Item("temp", "temp");
            NPCalien fnorkel = new NPCalien("Fnorkel", 
                fnorkelDesc,
                "Du kan vel ikke hjælpe mig med at samle materialer ind til solpanelet?", false, temp);
            
            //Dette er NPCer med spørgsmål
            NPC glasmagerGlenn = new NPC(
                "Glasmager Glenn", 
                gleenDesc, 
                new List<Question>
                {
                    new Question(glasmagerGlennQ1,
                        new string[] { 
                            "»Det beskytter de skrøbelige solceller mod vejr og vind, mens det lader solens lys passere uhindret.««",
                            "»Det forstærker solens stråler for at øge panelernes energikraft.«", 
                            "»Det holder solcellerne kølige ved at reflektere overskydende varme væk.«" },
                        1),
                    new Question(glasmagerGlennQ2,
                        new string[] { 
                            "»For at gøre solcellepanelet smukt og lade det falde harmonisk ind i omgivelserne.«", 
                            "»For at lade solens magiske stråler passere frit og fylde solcellerne med kraft til at skabe energi.«", 
                            "»For at lade skadelige UV-stråler rense solcellerne og holde dem klare.«" },
                        2)
                },
                true, allItems["part1"]);
            
            NPC elektrikerErik = new NPC(
                "Elektriker Erik", 
                erikDesc, 
                new List<Question>
                {
                    new Question(elektrikerErikQ1,
                        new string[] { 
                            "»Den omdanner solens energi fra panelerne til kraftfuld strøm, som dit hjem kan bruge.«"
                            , "»Den fanger energien fra solens lys og opbevarer den til fremtidige tider.«", 
                            "»Den forstærker solens energi og skaber mere elektricitet end panelerne selv kan levere.«" },
                        1),
                    new Question(elektrikerErikQ2,
                        new string[] {
                            "»De udnytter solens vedvarende stråler og skaber elektricitet uden at forurene vores verden.«",
                            "»De opsamler elektricitet om dagen og opbevarer den magisk til natten, så batterier ikke er nødvendige.«",
                            "»De leverer uendelige mængder gratis energi uden nogensinde at skulle kobles til elnettet.«" },
                        1)
                },
                true, allItems["part2"]);

            
            NPC kunstKaren = new NPC(
                "Kunstneren Karen", 
                karenDesc, 
                new List<Question>
                {
                    new Question(kunstKarenQ1,
                        new string[] { 
                            "»Ved at indlejre solpaneler som dekorative mønstre i facaden, så de ligner magiske runer, der både beskytter og forsyner bygningen.«", 
                            "»Ved at bruge fortryllende bygningsintegrerede solceller, der smelter sammen med taget som et skjold af lys og fungerer som glitrende vinduer, " +
                            "der lader solens magi strømme ind. Et mesterværk af både skønhed og kraft.«", 
                            "»Ved at male solpanelerne med reflekterende farver, så de passer til bygningens farvetema.«" },
                        2),
                    new Question(kunstKarenQ2,
                        new string[] { 
                            "»Mosaiklamper med solceller, der opsamler solens energi om dagen og udsender et farverigt, magisk lys om natten.«", 
                            "»Spejllamper med solceller, der opsamler solens energi og reflekterer lyset som en kalejdoskopisk regnbue, der danser gennem haven.«", 
                            "»Solkrystal-lamper, der lagrer solens stråler og projicerer skarpe geometriske mønstre i mørket.«" },
                        1)
                },
                true, allItems["part3"]);
            
            NPC bilejerenBent = new NPC(
                "Bilejeren Bent", 
                bentDesc, 
                new List<Question>
                {
                    new Question(bilBentQ1,
                        new string[] { 
                            "»Ved at installere solpaneler på taget af bilen, som samler energien fra solens stråler til direkte opladning.«", 
                            "»Ved at oprette en forbindelse mellem bilen og en solcelledrevet ladestation, der udstråler ren energi fra solen.«", 
                            "»Ved at placere solpaneler rundt om hjulene, så de genererer energi, mens bilen kører på solbestrålede veje.«" },
                        2),
                    new Question(bilBentQ2,
                        new string[]
                        {
                            "»For at sikre, at al solens kraft straks kanaliseres til køretøjet uden spild, som om lysets magi aldrig standses.«", 
                            "»For at samle overskydende solenergi i et magisk lager, klar til at give liv til køretøjet om natten eller på dystre, overskyede dage.«", 
                            "»For at beskytte køretøjets hjerte mod den farlige kraft fra overopladning og absorbere enhver rest af solens stråler.«"
                        },
                        2)
                },
                true, allItems["part4"]);
            
            NPC naboBørn = new NPC(
                "Nabo Børnene", 
                naboBørnDesc, 
                new List<Question>
                {
                    new Question(naboBørnQ1,
                        new string[]
                        {
                            "»De indsamler solens stråler og omdanner dem til energi, som giver dem liv og får dem til at danse eller gå.«", 
                            "»Solcellerne opsamler solkraft til at skabe små vindstød, som skubber dyrene fremad.«", 
                            "»De bruger solens energi til at oplade krystaller, der giver dem magiske kræfter til at bevæge sig selv.«"
                        },
                        1),
                    new Question(naboBørnQ2,
                        new string[]
                        {
                            "»De omdanner sollys til små gnister, der får legetøjet til at lyse op i mørket.«", 
                            "»De bruger solens kraft til at skabe regnbuer, som gør alting smukkere og sjovere at lege med.«", 
                            "»De lærer os, hvordan solens stråler kan skabe energi uden at forurene, som en gave fra naturens magi.«"
                        },
                        3)
                },
                true, allItems["part5"]);
            
            NPC gud = new NPC(
                "Gud", 
                gudDesc, 
                new List<Question>
                {
                    new Question(gudQ1,
                        new string[]
                        {
                            "»Fordi solen udsender en uendelig strøm af lys, som kan oplyse selv de mørkeste nattehimler.«", 
                            "»Fordi den udsender enorme mængder energi som lys og varme, som vi kan udnytte.« ", 
                            "»Fordi dens kraft ligger gemt i dens kerne og kan frigives ved vores egne magiske handlinger.«"
                        },
                        2),
                    new Question(gudQ2,
                        new string[]
                        {
                            "»At solen vil skinne i utallige tidsaldre og fortsat sprede sin livgivende kraft.«", 
                            "»At solen genoplader sin magi fra stjernernes energi hver nat og bliver stærkere for hver dag, der går.«", 
                            "»At solen genskaber sin kraft ved hjælp af universets æter og derfor aldrig løber tør for energi.«"
                        },
                        1)
                },
                true, allItems["part6"]);

            
            NPC gladNabo = new NPC(
                "Glad Nabo", 
                gladNaboDesc, 
                new List<Question>
                {
                    new Question(gladNaboQ1,
                        new string[]
                        {
                            "»Man kan reducere elregningen med op til 50% ved at generere sin egen elektricitet.«", 
                            "»Solpaneler kan eliminere elregningen fuldstændigt, så man aldrig betaler for strøm igen.«", 
                            "»Besparelserne er minimale; solpaneler har ingen væsentlig indvirkning på elregningen.«"
                        },
                        1),
                    new Question(gladNaboQ2,
                        new string[]
                        {
                            "»Det betyder, at du kan opbevare den overskydende strøm i dit solcelleanlæg til senere brug.«", 
                            "»Det betyder, at du kan tjene penge ved at sælge din overskydende elektricitet til elnettet.«)", 
                            "»Det betyder, at du kan bruge den overskydende strøm til at opvarme dit hjem uden ekstra omkostninger.«"
                        },
                        2)
                },
                true, allItems["part7"]);

            
            NPC surNabo = new NPC(
                "Sur Nabo",
                surNaboDesc,
                new List<Question>
                {
                    new Question(surNaboQ1,
                        new string[]
                        {
                            "»Solpaneler fungerer som et skjold, der beskytter huset mod alderdom ved at reflektere solen væk og forhindre, at taget slides.«", 
                            "»Fordi solpaneler tiltrækker solens energi direkte ind i husets vægge, som gør dem stærkere og mere modstandsdygtige over tid.«", 
                            "Solpaneler gør huset mere attraktivt for købere, fordi de lover lavere energiomkostninger og en bæredygtig livsstil " +
                            "– som en investering i både fremtid og værdighed.«"
                        },
                        3),
                    new Question(surNaboQ2,
                        new string[]
                        {
                            "»Naboens solpaneler oplader batterier i løbet af dagen, som kan lagre energi til at drive huset under en strømafbrydelse " +
                            "– en energikilde uafhængig af elnettet.«", 
                            "Solpanelerne skaber et magnetisk felt, som stabiliserer strømforsyningen, selv når der er problemer på elnettet.«", 
                            "»Panelernes energi bliver automatisk ledt ind i naboens vægge, som opbygger en naturlig reserve af elektricitet i strukturen.«"
                        },
                        1)

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