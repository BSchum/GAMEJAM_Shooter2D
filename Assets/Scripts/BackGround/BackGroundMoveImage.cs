﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoveImage : MonoBehaviour {
    private Vector3 _startPosition;
    public float ImageWidth;
    private float _actualPositionX;
    private float _speed;
    private float _newPosition;
    
    public float speed = 2f;
    public static float baseSpeed = 2f;


    // Use this for initialization
    void Start () {

        _startPosition = GetComponent<Transform>().position;
        _speed = speed;
        _actualPositionX = 0;
        ImageWidth = gameObject.GetComponent<SpriteRenderer>().bounds.max.x - gameObject.GetComponent<SpriteRenderer>().bounds.min.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.tag == "ground")
        {
            baseSpeed = speed;
        }
        _speed = speed;
        _actualPositionX += Time.deltaTime * _speed;
        _newPosition = Mathf.Repeat(_actualPositionX, ImageWidth);
        transform.position = _startPosition + Vector3.left * _newPosition;
    }
}
