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

    IEnumerator SpawnRates() { yield return new WaitForSeconds(3f); Instantiate(WhatTypeofEnemy(), RandomizeSpawn(), Quaternion.identity); StartCoroutine(SpawnRates()); }
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
        // Determine the min and max X and Z values based on your corner transforms
        float minX = Mathf.Min(bottomLeftCornerMin.position.x, upperLeftCornerMin.position.x);
        float maxX = Mathf.Max(bottomRightCornerMax.position.x, upperRightCornerMax.position.x);

        float minZ = Mathf.Min(bottomLeftCornerMin.position.z, bottomRightCornerMin.position.z);
        float maxZ = Mathf.Max(upperLeftCornerMax.position.z, upperRightCornerMax.position.z);

        // Randomize X and Z within those ranges
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // You can pick a Y value from one of your corners (or also randomize between min/max Y)
        float y = Random.Range(bottomLeftCornerMin.position.y, upperLeftCornerMax.position.y);

        return new Vector3(randomX, y, randomZ);
    }
}
