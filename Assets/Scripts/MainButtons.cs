using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Find;
using UnityEngine.UI;

public class MainButtons : MonoBehaviour
{
   
    public WorldRotation rotateWorld;
   
    public void NewGame()
    {
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 0;
        GetComponent<CameraPositions>().CameraPos =1;
        GetComponent<SelectButtons>().SetTexts(0);
        rotateWorld.worldturnforce = 0;
        rotateWorld.RotateAngle(18);
    }

}
