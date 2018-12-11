using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAutoLock : MonoBehaviour
{
    public float rotationSpeed;
    public string target;
    public Rigidbody projectile;

    [Header("Turret Variables")]
    public Transform turret;
    public float maxYaw;
    public float minYaw;

    [Header("Railgun Variables")]
    public Transform gun;
    public float maxPitch;
    public float minPitch;

    bool activeTargets;

    void OnEnable ()
    {
        activeTargets = true;
        StartCoroutine(rotateTurret());
	}

    IEnumerator rotateTurret()
    {
        while(activeTargets)
        {
            GameObject targetObj = null;
            targetObj = GameObject.FindGameObjectWithTag(target);

            if (targetObj == null)
            {
                activeTargets = false;
                enabled = false;
                yield return null;
            }

            Vector3 targetDirection = targetObj.transform.position - transform.position;

            //convert targeting to local reference frame
            targetDirection = transform.InverseTransformDirection(targetDirection).normalized;

            //get the component angles
            float yaw = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
            float pitch = Mathf.Atan2(-targetDirection.y, targetDirection.z) * Mathf.Rad2Deg;

            //clamp rotations
            yaw = Mathf.Clamp(yaw, minYaw, maxYaw);
            pitch = Mathf.Clamp(pitch, maxPitch, minPitch);

            //find the current rotation of components
            Vector3 localTurretForward = transform.InverseTransformDirection(turret.forward);
            float currentTurretForward = Mathf.Atan2(localTurretForward.x, localTurretForward.z) * Mathf.Rad2Deg;

            Vector3 localGunForward = transform.InverseTransformDirection(gun.forward);
            float currentGunForward = Mathf.Atan2(-localGunForward.y, targetDirection.z) * Mathf.Rad2Deg;

            //find the angle to rotate to face the target
            yaw -= currentTurretForward;
            pitch -= currentGunForward;

            //clamp to rotation possible in one frame
            yaw = Mathf.Clamp(yaw, -rotationSpeed * Time.fixedDeltaTime, rotationSpeed * Time.fixedDeltaTime);
            pitch = Mathf.Clamp(pitch, -rotationSpeed * Time.fixedDeltaTime, rotationSpeed * Time.fixedDeltaTime);

            if(Mathf.Abs(yaw) < 0.1E-12f && Mathf.Abs(pitch) < 0.1E-12f)
            {
                Rigidbody newProjectile = Instantiate(projectile, gun.position, transform.rotation);
                newProjectile.velocity = transform.TransformDirection(localGunForward) * 20f;
                yield return new WaitForSeconds(3f);
            }
            else
            {
                //translate angle into a Quaternion
                Quaternion appliedYaw = Quaternion.AngleAxis(yaw, Vector3.up);
                Quaternion appliedPitch = Quaternion.AngleAxis(pitch, Vector3.right);

                //apply rotation to components
                turret.localRotation *= appliedYaw;
                gun.localRotation *= appliedPitch;
            }

            yield return null;
        }
    }
}
