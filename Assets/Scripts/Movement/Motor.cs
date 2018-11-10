using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {
    
    [SerializeField]
    float speed = 10f;

    public void Move(Vector3 direction)
    {
        this.gameObject.transform.Translate(direction * Time.deltaTime * speed);
    }
}
