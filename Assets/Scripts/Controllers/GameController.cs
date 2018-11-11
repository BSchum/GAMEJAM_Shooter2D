using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public SpawnController spawnCtrl;
    public Text startUI;

    enum GameState
    {
        NotStarted,
        Started
    }
    GameState gameState = GameState.NotStarted;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        spawnCtrl.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(gameState == GameState.NotStarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                spawnCtrl.enabled = true;
                Destroy(startUI.gameObject);
                gameState = GameState.Started;
            }
        }
	}
}
