using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Find;
public class Craftter : MonoBehaviour
{
    public byte itemcode;
    public byte product;
    Image resource0I;
    Image resource1I;
    Text resource0T;
    Text resource1T;
    Button buyBtn;
    public ResourcesInner resourcesInner;
    GameData gameData;
    List<ItemRequintmentData> requests = new List<ItemRequintmentData>();
    void Start()
    {
        gameData = resourcesInner.gameData;
        resource0I = transform.Find("Resource0I").GetComponent<Image>();
        resource1I = transform.Find("Resource1I").GetComponent<Image>();
        resource0T = transform.Find("Resource0").GetComponent<Text>();
        resource1T = transform.Find("Resource1").GetComponent<Text>();
        buyBtn = transform.Find("BuyBtn").GetComponent<Button>();
        requests = new Finder().ItemRequintmentsFinder(itemcode);
        resource0I.sprite = Resources.Load<Sprite>(gameData.collectable.HavedItems[requests[0].requedItemcode].itempicture);
        resource1I.sprite = Resources.Load<Sprite>(gameData.collectable.HavedItems[requests[1].requedItemcode].itempicture);
        buyBtn.onClick.AddListener(OnBuy);
        OnProductChange();
    }
    public void OnProductChange()
    {
        if (product != 255)
        {
            resource0T.text = "-" + requests[0].requedCount * product;
            resource1T.text = "-" + requests[1].requedCount * product;
        }
        else
        {
            int mincount;
            int req0count=Mathf.FloorToInt(gameData.collectable.HavedItems[requests[0].requedItemcode].itemcount/requests[0].requedCount);
            int req1count=Mathf.FloorToInt(gameData.collectable.HavedItems[requests[1].requedItemcode].itemcount/requests[1].requedCount);
            if (req1count > req0count)
            {
                mincount = req0count;
            }
            else
            {
                mincount = req1count;
            }
            resource0T.text = "-" + requests[0].requedCount * mincount;
            resource1T.text = "-" + requests[1].requedCount * mincount;
        }

    }
    void OnBuy()
    {
        if (product != 255)
        {
            gameData.collectable.HavedItems[requests[0].requedItemcode].itemcount -= requests[0].requedCount * product;
            gameData.collectable.HavedItems[requests[1].requedItemcode].itemcount -= requests[1].requedCount * product;
            Adder(product);
        }
        else
        {
            int mincount;
            int req0count = Mathf.FloorToInt(gameData.collectable.HavedItems[requests[0].requedItemcode].itemcount / requests[0].requedCount);
            int req1count = Mathf.FloorToInt(gameData.collectable.HavedItems[requests[1].requedItemcode].itemcount / requests[1].requedCount);
            if (req1count > req0count)
            {
                mincount = req0count;
            }
            else
            {
                mincount = req1count;
            }
            gameData.collectable.HavedItems[requests[0].requedItemcode].itemcount -= requests[0].requedCount * mincount;
            gameData.collectable.HavedItems[requests[1].requedItemcode].itemcount -= requests[1].requedCount * mincount;
            Adder(mincount);
        }

    }
    void Adder(int count)
    {
        if (gameData.collectable.HavedItems.Count >itemcode)
        {
            gameData.collectable.HavedItems[itemcode].itemcount += count;

        }
        else
        {
            gameData.collectable.HavedItems.Add( new Finder().ItemFinder(itemcode,count));
        }
        WorkLoadOpenner();
    }
   void WorkLoadOpenner()
    {
        switch (itemcode)
        {
            case 3:
                resourcesInner.gameObject.GetComponent<WorkButtons>().IsAxeAdded();
                break;
        }
    }
}
