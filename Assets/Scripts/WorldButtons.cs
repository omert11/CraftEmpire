using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButtons : MonoBehaviour
{
    public List<GameObject> crafters;
    public void OnStart()
    {
        
    }
    public void ChangeProduct(int product)
    {
        byte parsedProduct = byte.Parse(product.ToString());
        foreach(GameObject crafter in crafters)
        {
            crafter.GetComponent<Craftter>().product=parsedProduct;
            crafter.GetComponent<Craftter>().OnProductChange();
        }
    }
    public void OnBack()
    {
        GetComponent<CameraPositions>().CameraPos = 8;
        GetComponent<CanvasUpdater>().onCanvasUpdate = true;
        GetComponent<CanvasUpdater>().canvasState = 8;
    }
}
