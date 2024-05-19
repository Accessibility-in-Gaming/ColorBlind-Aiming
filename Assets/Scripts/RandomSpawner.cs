using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public static RandomSpawner instance;

    public GameObject targetPrefab;
    private static GameObject target;

    public float XRange = 10f;
    public float YRange = 10f;

    private int pointCounter = 0;

    
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
        pointCounter += 1;

        if (pointCounter < 10){

            // move the target to another location
            Vector3 randomDisplacement = new Vector3(Random.Range(-XRange, XRange), Random.Range(-YRange, YRange), 0);
            target.transform.SetLocalPositionAndRotation(transform.position + randomDisplacement, Quaternion.identity);

        }
        else {
            pointCounter = 0;
            target.transform.SetLocalPositionAndRotation(transform.position, Quaternion.identity);
        }
    }
}
