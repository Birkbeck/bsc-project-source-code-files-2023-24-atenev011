using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnableObject
{
    public GameObject Prefab;
    [Range(0, 1)]
    public float Probability;

}
