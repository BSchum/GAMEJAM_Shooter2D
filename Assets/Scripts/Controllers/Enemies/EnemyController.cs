using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class EnemyController : MonoBehaviour
{
    Motor motor;
    public Transform path { get; set; }
    Transform[] pathPoints;
    int currentTargetIndex = 1;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        pathPoints = path.GetComponentsInChildren<Transform>();
        this.motor = GetComponent<Motor>();
        target = pathPoints[currentTargetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(path == null)
        {
            motor.Move(-transform.right);
        }
        else
        {
            MoveFromPath();
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
