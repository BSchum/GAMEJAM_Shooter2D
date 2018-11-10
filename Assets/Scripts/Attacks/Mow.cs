using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mow : MonoBehaviour {
    [SerializeField]
    GameObject _rightAttack;
    [SerializeField]
    GameObject _leftAttack;
    [SerializeField]
    float _activateTime = 0.2f;

    int damage = 50;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Swing(_leftAttack));
        }

        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Swing(_rightAttack));
        }
    }

    private IEnumerator Swing(GameObject rightAttack)
    {
        rightAttack.GetComponent<PolygonCollider2D>().enabled = true;
        yield return new WaitForSeconds(_activateTime);
        rightAttack.GetComponent<PolygonCollider2D>().enabled = false;
    }

    public void OnMowCollision(Collider2D col)
    {
        if(col.gameObject.tag == "enemy")
        {
            col.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
