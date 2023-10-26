using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GhostPrefab;
    public GameObject[] Spawnponts;
    public float TimeSpawn;
    int SpawnPose;
    private void Start()
    {
        StartCoroutine("Wait");
    }
    IEnumerator Wait()
    {
   
        yield return new WaitForSeconds(TimeSpawn);
        SpawnPose = Random.Range(0, Spawnponts.Length);
        Instantiate(GhostPrefab, Spawnponts[SpawnPose].transform.position, Quaternion.identity);
        StartCoroutine("Wait");
    }
}
