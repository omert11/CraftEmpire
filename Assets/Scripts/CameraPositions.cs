using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour
{
    public Transform Camera;
    public int CameraPos;
    void Update()
    {
        switch (CameraPos)
        {

            case 0:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 15, -100), Time.deltaTime * 5);
                break;
            case 1:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, -15, -100), Time.deltaTime * 5);
                break;
            case 2:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 40, -250), Time.deltaTime * 5);
                break;
            case 3:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 40, -2000), Time.deltaTime * 5);
                Camera.rotation = Quaternion.RotateTowards(Camera.rotation, Quaternion.Euler(7, 90, 0), 120 * Time.deltaTime);
                break;
            case 4:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 40, -250), Time.deltaTime * 5);
                Camera.rotation = Quaternion.RotateTowards(Camera.rotation, Quaternion.Euler(7, 0, 0), 120 * Time.deltaTime);
                break;
            case 5:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 40, -2000), Time.deltaTime * 5);
                Camera.rotation = Quaternion.RotateTowards(Camera.rotation, Quaternion.Euler(90, 0, 0), 120 * Time.deltaTime);
                break;
            case 6:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 40, -250), Time.deltaTime * 5);
                Camera.rotation = Quaternion.RotateTowards(Camera.rotation, Quaternion.Euler(7, 0, 0), 120 * Time.deltaTime);
                break;
            case 7:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 40, -2000), Time.deltaTime * 5);
                Camera.rotation = Quaternion.RotateTowards(Camera.rotation, Quaternion.Euler(-90, 0, 0), 120 * Time.deltaTime);
                break;
            case 8:
                Camera.position = Vector3.Slerp(Camera.position, new Vector3(0, 40, -250), Time.deltaTime * 5);
                Camera.rotation = Quaternion.RotateTowards(Camera.rotation, Quaternion.Euler(7, 0, 0), 120 * Time.deltaTime);
                break;
        }

    }
}
