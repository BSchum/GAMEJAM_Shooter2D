using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class EnemyController : MonoBehaviour {
    Motor motor;
	// Use this for initialization
	void Start () {
        this.motor = GetComponent<Motor>();
	}
	
	// Update is called once per frame
	void Update () {
        motor.Move(-transform.right);
	}
}
