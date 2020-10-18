using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtons : MonoBehaviour
{
     WorldRotation world;
    int speed;
    public void OnspeedChange(bool isUp)
    {
        world = GetComponent<MainButtons>().rotateWorld;
        speed = GetComponent<ResourcesInner>().gameData.speed;
        if (isUp)
        {
            speed =speed*15;
        }
        else
        {
            speed=speed/15;
        }
        if (speed < 1)
        {
            speed = 1250;
        }
        if (speed > 1250)
        {
            speed = 5;
        }
        GetComponent<ResourcesInner>().gameData.speed = speed;
        world.worldturnforce = speed;
    }
    public void OnGoSkillTree()
    {
        GetComponent<SkillTree>().OnStart();
        GetComponent<CameraPositions>().CameraPos = 3;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 3;
    }
  public  void OnGoWorks()
    {
        GetComponent<CameraPositions>().CameraPos = 5;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 5;
    }
    public void OnGoWorld()
    {
        GetComponent<WorldButtons>().OnStart();
        GetComponent<CameraPositions>().CameraPos = 7;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 7;
    }
}
