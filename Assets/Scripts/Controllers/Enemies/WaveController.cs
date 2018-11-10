using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {
    [SerializeField]
    List<Wave> _waves;
    [SerializeField]
    float _wavesRate;
    [SerializeField]
    Transform parent;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    
    IEnumerator Spawn(Wave wave)
    {
        for (int i = 0; i < wave.enemies.Count; i++)
        {
            GameObject enemy = Instantiate(wave.enemies[i], wave.pathParent.GetComponentsInChildren<Transform>()[1].position, Quaternion.identity ,parent);
            enemy.GetComponent<EnemyController>().path = wave.pathParent;
            yield return new WaitForSeconds(wave.spawnRate);
        }
    }

    IEnumerator SpawnWaves()
    {
        foreach (Wave w in _waves)
        {
            StartCoroutine(Spawn(w));
            yield return new WaitForSeconds(_wavesRate);
        }
    }
}
