using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Find;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    ResourcesInner resourcesInner;
    GameObject SkillTreeCnv;
    public GameObject SkillTreeDialog;
    public void OnStart()
    {
        resourcesInner = GetComponent<ResourcesInner>();
        SkillTreeCnv = GetComponent<CanvasUpdater>().SkillTreeCanvas.gameObject;
        ActiveButtons();
    }
    void ActiveButtons()
    {
        Button ComminacationSkillBtn = SkillTreeCnv.transform.Find("ComminacationSkillBtn").GetComponent<Button>();
        Button FireSkillBtn = SkillTreeCnv.transform.Find("FireSkillBtn").GetComponent<Button>();
        Button AxesSkillBtn = SkillTreeCnv.transform.Find("AxesSkillBtn").GetComponent<Button>();
        List<Button> buttons = new List<Button> { ComminacationSkillBtn, FireSkillBtn,AxesSkillBtn};
        for (int i = 0; i < buttons.Count; i++)
        {
            SkillData isSkill = new Finder().SkillFinder(i);
            buttons[i].interactable = resourcesInner.gameData.collectable.HavedItems[1].itemcount >= isSkill.skillRequentment && !resourcesInner.gameData.completedskils.Contains(i);

        }

    }
    public void OnSkillAdd(int skillnum)
    {
        SkillData mySkill = new Finder().SkillFinder(skillnum);
        Plusser(mySkill.plusRef, mySkill.plusPoint);
        resourcesInner.gameData.collectable.HavedItems[1].itemcount -= mySkill.skillRequentment;
        resourcesInner.gameData.completedskils.Add(mySkill.skillNum);
        ActiveButtons();
        OnCancel();
    }
    void Plusser(int plusedRef, float plusPoint)
    {
        switch (plusedRef)
        {
            case 0:
                resourcesInner.gameData.collectable.HavedItems[1].CollectS *= plusPoint;
                break;
            case 1:
                resourcesInner.gameData.collectable.matCollectS *= plusPoint;
                break;
            case 2:
                resourcesInner.gameData.collectable.HavedItems[2].CollectS *= plusPoint;
                break;
        }

    }
    public void OnCancel()
    {
        SkillTreeDialog.SetActive(false);

    }
    public void OnSkillPressed(int skillnum)
    {
        SkillTreeDialog.SetActive(true);
        SkillData mySkill = new Finder().SkillFinder(skillnum);
        Text SkillNameText = SkillTreeDialog.transform.Find("SkillNameText").GetComponent<Text>();
        Text SkillDescp = SkillTreeDialog.transform.Find("SkillDescp").GetComponent<Text>();
        Image SkillImage = SkillTreeDialog.transform.Find("SkillImage").GetComponent<Image>();
        Button PosstiveBtn = SkillTreeDialog.transform.Find("PosstiveBtn").GetComponent<Button>();
        PosstiveBtn.onClick.AddListener(() => OnSkillAdd(skillnum));
        SkillNameText.text = mySkill.skillName;
        SkillDescp.text = mySkill.skillDescription;
        SkillImage.sprite = Resources.Load<Sprite>(mySkill.skillImage);
    }
    public void OnBack()
    {
        GetComponent<CameraPositions>().CameraPos = 4;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 4;
    }
}
