using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Behaviour camFov;

    float driveCD = 10;
    float count;

    void Update()
    {
        if(count < 0)
        {
            count -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && count <= 0)
        {
            count = driveCD;
            camFov.enabled = true;
        }
    }
}
