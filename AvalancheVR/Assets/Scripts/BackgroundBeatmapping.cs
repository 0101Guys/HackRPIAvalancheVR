using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundBeatmapping : MonoBehaviour {
	
	private float bpm = 130f;
	private float offset = 0f;
	public float pulseTimer;

	private int maxSpheres = 30;

	public List<GameObject> bgSpheres = new List<GameObject>();
	private List<Color> colors = new List<Color>();
	// Use this for initialization
	void Start () {
		pulseTimer = 0.46153846f + offset;
		
		colors.Add (Color.red);
		colors.Add (Color.blue);
		colors.Add (Color.yellow);
		colors.Add (Color.cyan);
		colors.Add (Color.green);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		pulseTimer -= Time.deltaTime;
		if (pulseTimer < 0) {
			Pulse ();
			pulseTimer = 0.46153846f;
		}
	}
	
	public void AddToBeatmapList(GameObject sphere) {
		bgSpheres.Add (sphere);
		if (bgSpheres.Count > maxSpheres) {
			Destroy (bgSpheres[0]);
			bgSpheres.RemoveAt (0);
		}
	}
	
	private void Pulse() {
		Debug.Log ("Pulse");
		int index = Random.Range (0, 5);
		foreach (GameObject sphere in bgSpheres) {
			Debug.Log ("change sphere in list");	
			sphere.renderer.material.SetColor("_TintColor", colors[index]);
		}
	}
}
