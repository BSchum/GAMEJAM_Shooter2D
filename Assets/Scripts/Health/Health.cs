using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour {
    public delegate void DamageTaken(int newHpAmount);
    public event DamageTaken damageTaken;
    public int hp { get; private set; }
    [SerializeField]
    int _maxHp;

	// Use this for initialization
	void Start () {
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
            Destroy(this.gameObject);
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
