using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class EnemyController : MonoBehaviour
{
    Motor motor;

    public int enemyScore;
    public int enemyHappyness;
    //*********Move from path
    public Transform path { get; set; }
    Transform[] pathPoints;
    int currentTargetIndex = 1;
    public Transform target;
    //*********Move from path


    // Use this for initialization
    void Start()
    {
        this.motor = GetComponent<Motor>();
        if (path != null)
        {
            pathPoints = path.GetComponentsInChildren<Transform>();
            target = pathPoints[currentTargetIndex];
        }
    }
    void Update()
    {
        if (path == null)
        {
            motor.Move(-transform.right);
        }
        else
        {
            MoveFromPath();
        }
        
        if (this.transform.position.x < Camera.main.ViewportToWorldPoint(new Vector3(-1, 0, 0)).x)
        {
            Destroy(this.gameObject);
        }
    }

    public void MoveFromPath()
    {
        Vector3 direction = target.position - this.transform.position;
        motor.Move(direction.normalized);

        if (direction.magnitude <= motor.GetSpeed() * Time.deltaTime)
        {
            GetNextPathNode();
        }
    }
    private void GetNextPathNode()
    {
        if (currentTargetIndex == pathPoints.Length)
        {
            Destroy(this.gameObject);
        }
        else
        {
            target = pathPoints[currentTargetIndex];
            currentTargetIndex++;
        }
    }
    
}
