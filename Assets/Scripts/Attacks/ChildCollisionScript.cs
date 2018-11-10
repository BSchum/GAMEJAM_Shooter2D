using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollisionScript : MonoBehaviour {
    [SerializeField]
    Mow mowCollider;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        mowCollider.OnMowCollision(col);
    }
}
