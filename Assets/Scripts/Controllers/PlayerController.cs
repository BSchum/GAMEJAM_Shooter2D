using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class PlayerController : MonoBehaviour
{
    Motor motor;
    Camera cam;
    public static float margeLeft_world = 0;
    public static float margeRight_world = 0;
    public static float margeUp_world = 3;
    public static float margeBottom_world = 0.5f;

    private float _imageSize;
    float margeLeft_pixel, margeRight_pixel, margeUp_pixel, margeBottom_pixel;


    float screenHeight;
    float screenWidth;
    float screenWidthInWorld;

    // Use this for initialization
    void Start()
    {
        motor = GetComponent<Motor>();
        cam = Camera.main;

        _imageSize = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.max.x - gameObject.GetComponentInChildren<SpriteRenderer>().bounds.min.x;

        Vector3 lowerLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 lowerRight = cam.ViewportToWorldPoint(new Vector3(1, 0, 0));
        screenWidthInWorld = (lowerLeft - lowerRight).magnitude;

        _imageSize = _imageSize * Screen.width / screenWidthInWorld;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMarge();
        Vector3 direction = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (CanPlayerMove(direction)){
            motor.Move(direction);
        }
    }

    bool CanPlayerMove(Vector3 direction)
    {
        Vector3 futurPosition = cam.WorldToScreenPoint(transform.position + direction * Time.deltaTime * motor.GetSpeed());

        if (futurPosition.x > (0 + _imageSize / 2 + margeLeft_pixel) && 
            futurPosition.x < (Screen.width - _imageSize / 2 - margeRight_pixel) && 
            futurPosition.y > (0 + _imageSize / 2 + margeBottom_pixel) && 
            futurPosition.y < (Screen.height - _imageSize / 2 - margeUp_pixel))
        {
            return true;
        }
        return false;
    }

    void CalculateMarge()
    {
        margeLeft_pixel = margeLeft_world * Screen.width / screenWidthInWorld;
        margeRight_pixel = margeRight_world * Screen.width / screenWidthInWorld;
        margeUp_pixel = margeUp_world * Screen.width / screenWidthInWorld;
        margeBottom_pixel = margeBottom_world * Screen.width / screenWidthInWorld;
    }
}