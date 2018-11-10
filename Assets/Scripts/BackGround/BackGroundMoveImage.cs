using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoveImage : MonoBehaviour {
    private Vector3 _startPosition;
    public float ImageWidth;
    private BackGroundMove _backGroundMove;
    private float _actualPositionX;
    private float _speed;
    private float _newPosition;

	// Use this for initialization
	void Start () {
        _startPosition = GetComponent<Transform>().position;
        _backGroundMove = FindObjectOfType<BackGroundMove>();
        _speed = _backGroundMove.speed;
        _actualPositionX = 0;
        ImageWidth = gameObject.GetComponent<SpriteRenderer>().bounds.max.x - gameObject.GetComponent<SpriteRenderer>().bounds.min.x;

    }
	
	// Update is called once per frame
	void Update () {
        _speed = _backGroundMove.speed;
        //this.gameObject.transform.Translate(-transform.right * Time.deltaTime * _speed);
        _actualPositionX += Time.deltaTime * _speed;
        _newPosition = Mathf.Repeat(_actualPositionX, ImageWidth);
        transform.position = _startPosition + Vector3.left * _newPosition;
    }
}
