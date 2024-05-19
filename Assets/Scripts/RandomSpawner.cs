using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public static RandomSpawner instance;

    public GameObject targetPrefab;
    private static GameObject target;

    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        target = Instantiate(targetPrefab, transform.position, Quaternion.identity);
    }


    public void AddPoint()
    {
        // add a point to the counter
        // move the target to another location
        Vector3 randomDisplacement = new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0);
        target.transform.SetLocalPositionAndRotation(transform.position + randomDisplacement, Quaternion.identity);
    }
}
