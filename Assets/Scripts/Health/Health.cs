using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour {
    public delegate void DamageTaken(int newHpAmount);
    public event DamageTaken damageTaken;
    public int hp { get; private set; }
    [SerializeField]
    int _maxHp;

    [SerializeField]
    float deathTime = 0;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        hp = _maxHp;
	}
	
    public int GetMaxHp()
    {
        return _maxHp;
    }

    public void TakeDamage(int amount)
    {
        this.hp -= amount;
        if(hp <= 0)
        {
            ScoreController.instance.AddScore(GetComponent<EnemyController>().enemyScore);
            ScoreController.instance.AddHappyness(GetComponent<EnemyController>().enemyHappyness);
            if(animator != null)
                animator.SetTrigger("Die");
            Destroy(this.gameObject, deathTime);
        }
    }

    public void Register(DamageTaken callBack)
    {
        damageTaken += callBack;
    }

    public void UnRegister(DamageTaken callBack)
    {
        damageTaken -= callBack;
    }
}
