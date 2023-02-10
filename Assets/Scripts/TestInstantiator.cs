using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstantiator : MonoBehaviour
{
    public GameObject[] colouredCubes;
    public Transform[] spawnPoints;

    private GameObject cubeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnProcedure");
    }

    public void SelectRandomCubePrefab()
    {
        int arrayNum = Random.Range(0, 7);
        cubeToSpawn = colouredCubes[arrayNum];
    }

    public IEnumerator SpawnProcedure()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            var currentSpawnLocation = spawnPoints[i].transform;
            SelectRandomCubePrefab();
            Instantiate(cubeToSpawn, currentSpawnLocation);
            yield return new WaitForSeconds(0.07f);
        }
    }
}
