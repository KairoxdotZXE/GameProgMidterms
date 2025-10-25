using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform upperLeftCornerMin, upperLeftCornerMax, upperRightCornerMin, upperRightCornerMax;
    public Transform bottomLeftCornerMin, bottomLeftCornerMax, bottomRightCornerMin, bottomRightCornerMax;
    public GameObject rType, gType, bType;
    void Start()
    {
        StartCoroutine(SpawnRates());
    }

    IEnumerator SpawnRates() { yield return new WaitForSeconds(3f);Debug.Log("Spawning"); Instantiate(WhatTypeofEnemy(), RandomizeSpawn(), Quaternion.identity); StartCoroutine(SpawnRates()); }
    GameObject WhatTypeofEnemy()
    {
        GameObject toSummon = null;
         int indx = Random.Range(1, 4);
        switch (indx)
        {
            case 1:
                toSummon = rType;
                break;
                case 2:
                toSummon = gType;
                break;
                case 3:
                toSummon = bType;
                break;
        }
        return toSummon;
    }
private Vector3 RandomizeSpawn()
{
    float minX = Mathf.Min(bottomLeftCornerMin.position.x, upperLeftCornerMin.position.x);
    float maxX = Mathf.Max(bottomRightCornerMax.position.x, upperRightCornerMax.position.x);
    float minZ = Mathf.Min(bottomLeftCornerMin.position.z, bottomRightCornerMin.position.z);
    float maxZ = Mathf.Max(upperLeftCornerMax.position.z, upperRightCornerMax.position.z);

    int edge = Random.Range(0, 4);

    float spawnX = 0f;
    float spawnZ = 0f;

    switch (edge)
    {
        case 0: // left
            spawnX = minX - 2f;
            spawnZ = Random.Range(minZ, maxZ);
            break;
        case 1: // right
            spawnX = maxX + 2f;
            spawnZ = Random.Range(minZ, maxZ);
            break;
        case 2: // top
            spawnZ = maxZ + 2f;
            spawnX = Random.Range(minX, maxX);
            break;
        case 3: // bottom
            spawnZ = minZ - 2f;
            spawnX = Random.Range(minX, maxX);
            break;
    }

    // Keep Y consistent (same as your prefab or ground level)
    float y = rType.transform.position.y; // or just 0f if your scene is flat

    return new Vector3(spawnX, y, spawnZ);
}

}
