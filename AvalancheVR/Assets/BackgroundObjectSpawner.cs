using UnityEngine;
using System.Collections;

public class BackgroundObjectSpawner : MonoBehaviour 
{
	public Transform sphere_prefab;
	public Transform sphere_prefabx;
	public BlockSpawner bs;
	public float spawn_circle_width = 75;
	
	public float width_min = 3, width_max = 9;
	
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
		if (Random.Range (0, 1) == 0)
						b = true;
				else
						b = false;
		if (b)
			x = Random.Range(bs.transform.position.x + w + 12, bs.transform.position.x + w + 75);
		else
			x = Random.Range(bs.transform.position.x - w - 75, bs.transform.position.x - w - 12);
		if (Random.Range (0, 1) == 0)
			b = true;
		else
			b = false;
		if (b)
			z = Random.Range(bs.transform.position.z + w + 12, bs.transform.position.z + w + 75);
		else
			z = Random.Range(bs.transform.position.z + w - 75, bs.transform.position.z + w + 12);
		Vector3 pos = new Vector3(x, Random.Range (transform.position.y - 12, transform.position.y + 46), z);
		Transform sphere;

		if (Random.Range (0, 2) == 0)
			b = true;
		else
			b = false;
		Debug.Log(b);
		if(b)
			sphere = (Transform)Instantiate(sphere_prefab, pos, Quaternion.identity);
		else
			sphere = (Transform)Instantiate(sphere_prefabx, pos, Quaternion.identity);
		
		float scale = Random.Range(width_min, width_max);
		sphere.transform.localScale = new Vector3(scale, scale, scale);
	}
	private void SetTimer()
	{
		spawn_timer = Random.Range(spawn_time_min, spawn_time_max);
	}
}
