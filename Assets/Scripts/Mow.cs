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
    float _activateTime = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Swing(_leftAttack));
        }
	}

    private IEnumerator Swing(GameObject rightAttack)
    {
        rightAttack.SetActive(true);
        Debug.Log("Je suis activé");
        yield return new WaitForSeconds(_activateTime);
        rightAttack.SetActive(false);
        Debug.Log("Je suis desactivé");
    }
}
