using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargetObjects : MonoBehaviour
{
    public GameObject spawn;

    void OnEnable()
    {
        int rand = Random.Range(2, 5);

        while (rand > 0)
        {
            Vector3 pos = new Vector3(Random.Range(-9f, 9f), Random.Range(0f, 6f), Random.Range(0f, 20f));
            Instantiate(spawn, pos, Quaternion.identity);
            rand--;
        }

        enabled = false;
    }
}
