using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;

    public void Spawn()
    {
        Debug.Log("Try spawn");

        if (prefab == null)
        {
            Debug.LogError("Spawner - prefab == null");
            return;
        }

        Instantiate(prefab, transform.position, Quaternion.identity);
    }

}
