using System.Collections;
using System.Collections.Generic;
using Find;
using UnityEngine;
using UnityEngine.UI;

public class WorkButtons : MonoBehaviour
{
    GameData gameData;
    Slider sliderFood;
    Slider sliderWood;
    public void OnStart()
    {
        gameData = GetComponent<ResourcesInner>().gameData;
        sliderFood = GetComponent<CanvasUpdater>().WorkCanvas.transform.Find("SliderFood").GetComponent<Slider>();
        sliderWood = GetComponent<CanvasUpdater>().WorkCanvas.transform.Find("SliderWood").GetComponent<Slider>();
        OnValChange();
    }
    public void IsAxeAdded()
    {
        sliderWood.maxValue = gameData.collectable.HavedItems[3].itemcount / gameData.population * 100;
        sliderWood.gameObject.SetActive(true);
        sliderWood.interactable = true;
    }
    public void OnSlide(int isSliding)
    {
        float foodval = sliderFood.value;
        float woodval = sliderWood.value;
        float all = foodval + woodval;
        byte slidenum = 2;
        float decraseval = (100-all) / (slidenum - 1);
        switch (isSliding)
        {
           case 0:
                sliderWood.value += decraseval;
                break;
            case 1:
                sliderFood.value += decraseval;
                break;
        }
        OnValChange();
    }
    void OnValChange()
    {
        float foodk = sliderFood.value / 100;
        float woodk = sliderWood.value / 100;
        gameData.workLoad.foodWorkL = foodk*100;
        sliderFood.transform.Find("Text_Progres").GetComponent<Text>().text = sliderFood.value.ToString("#.#");
        sliderFood.transform.Find("Text_Pop").GetComponent<Text>().text = Mathf.RoundToInt(gameData.population *foodk).ToString();
        float product_f = (gameData.population * (((gameData.workLoad.foodWorkL + (new Finder().WorldFinder(gameData.worldnum).foodprops / 10)) / 100) - gameData.popHungry) * gameData.collectable.matCollectS);
        sliderFood.transform.Find("Text_Product").GetComponent<Text>().text = product_f.ToString("#.##");
        if (product_f > 0) sliderFood.transform.Find("Text_Product").GetComponent<Text>().color = Color.green;
        else sliderFood.transform.Find("Text_Product").GetComponent<Text>().color = Color.red;         
        //Wood
        gameData.workLoad.woodWorkL = woodk*100;
        sliderWood.transform.Find("Text_Progres").GetComponent<Text>().text = sliderWood.value.ToString("#.#");
        sliderWood.transform.Find("Text_Pop").GetComponent<Text>().text = Mathf.RoundToInt(gameData.population * woodk).ToString();
        float product_w = gameData.population * gameData.workLoad.woodWorkL * gameData.collectable.HavedItems[2].CollectS * (new Finder().WorldFinder(gameData.worldnum).woodprops / 100) / 100 * gameData.collectable.matCollectS;
        sliderWood.transform.Find("Text_Product").GetComponent<Text>().text = product_w.ToString("#.##");
        if (product_w > 0) sliderWood.transform.Find("Text_Product").GetComponent<Text>().color = Color.green;
        else sliderWood.transform.Find("Text_Product").GetComponent<Text>().color = Color.red;
    }
    public void OnBack()
    {
        GetComponent<CameraPositions>().CameraPos = 6;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 6;
    }
}
