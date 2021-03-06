﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	public float levelSeconds = 60f;
	
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin (){
		winLabel = GameObject.Find ("Victory Text");
		if(!winLabel){
			Debug.LogWarning ("Please create the win object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;	
		
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition (){
		DestroyAllTaggedObjects();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}
	
	//Destroys all objects will destroyOnWin tag
	void DestroyAllTaggedObjects(){
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag ("destroyOnWin");
		
		foreach(GameObject taggedObject in taggedObjectArray){
			Destroy (taggedObject);
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}
