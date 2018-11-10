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
    Transform spawnLine;
	//Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}

    IEnumerator Spawn()
    {
        Camera cam = Camera.main;
        Vector3 upperRight = cam.ViewportToWorldPoint(new Vector3(1, 0, 0));
        Vector3 lowerRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));
        while(true)
        {
            Vector3 position = new Vector3(spawnLine.position.x, UnityEngine.Random.Range(upperRight.y - PlayerController.margeUp_world, lowerRight.y - PlayerController.margeBottom_world), 0);
            Debug.Log(position);
            Instantiate(_enemies[UnityEngine.Random.Range(0, _enemies.Count)], position, Quaternion.identity, parent);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
