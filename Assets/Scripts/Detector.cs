using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public Behaviour explosionSpawn;

    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Projectile")
        {
            explosionSpawn.enabled = true;
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(waitAndDestroy());
            Destroy(target.gameObject);
        }
    }

    IEnumerator waitAndDestroy()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
