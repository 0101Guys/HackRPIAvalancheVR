using UnityEngine;
using System.Collections;

public class SphereRotate : MonoBehaviour {

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * Random.Range (5,145));
	}
}
