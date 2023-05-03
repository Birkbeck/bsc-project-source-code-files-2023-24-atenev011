/// <summary>
/// Author: atenev01
/// Class for box colider.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColliderAdder : MonoBehaviour
{
    void Start()
    {
        // Find all GameObjects in the scene with the tag "tree_1"
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree_1");

        // Loop through each tree and add a BoxCollider component if it doesn't already have one
        foreach (GameObject tree in trees)
        {
            if (tree.GetComponent<BoxCollider>() == null) // If tree doesn't have a collider component
            {
                tree.AddComponent<BoxCollider>(); // Add a BoxCollider component
            }
        }
    }
}
