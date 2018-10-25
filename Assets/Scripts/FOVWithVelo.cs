using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVWithVelo : MonoBehaviour
{
    Camera cam;

    void OnEnable()
    {
        cam = FindObjectOfType<Camera>();
        cam.fieldOfView = 70f;
    }

    void Update()
    {
        if(cam.fieldOfView < 179)
        {
            cam.fieldOfView +=  (100 * Time.deltaTime);
        }
        else
        {
            cam.fieldOfView = 70f;
            enabled = false;
        }
    }
}
