using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControllerUI : MonoBehaviour {
    public Text ScoreText;
    public Text HappyText;

    // Use this for initialization
    void Start () {
        ScoreController.instance.Subscribe((ScoreController.OnScoreUpdate)ChangeScoreUI);
        ScoreController.instance.Subscribe((ScoreController.OnHappynessUpdate)ChangeHappynessUI);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeScoreUI(int amount)
    {
        ScoreText.text = "Score : " + amount;
    }

    void ChangeHappynessUI(int amount)
    {
        HappyText.text = "Father Happyness : " + amount;
    }

}
