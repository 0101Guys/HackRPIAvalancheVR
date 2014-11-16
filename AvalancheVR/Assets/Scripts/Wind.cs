using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
	public GameObject player;
	PlayerMove2 playerMovement;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		playerMovement = player.GetComponent<PlayerMove2>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		player.GetComponent<PlayerMove2>().SetWindBoostState (true);
		Debug.Log ("Activate Wind boost");
	}

	void OnTriggerExit(Collider col) {
		player.GetComponent<PlayerMove2>().SetWindBoostState(false);
	}
}
