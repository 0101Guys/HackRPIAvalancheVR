﻿using UnityEngine;
using System.Collections;

public class BackgroundObjectSpawner : MonoBehaviour 
{
	public Transform sphere_prefab;
	public Transform sphere_prefabx;
	public BlockSpawner bs;
	public float spawn_circle_width = 75;
	
	public float width_min = 3, width_max = 9;
	public float inner_dist = 12, outer_dist = 75;
	
	private float spawn_time_max = 2f, spawn_time_min = 0.5f;
	private float spawn_timer;
	
	
	public void Start()
	{
		SetTimer();
	}
	
	public void Update()
	{
		spawn_timer -= Time.deltaTime;
		
		if (spawn_timer <= 0)
		{
			SpawnSphere();
			SetTimer();
		}
	}
	
	private void SpawnSphere()
	{
		float w = bs.spawn_square_width / 2f;
		bool b;
		float x, z;
		int c;
		Transform sphere;
		Vector3 pos;


		for (int i = 0; i < 5; i++) {
						if (Random.Range (0, 2) == 0)
								b = true;
						else
								b = false;
						if (b)
								x = Random.Range (bs.transform.position.x + w + inner_dist, bs.transform.position.x + w + outer_dist);
						else
				x = Random.Range (bs.transform.position.x - w - outer_dist, bs.transform.position.x - w - inner_dist);
						if (Random.Range (0, 2) == 0)
								b = true;
						else
								b = false;
						if (b)
								z = Random.Range (bs.transform.position.z + w + inner_dist, bs.transform.position.z + w + outer_dist);
						else
								z = Random.Range (bs.transform.position.z + w - outer_dist, bs.transform.position.z + w - inner_dist);
						pos = new Vector3 (x, Random.Range (transform.position.y - outer_dist, transform.position.y + outer_dist), z);
						

						if (Random.Range (0, 2) == 0)
								b = true;
						else
								b = false;
						if (b)
								sphere = (Transform)Instantiate (sphere_prefab, pos, Quaternion.identity);
						else {
								sphere = (Transform)Instantiate (sphere_prefabx, pos, Quaternion.identity);
								GameObject.FindGameObjectWithTag("beatmapper").GetComponent<BackgroundBeatmapping>().AddToBeatmapList(sphere.gameObject);
						}
		
						float scale = Random.Range (width_min, width_max);
						sphere.transform.localScale = new Vector3 (scale, scale, scale);
						c = Random.Range (0, 5);
				switch(c){
						case 0: sphere.transform.renderer.material.color = Color.red;
						break;
			case 1: sphere.transform.renderer.material.color = Color.green;
				break;
			case 2: sphere.transform.renderer.material.color = Color.blue;
				break;
			case 3: sphere.transform.renderer.material.color = Color.yellow;
				break;
			case 4: sphere.transform.renderer.material.color = Color.cyan;
				break;
			default: break;
			}
				}
	}
	private void SetTimer()
	{
		spawn_timer = Random.Range(spawn_time_min, spawn_time_max);
	}
}
