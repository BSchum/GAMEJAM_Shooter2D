using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Motor))]
public class ThrowedMow : MonoBehaviour
{

    Motor motor;
    [SerializeField]
    int damage;

    public Transform player;
    bool hasHit;
    bool hasDrop = false;
    public Vector3 firstThrowPos;

    Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        motor = GetComponent<Motor>();
    }
    void Update()
    {
        if (!hasHit)
        {
            Vector3 direction = firstThrowPos - this.transform.position;
            bool isTooFar = direction.magnitude > 12f;

            //Si mon arme est encore en l'air
            if (!isTooFar && !hasDrop)
            {
                motor.Move(transform.right);
            }
            //Si mon arme est tombé
            else if (hasDrop)
            {
                motor.Move(-transform.right, BackGroundMoveImage.speed);
                ReturnToThrower();
            }
            //Alors elle tombe
            else
            {
                animator.SetBool("HasFallen", true);
                hasDrop = true;
            }
        }
        else
        {
            Vector3 direction = player.transform.position - this.transform.position;
            motor.Move(direction.normalized);
            ReturnToThrower();
        }
    }
    void ReturnToThrower()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        if (direction.magnitude <= (motor.GetSpeed() * Time.deltaTime + 2))
        {
            player.GetComponent<Mow>().Recuperate();
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "enemy")
        {
            col.transform.GetComponent<Health>().TakeDamage(damage);
            hasHit = true;
        }
    }
}
