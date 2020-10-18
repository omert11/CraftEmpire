using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    public float worldturnforce;
    public Transform Camera;
    public bool one;
    float angle;
void Update()
    {
        if (one)
        {
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, angle, 0), 120 * Time.deltaTime);

        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * worldturnforce);

        }

    }
   public void RotateAngle(float ang)
    {
        angle = ang;
        one = true;
    }
}
