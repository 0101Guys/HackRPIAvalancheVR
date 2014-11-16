using UnityEngine;
using System.Collections;

public class WindSpawner : MonoBehaviour {

	public GameObject[] windSpawnLocs;
	public GameObject windPrefab;
	private float moveSpeed = 3f;
	private float spawnTimer = 15f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
		if (spawnTimer < 0) {
			SpawnWind();
			spawnTimer = 10f;
		}
		spawnTimer -= Time.deltaTime;
	}

	void SpawnWind() {
		Debug.Log ("Spawn Wind");
		int location = Random.Range (0, 4);
		GameObject temp = (GameObject)GameObject.Instantiate (windPrefab, windSpawnLocs[location].transform.position, Quaternion.identity);
		temp.transform.Rotate (90, 0, 0);
	}

}
