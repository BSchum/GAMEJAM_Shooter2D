using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollisionScript : MonoBehaviour {
    [SerializeField]
    Mow mowCollider;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        mowCollider.OnMowCollision(col);
    }
}
