using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 2.0f;

    private List<GameObject> objectsToDestroy = new List<GameObject>();

    void Update()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Piece");


        objectsToDestroy.AddRange(clones);
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj, destroyTime);
        }

        objectsToDestroy.Clear();
    }
}