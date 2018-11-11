using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    int fatherHappyness;
    [SerializeField]
    int maxHappyness = 10;
    int score = 0;

    public delegate void OnScoreUpdate(int score);
    public event OnScoreUpdate onScoreUpdate;

    public delegate void OnHappynessUpdate(int happyness);
    public event OnHappynessUpdate onHappynessUpdate;

    public static ScoreController instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        fatherHappyness = maxHappyness;
    }

    public void AddScore(int amount)
    {
        score += amount;
        onScoreUpdate(score);
    }
    public void AddHappyness(int amount)
    {
        fatherHappyness += amount;
        onHappynessUpdate(fatherHappyness);
        if(fatherHappyness <= 0)
        {
            //TODO go to defeat scene
            Time.timeScale = 0;
        }
    }
    public void Subscribe(OnScoreUpdate callBack)
    {
        onScoreUpdate += callBack;
    }

    public void Subscribe(OnHappynessUpdate callBack)
    {
        onHappynessUpdate += callBack;
    }


}
