﻿using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
	public GameObject player;
	public AudioClip wind;
	PlayerMove playerMovement;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerMovement = player.GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.name == "Player") {
			player.GetComponent<PlayerMove>().SetWindBoostState (true);
			Debug.Log ("Activate Wind boost");
			if (!audio.isPlaying) {
				audio.Play();
				Debug.Log ("Play Wind Sounds");
			}
		}
	}
	
	void OnTriggerExit(Collider col) {
		if (col.name == "Player") {
			player.GetComponent<PlayerMove>().SetWindBoostState(false);
			audio.Stop ();
		}
	}
}
