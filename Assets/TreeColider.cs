using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColliderAdder : MonoBehaviour
{
    void Start()
    {
        // Find all GameObjects in the scene with the name "tree_1"
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree_1");

        // Loop through each tree GameObject and add a BoxCollider component
        foreach (GameObject tree in trees)
        {
            // Check if the tree already has a collider component
            if (tree.GetComponent<BoxCollider>() == null)
            {
                // Add a BoxCollider component to the tree
                tree.AddComponent<BoxCollider>();
            }
        }
    }
}
