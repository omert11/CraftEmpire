using System.Collections;
using System.Collections.Generic;
using Find;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesInner : MonoBehaviour
{
    public GameData gameData;
    WorldData worldData;
    GameObject GameCanvs;
    Text PopText;
    Text WorldName;
    Text DegreeT;
    Text DateText;
    Text SpeedText;
    int lastmonth;
    int lastday;
    int lastyear;
    void Start()
    {
        GameCanvs = GetComponent<CanvasUpdater>().GameCanvas.gameObject;
        PopText = GameCanvs.transform.Find("PopText").GetComponent<Text>();
        WorldName = GameCanvs.transform.Find("WorldName").GetComponent<Text>();
        DegreeT = GameCanvs.transform.Find("DegreeT").GetComponent<Text>();
        DateText = GameCanvs.transform.Find("DateText").GetComponent<Text>();
        SpeedText = GameCanvs.transform.Find("SpeedText").GetComponent<Text>();
        if (SaveLoadSystem.HasSaved())
        {
        gameData = SaveLoadSystem.LoadPlayer();
        }
        else
        {
            gameData = new GameData().GameDataNew(GetComponent<SelectButtons>().worldNum);
        }
        worldData = new Finder().WorldFinder(gameData.worldnum);
    }

    void Update()
    {
        PopText.text = gameData.population.ToString();
        WorldName.text = worldData.worldname;
        DegreeT.text = gameData.temp.ToString("#.##");
        DateText.text = DateCreator();
        SpeedText.text = gameData.speed.ToString();
        TimeCalculator();
    }
    string DateCreator()
    {
        string year_t = Mathf.FloorToInt(gameData.date / 420).ToString();
        string month_t = Mathf.FloorToInt((gameData.date % 420) / 30).ToString();
        string day_t = Mathf.FloorToInt((gameData.date % 420) % 30).ToString();
        if ((gameData.date % 420) / 30 < 10) month_t = "0" + month_t;
        int month = int.Parse(month_t);
        int year = int.Parse(year_t);
        int day = int.Parse(day_t);
        DegreeCalculator(month);

        if (lastmonth != month)
        {
            OnMonthChanged(month);
            lastmonth = month;
        }
        if (lastday != day)
        {
            OnDayChanged(day);
            lastday = day;
        }if (lastyear != year)
        {
            OnYearChanged(year);
            lastyear = year;
        }

        return year_t + " / " + month_t + " / " + day_t;

    }
    void OnDayChanged(int day)
    {
        if (gameData.completedskils.Contains(0)) gameData.collectable.HavedItems[1].itemcount += 1 * gameData.collectable.HavedItems[1].CollectS;
        GetComponent<WorkButtons>().OnStart();
        ResourceCalculator();
    }
    void OnMonthChanged(int month)
    {
        if (month % 3 == 0)
        {
            BornNewPop();
        }

    }
    void OnYearChanged(int year)
    {
    }

    void DegreeCalculator(int month)
    {
        if (month < 7)
        {
            float maxdeg = 33;
            float mindeg = 16;
            float secinturn = gameData.speed / 360f;
            float nightdetector = gameData.date % 1;
            if (nightdetector < 0.6 && nightdetector > 0.35)
            {
                //night
                if (gameData.temp - 1 / (0.25f / secinturn*Time.deltaTime) <= maxdeg && gameData.temp - 1 / (0.25f / secinturn*Time.deltaTime) >= mindeg)
                {
                    gameData.temp -= 1 / (0.25f / (secinturn * Time.deltaTime));
                }

            }
            else
            {
                if (gameData.temp + 1.05f / (0.75f / secinturn*Time.deltaTime) <= maxdeg && gameData.temp + 1.05f / (0.75f / secinturn*Time.deltaTime) >= mindeg)
                {
                    gameData.temp += 1.05f / (0.75f / (secinturn * Time.deltaTime));
                }
            }


        }
        else
        {
            float maxdeg = 25;
            float mindeg = -10;
            float secinturn = gameData.speed / 360f;
            float nightdetector = gameData.date % 1;
            if (nightdetector < 0.6 && nightdetector > 0.35)
            {
                //night
                if (gameData.temp - 1.05f / (0.25f / secinturn*Time.deltaTime) <= maxdeg && gameData.temp - 1.05f / (0.25f / secinturn*Time.deltaTime) >= mindeg)
                {
                    gameData.temp -= 1.05f / (0.25f / (secinturn * Time.deltaTime));
                }

            }
            else
            {
                if (gameData.temp + 1f / (0.75f / secinturn*Time.deltaTime) <= maxdeg && gameData.temp + 1 / (0.75f / secinturn*Time.deltaTime) >= mindeg)
                {
                    gameData.temp += 1f / (0.75f / (secinturn * Time.deltaTime));
                }
            }
        }

    }
    void BornNewPop()
    {
        gameData.population += Mathf.FloorToInt(Random.Range(0, gameData.population / 2 + 1));
    }
    void TimeCalculator()
    {
        float secinturn = gameData.speed / 360f;
        float pulusandtick = secinturn * Time.deltaTime;
        gameData.date += pulusandtick;
    }
    void ResourceCalculator()
    {
        gameData.collectable.HavedItems[0].itemcount += gameData.population * (((gameData.workLoad.foodWorkL+(worldData.foodprops/10))/100) - gameData.popHungry)*gameData.collectable.matCollectS;
        gameData.collectable.HavedItems[2].itemcount += gameData.population * gameData.workLoad.woodWorkL * gameData.collectable.HavedItems[2].CollectS*(worldData.woodprops/100) / 100 * gameData.collectable.matCollectS;
    }
}
