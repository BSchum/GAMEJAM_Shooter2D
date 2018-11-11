using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField]
    List<GameObject> _enemies;
    int _currentEnemy;
    [SerializeField]
    Transform parent;
    [SerializeField]
    float _spawnRate = 2f;
    [SerializeField]
    float _flowerSpawnRate = 0.5f;

    [SerializeField]
    Transform spawnLine;


    [SerializeField]
    List<GameObject> _plants;
    //Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnPlants());
	}

    IEnumerator Spawn()
    {
        Camera cam = Camera.main;
        Vector3 lowerRight = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperRight = cam.ViewportToWorldPoint(new Vector3(0, 1, 0));
        while(true)
        {
            Vector3 position = new Vector3(spawnLine.position.x, UnityEngine.Random.Range(lowerRight.y + PlayerController.margeBottom_world, upperRight.y - PlayerController.margeUp_world),  0);
            Instantiate(_enemies[UnityEngine.Random.Range(0, _enemies.Count)], position, Quaternion.identity, parent);
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    IEnumerator SpawnPlants()
    {
        Camera cam = Camera.main;
        Vector3 lowerRight = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperRight = cam.ViewportToWorldPoint(new Vector3(0, 1, 0));
        while (true)
        {
            Vector3 position = new Vector3(spawnLine.position.x, UnityEngine.Random.Range(lowerRight.y + PlayerController.margeBottom_world, upperRight.y - PlayerController.margeUp_world), 0);
            Instantiate(_plants[UnityEngine.Random.Range(0, _plants.Count)], position, Quaternion.identity, parent);
            yield return new WaitForSeconds(_flowerSpawnRate);
        }
    }
}
