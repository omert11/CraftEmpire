using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLobber : MonoBehaviour
{
    private const float M = 1000000f;
    private const float B = 1000000000f;
    private const float S = M * M * M * M;
    public int resourceCode;
    public float lastresource;
    public GameObject brain;
    Image backgraund;
    bool backshine;
    byte lightness;
    Text text;
    Image image;
    private void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
        backgraund = GetComponentInParent<Image>();
        image = transform.Find("Image").GetComponent<Image>();
    }
    void Update()
    {
        float resource = 0f;
        switch (resourceCode)
        {
            case 0:
                resource = brain.GetComponent<ResourcesInner>().gameData.collectable.HavedItems[0].itemcount;
                if (System.Math.Abs(lastresource - resource) > Mathf.Epsilon)
                {
                    IsChanged(resource);
                    lastresource = resource;
                }
                break;
            case 1:
                resource = brain.GetComponent<ResourcesInner>().gameData.collectable.HavedItems[1].itemcount;
                if (System.Math.Abs(lastresource - resource) > Mathf.Epsilon)
                {
                    IsChanged(resource);
                    lastresource = resource;
                }
                break;
            case 2:
                resource = brain.GetComponent<ResourcesInner>().gameData.collectable.HavedItems[2].itemcount;
                if (System.Math.Abs(lastresource - resource) > Mathf.Epsilon)
                {
                    IsChanged(resource);
                    lastresource = resource;
                }
                break;
        }
        if (backshine)
        {
            backgraund.color = new Color32(lightness, lightness, lightness, 120);

            if (lightness - byte.Parse(Mathf.RoundToInt(lightness * Time.deltaTime*3).ToString())<0)
            {
                lightness = 0;
                backshine = false;
            }
            else
            {
                lightness -= byte.Parse(Mathf.RoundToInt(lightness * Time.deltaTime*3).ToString());
            }
        }
    }
    void IsChanged(float resource)
    {
        string write = "";
        if (resource < 10000f)
        {
            write = resource.ToString("#.##");
        }
        else if (resource < M)
        {
            resource /= 1000;
            write = resource.ToString("#.##") + "K";
        }
        else if (resource < M * 1000)
        {
            resource /= M;
            write = resource.ToString("#.##") + "M";
        }
        else if (resource < M * M)
        {
            resource /= B;
            write = resource.ToString("#.##") + "B";
        }
        else if (resource < M * B)
        {
            resource /= M * M;
            write = resource.ToString("#.##") + "T";
        }
        else if (resource < M * M * M)
        {
            resource /= M * B;
            write = resource.ToString("#.##") + "Qa";
        }
        else if (resource < M * M * B)
        {
            resource /= M * M * M;
            write = resource.ToString("#.##") + "Qb";
        }
        else if (resource < M * M * M * M)
        {
            resource /= M * M * B;
            write = resource.ToString("#.##") + "Sx";
        }
        else if (resource < M * M * M * B)
        {
            resource /= M * M * M * M;
            write = resource.ToString("#.##") + "Sp";
        }
        else if (resource < S * M)
        {
            resource /= M * M * M * B;
            write = resource.ToString("#.##") + "Oc";
        }
        else if (resource < S * B)
        {
            resource /= S * M;
            write = resource.ToString("#.##") + "No";
        }
        else if (resource < S * M * M)
        {
            resource /= S * B;
            write = resource.ToString("#.##") + "De";
        }
        else if (resource < S * M * B)
        {
            resource /= S * M * M;
            write = resource.ToString("#.##") + "Ud";
        }
        text.text = write;
        image.enabled = true;
        backshine = true;
        backgraund.color = new Color32(255, 255, 255, 120);
        lightness = 255;
    }
}
