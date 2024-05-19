using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPrefab : MonoBehaviour
{
    public void Damage(){
        RandomSpawner.instance.AddPoint();
    }
}
