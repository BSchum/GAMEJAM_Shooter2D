﻿using System;
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
    AudioSource audio;
    [SerializeField]
    float _activateTime = 0.4f;

    
    float attackRate = 0.5f;
    float nextAttack = 0;

    bool hasMow = true;

    int damage = 50;

    // Update is called once per frame
    void Update()
    {

        if (hasMow && nextAttack < Time.time)
        {
            if (Input.GetButtonDown("Fire1") && !Input.GetButtonDown("Fire2"))
            {
                Debug.Log("Up");
                nextAttack = Time.time + attackRate;
                audio.Play();
                this.GetComponentInChildren<Animator>().SetTrigger("isUpAttacking");
                StartCoroutine(Swing(_leftAttack));
            }
            else if (Input.GetButtonDown("Fire2") && !Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Down");
                nextAttack = Time.time + attackRate;
                audio.Play();
                this.GetComponentInChildren<Animator>().SetTrigger("isDownAttacking");
                StartCoroutine(Swing(_rightAttack));

            }
            if (Input.GetButtonDown("Fire1") && Input.GetButtonDown("Fire2"))
            {
                Debug.Log("Prepare");
                this.GetComponentInChildren<Animator>().SetTrigger("isHolding");
            }

            if (Input.GetButtonUp("Fire1") && Input.GetButtonUp("Fire2"))
            {
                Debug.Log("Release");
                this.GetComponentInChildren<Animator>().SetTrigger("isNaked");
                nextAttack = Time.time + attackRate;
                audio.Play();
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
        this.GetComponentInChildren<Animator>().SetTrigger("isRunning");
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
