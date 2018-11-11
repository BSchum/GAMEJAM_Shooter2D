using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlinkScript : MonoBehaviour {
    public Color textColorOn;
    public Color textColorOff;
    public Text guiText;

	// Use this for initialization
	void Start () {
        StartCoroutine(Blink());
	}
	
    IEnumerator Blink()
    {
        while (true)
        {
            Debug.Log("Change color");
            guiText.color = Color.Lerp(textColorOn, textColorOff, Mathf.PingPong(0, 1));
            yield return new WaitForSeconds(0.5f);
            guiText.color = Color.Lerp(textColorOff, textColorOn, Mathf.PingPong(0, 1));
            yield return new WaitForSeconds(0.5f);
        }
    }
}
