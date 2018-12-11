using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawn : MonoBehaviour
{
    public Rigidbody clone;

    void OnEnable()
    {
        int rand = Random.Range(6, 12);

        while (rand > 0)
        {
            Vector3 rotAndDir = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            Rigidbody splinterClone = Instantiate(clone, transform.position, Quaternion.Euler(rotAndDir * 36f));
            splinterClone.AddForce(rotAndDir, ForceMode.Impulse);
            splinterClone.useGravity = true;
            splinterClone.transform.localScale *= Random.Range(.04f, .5f);
            rand--;
        }

        enabled = false;
    }
}
