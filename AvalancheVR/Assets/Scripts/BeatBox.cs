using UnityEngine;
using System.Collections;

public class BeatBox : MonoBehaviour {

	private float bpm = 130f;
	private float offset = 0f;
	public float pulseUpTimer;
	public float pulseDownTimer;
	private float lastColorIndex = 0;

	private bool pulseUp = true;
	private bool started = true;

	public float startingScaleX = 1f;

	// Use this for initialization
	void Start () {
		GameObject bm = GameObject.FindGameObjectWithTag("beatmapper");
		if (bm) {
			pulseUpTimer = bm.GetComponent<BackgroundBeatmapping>().pulseTimer;
			Debug.Log ("Start pulse timer = " + pulseUpTimer);
			pulseDownTimer = 0.76153846f;
		}
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!started && pulseUpTimer < 0f) {
			started = true;
			pulseUp = true;
			pulseUpTimer = 0.08076923f;
		}

		if (started && pulseUp) {
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.1f * startingScaleX, 1.1f * startingScaleX, 1.1f * startingScaleX), 0.08076923f);
			pulseUpTimer -= Time.deltaTime;
			//transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
		}

		if (started && !pulseUp) {
			transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(1.0f * startingScaleX, 1.0f * startingScaleX, 1.0f * startingScaleX), 0.38076923f);
			pulseDownTimer -= Time.deltaTime;
			//transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}

		if (started && pulseUpTimer < 0f) {
			pulseUp = !pulseUp;
			pulseUpTimer = 0.08076923f;
		}

		if (started && pulseDownTimer < 0f) {
			pulseUp = !pulseUp;
			pulseDownTimer = 0.38076923f;
		}

	}
}
