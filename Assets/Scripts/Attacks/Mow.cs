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
    GameObject _throwedMow;
    [SerializeField]
    float _activateTime = 0.4f;

    bool hasMow = true;

    int damage = 50;
	
	// Update is called once per frame
	void Update () {
        if (hasMow)
        {
            if (Input.GetButtonDown("Fire1") && !Input.GetButtonDown("Fire2"))
            {
                this.GetComponentInChildren<Animator>().SetTrigger("isUpAttacking");
                StartCoroutine(Swing(_leftAttack));
            }

            if (Input.GetButtonDown("Fire2") && !Input.GetButtonDown("Fire1"))
            {
                this.GetComponentInChildren<Animator>().SetTrigger("isDownAttacking");
                StartCoroutine(Swing(_rightAttack));

            }

            if (Input.GetButtonUp("Fire1") && Input.GetButtonUp("Fire2"))
            {
                Throw(_throwedMow);
            }
        }
    }
    
    private IEnumerator Swing(GameObject rightAttack)
    {
        //Activation du collider de la faux
        rightAttack.GetComponent<PolygonCollider2D>().enabled = true;
        yield return new WaitForSeconds(_activateTime);
        rightAttack.GetComponent<PolygonCollider2D>().enabled = false;
        this.GetComponentInChildren<Animator>().SetTrigger("isRunning");


    }

    private void Throw(GameObject mow)
    {
        GameObject throwedMow = Instantiate(mow, this.transform.position, Quaternion.identity);
        throwedMow.GetComponent<ThrowedMow>().player = this.gameObject.transform;
        throwedMow.GetComponent<ThrowedMow>().firstThrowPos = this.gameObject.transform.position;
        hasMow = false;
    }

    public void Recuperate()
    {
        hasMow = true;
    }

    public void OnMowCollision(Collision2D col)
    {
        if(col.gameObject.tag == "enemy")
        {
            col.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
