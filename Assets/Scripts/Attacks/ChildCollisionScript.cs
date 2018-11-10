using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollisionScript : MonoBehaviour {
    [SerializeField]
    Mow mowCollider;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Je suis dans le script ChildCollision et la collision a été detecté avec " + col.gameObject.name);

        mowCollider.OnMowCollision(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("This is the end");
    }
}
