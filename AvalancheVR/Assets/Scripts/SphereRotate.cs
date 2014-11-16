using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereRotate : MonoBehaviour {

	private List<Color> colors = new List<Color>();
	// BackgroundBeatmapping bb;

	public Transform sp;
	private float bpm = 130f;
	private float offset = 0f;
	private float pulseTimer;

	// Use this for initialization
	public void Start () {
		//pulseTimer = GameObject.FindGameObjectWithTag("beatmapper").GetComponent<BackgroundBeatmapping>().pulseTimer;
		//bb = GameObject.FindGameObjectWithTag("beatmapper").GetComponent<Gr
		colors.Add (Color.red);
		colors.Add (Color.blue);
		colors.Add (Color.yellow);
		colors.Add (Color.cyan);
		colors.Add (Color.green);
	}
	
	// Update is called once per frame
	public void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * Random.Range (5,145));
		/*pulseTimer -= Time.deltaTime;
		if (pulseTimer < 0) {
			//Pulse ();
			pulseTimer = 0.46153846f;
		} */
	}

	/*private void Pulse() {
		Debug.Log ("Pulse");
		int index = Random.Range (0, 5);
		gameObject.renderer.material.SetColor("_TintColor", colors[index]);
	}*/
}
