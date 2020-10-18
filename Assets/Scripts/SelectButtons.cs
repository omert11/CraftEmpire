using System.Collections;
using System.Collections.Generic;
using Find;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtons : MonoBehaviour
{
    public CanvasGroup SelectCanvas;
    public WorldRotation rotateWorld;

    bool setslowly;
    float wood;
    float woodplus;
    float ore;
    float oreplus;
    float food;
    float foodplus;
    public int worldNum;
    public void Change(bool isPos)
    {
        if (isPos)
        {
            worldNum++;

        }
        else
        {
            worldNum--;
        }
        if (worldNum > 4)
        {
            worldNum = 0;
        }
        else if (worldNum < 0)
        {
            worldNum = 4;
        }
        switch (worldNum)
        {
            case 0:
                rotateWorld.RotateAngle(18);
                break;
            case 1:
                rotateWorld.RotateAngle(110);
                break;
            case 2:
                rotateWorld.RotateAngle(181);
                break;
            case 3:
                rotateWorld.RotateAngle(252);
                break;
            case 4:
                rotateWorld.RotateAngle(323);
                break;

        }
        SetTexts(worldNum);
    }
   public void SetTexts(int worldn)
    {
        WorldData nowWorld = new Finder().WorldFinder(worldn);
        Text Kitatext = SelectCanvas.gameObject.transform.Find("Kitatext").GetComponent<Text>();
        Text Yuzeytext = SelectCanvas.gameObject.transform.Find("Yuzeytext").GetComponent<Text>();
        Kitatext.text = nowWorld.worldname;
        Yuzeytext.text = nowWorld.surfacearea + " Km²";
        wood = nowWorld.woodprops;
        food = nowWorld.foodprops;
        ore = nowWorld.oreprops;
        setslowly = true;
    }
    void SetSlowly()
    {
        Text foodtext = SelectCanvas.gameObject.transform.Find("FoodText").GetComponent<Text>();
        Text woodtext = SelectCanvas.gameObject.transform.Find("WoodText").GetComponent<Text>();
        Text oretext = SelectCanvas.gameObject.transform.Find("OreText").GetComponent<Text>();
        Image foodslider = SelectCanvas.gameObject.transform.Find("FoodSlider").GetComponent<Image>();
        Image woodslider = SelectCanvas.gameObject.transform.Find("WoodSlider").GetComponent<Image>();
        Image oreslider = SelectCanvas.gameObject.transform.Find("OreSlider").GetComponent<Image>();
        float nowfood = foodslider.fillAmount * 100;
        float nowwood = woodslider.fillAmount * 100;
        float nowore = oreslider.fillAmount * 100;
        foodplus = (food - nowfood) / 10;
        woodplus = (wood - nowwood) / 10;
        oreplus = (ore - nowore) / 10;
        if (System.Math.Abs(nowfood - food) > Mathf.Epsilon && System.Math.Abs(nowwood - wood) > Mathf.Epsilon
        && System.Math.Abs(nowore - ore) > Mathf.Epsilon)
        {
            foodtext.text = (nowfood + foodplus).ToString("#.##");
            woodtext.text = (nowwood + woodplus).ToString("#.##");
            oretext.text = (nowore + oreplus).ToString("#.##");
            foodslider.fillAmount = (nowfood + foodplus) / 100;
            woodslider.fillAmount = (nowwood + woodplus) / 100;
            oreslider.fillAmount = (nowore + oreplus) / 100;
        }
        else
        {
            setslowly = false;
        }

    }
    void Update()
    {
        if (setslowly)
            SetSlowly();
    }
    public void OnWorldSelected()
    {
        rotateWorld.worldturnforce = 5;
        rotateWorld.one = false;
        GetComponent<CameraPositions>().CameraPos = 2;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 2;
        GetComponent<ResourcesInner>().enabled = true;
    }
    public void OnMainMenu()
    {
        rotateWorld.worldturnforce = 5;
        rotateWorld.one = false;
        GetComponent<CameraPositions>().CameraPos = 0;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 1;
    }
}
