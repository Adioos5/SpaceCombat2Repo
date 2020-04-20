using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensSpawner : MonoBehaviour
{
    public GameObject spawningMother;

    public List<GameObject> spawningAreas;

    public void SpawnAnAlien() {

        GameObject alien = Instantiate(spawningMother) as GameObject;

        alien.transform.parent = transform;

        alien.transform.localPosition = spawningAreas[Random.Range(0, spawningAreas.Count)].transform.localPosition;

        alien.SetActive(true);
        alien.GetComponent<ChasePlayer>().particles.SetActive(false);
    }
}
