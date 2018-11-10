using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Health))]
public class EnemyHealthBar : MonoBehaviour {
    Slider healthBar;
    Health health;
	// Use this for initialization
	void Start () {
        healthBar = GetComponentInChildren<Slider>();
        health = GetComponent<Health>();
        healthBar.maxValue = health.GetMaxHp();
        healthBar.value = health.GetMaxHp();
        health.Register(new Health.DamageTaken(ChangeHealth));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeHealth(int hp)
    {
        healthBar.value = hp;
    }
}
