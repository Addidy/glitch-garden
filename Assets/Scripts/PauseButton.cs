using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

	private GameObject pauseScreen;
	private bool isPaused = false;

	// Use this for initialization
	void Start () {
		pauseScreen = GameObject.Find("Pause Screen");
		pauseScreen.SetActive (false);
	}
	
	private void OnMouseDown(){
		isPaused = !isPaused;
		pauseScreen.SetActive (isPaused);
		Time.timeScale = isPaused ? 0 : 1;
	}	
}
