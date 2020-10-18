using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Find
{
    public class WorldData
    {
        public int worldnum;
        public string worldname;
        public float woodprops;
        public float foodprops;
        public float oreprops;
        public float surfacearea;
        public WorldData(int worldnum, string worldname, float woodprops, float foodprops, float oreprops, float surfacearea)
        {
            this.worldnum = worldnum;
            this.worldname = worldname;
            this.woodprops = woodprops;
            this.foodprops = foodprops;
            this.oreprops = oreprops;
            this.surfacearea = surfacearea;
        }
    }
    public class ItemRequintmentData
    {
        public int requedItemcode;
        public float requedCount;

        public ItemRequintmentData(int requedItemcode, float requedCount)
        {
            this.requedItemcode = requedItemcode;
            this.requedCount = requedCount;
        }
    }
    public class ItemData
    {
        public int itemcode;
        public string itemname;
        public float itemcount;
        public string itempicture;
        public float CollectS;
        public ItemData(int itemcode, string itemname, float itemcount, string itempicture, float CollectS)
        {
            this.itemcode = itemcode;
            this.itemname = itemname;
            this.itemcount = itemcount;
            this.itempicture = itempicture;
            this.CollectS = CollectS;
        }
         public ItemData(int itemcode, string itemname, float itemcount, string itempicture)
        {
            this.itemcode = itemcode;
            this.itemname = itemname;
            this.itemcount = itemcount;
            this.itempicture = itempicture;
        }
    }
    public class WorkLoadData
    {
        public float woodWorkL;
        public float foodWorkL;

        public WorkLoadData(float woodWorkL, float foodWorkL)
        {
            this.woodWorkL = woodWorkL;
            this.foodWorkL = foodWorkL;
        }
    }
    public class CollectableData
    {
        public List<ItemData> HavedItems;
        public float matCollectS;
        public CollectableData(float matCollectS,List<ItemData> HavedItems)
        {

            this.matCollectS = matCollectS;
            this.HavedItems = HavedItems;
        }
    }
    public class GameData
    {
        public int worldnum;
        public float population;
        public float temp;
        public float date;
        public int speed;
        public List<int> completedskils;
        public List<ItemData> myWorlditems;
        public float popHungry;
        public WorkLoadData workLoad;
        public CollectableData collectable;
        public GameData()
        {
        }

        public GameData(int worldnum, float population, float temp, float date,
         int speed, List<int> completedskils, float popHungry, WorkLoadData workLoad, CollectableData collectable)
        {
            this.worldnum = worldnum;
            this.population = population;
            this.temp = temp;
            this.date = date;
            this.speed = speed;
            this.completedskils = completedskils;
            this.popHungry = popHungry;
            this.workLoad = workLoad;
            this.collectable = collectable;
        }

        public GameData GameDataNew(int worldnum)
        {
            return new GameData(worldnum, 10, 23, 1, 5, new List<int>(), 1f,
            new WorkLoadData(0, 100), new CollectableData(1,new List<ItemData> {new Finder().ItemFinder(0,200),new Finder().ItemFinder(1,50),new Finder().ItemFinder(2,100)}));
        }
    }
    public class SkillData
    {
        public int skillNum;
        public int skillRequentment;
        public string skillName;
        public string skillDescription;
        public string skillImage;
        public float plusPoint;
        public int plusRef;
        public SkillData(int skillNum, int skillRequentment, string skillName, string skillDescription, string skillImage, float plusPoint, int plusRef)
        {
            this.skillNum = skillNum;
            this.skillRequentment = skillRequentment;
            this.skillName = skillName;
            this.skillDescription = skillDescription;
            this.plusPoint = plusPoint;
            this.plusRef = plusRef;
            this.skillImage = skillImage;
        }
    }
    public class PopulationData
    {
        public int indexPop;
        public bool isGirl;
        public bool isPregnant;
        public int pregnantTime;
        public int age;
        public float happiness;
        public PopulationData(int indexPop, bool isGirl, bool isPregnant, int pregnantTime, int age, float happiness)
        {
            this.indexPop = indexPop;
            this.isGirl = isGirl;
            this.isPregnant = isPregnant;
            this.pregnantTime = pregnantTime;
            this.age = age;
            this.happiness = happiness;
        }
    }
    public class Finder
    {
        public WorldData WorldFinder(int worldnum)
        {
            WorldData returned = null;
            switch (worldnum)
            {
                case 0:
                    returned = new WorldData(worldnum, "Amea", 87, 90, 45, 6500);
                    break;
                case 1:
                    returned = new WorldData(worldnum, "Crepune", 60, 20, 95, 2000);
                    break;
                case 2:
                    returned = new WorldData(worldnum, "Bechia", 100, 90, 25, 4500);
                    break;
                case 3:
                    returned = new WorldData(worldnum, "Uavris", 60, 100, 65, 6500);
                    break;
                case 4:
                    returned = new WorldData(worldnum, "Amone", 70, 70, 70, 1750);
                    break;
            }
            return returned;
        }
        public SkillData SkillFinder(int skillNum)
        {
            SkillData returned = null;
            switch (skillNum)
            {
                case 0:
                    returned = new SkillData(skillNum, 50, "İletişim",
                    "Popülasyonun iletişim kurmayı öğrenerek toplum puanı kazanmaya başlar. (Toplum puanı x1)", "subject", 1, 0);
                    break;
                case 1:
                    returned = new SkillData(skillNum, 75, "Ateş",
                    "Popülasyonun ateş yakmayı öğrenerek geceleri de çalışabilir. (Meteryal Verimliliği x1.25)", "fire", 1.25f, 1);
                    break;
                case 2:
                    returned = new SkillData(skillNum, 250, "Baltalar",
                    "Odun ile balta üretmeye başla.Balta olmadan odun toplayamayacağını unutma.(Odun Verimliliği x1)", "axe", 1f, 2);
                    break;
            }
            return returned;
        }

        public ItemData ItemFinder(int itemcode,float itemCount)
        {
            ItemData returned = null;
            switch (itemcode)
            {
                case 0:
                    returned = new ItemData(itemcode, "Gıda",itemCount , "food",1);
                    break;
                case 1:
                    returned = new ItemData(itemcode, "Toplum Puanı", itemCount, "emerald",1);
                    break;
                case 2:
                    returned = new ItemData(itemcode, "Odun", itemCount, "wood",1);
                    break;
                case 3:
                    returned = new ItemData(itemcode, "Odun Balta", itemCount, "woodaxe");
                    break;

            }
            return returned;
        }
        public List<ItemRequintmentData> ItemRequintmentsFinder(int itemcode)
        {
            List<ItemRequintmentData> returned = new List<ItemRequintmentData>();
            switch (itemcode)
            {
                case 3:
                    returned.AddRange(new List<ItemRequintmentData> {new ItemRequintmentData(1,2), new ItemRequintmentData(2,10)});
                    break;
            }
            return returned;
        }
    }
}

