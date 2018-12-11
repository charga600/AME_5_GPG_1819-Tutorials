using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Behaviour JumpBehav;
    public Behaviour SpawnBehav;
    public Behaviour TurretBehav;

    bool lastJumpActive;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TurretBehav.isActiveAndEnabled == false)
        {
            JumpBehav.enabled = true;
        }

        if(lastJumpActive != JumpBehav.isActiveAndEnabled && lastJumpActive)
        {
            SpawnBehav.enabled = true;
            TurretBehav.enabled = true;
        }

        lastJumpActive = JumpBehav.isActiveAndEnabled;
    }
}
