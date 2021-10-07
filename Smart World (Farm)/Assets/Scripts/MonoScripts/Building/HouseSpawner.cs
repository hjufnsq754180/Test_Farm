using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject personPref;
    public Transform spawnPoint;
    public bool isSpawn = false;

    private void Start()
    {
        if (!isSpawn)
        {
            Vector3 personPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
            Instantiate(personPref, personPos, Quaternion.identity);
            isSpawn = true;
        }
    }
}
