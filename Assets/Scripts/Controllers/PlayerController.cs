using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class PlayerController : MonoBehaviour {
    Motor motor;
	// Use this for initialization
	void Start () {
        motor = GetComponent<Motor>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        motor.Move(direction);
	}
}
