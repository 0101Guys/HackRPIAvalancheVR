using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour 
{
    public Transform block_prefab;
    public float spawn_square_width = 10;
	public int c;

    public float width_min = 2, width_max = 3;

    public float spawn_time_max = 2f, spawn_time_min = 0.5f;
    private float spawn_timer;

	private float upSpeed = 2f;

    public void Start()
    {
        SetTimer();
    }

    public void Update()
    {
        spawn_timer -= Time.deltaTime;

        if (spawn_timer <= 0)
        {
            SpawnBlock();
            SetTimer();
        }

		transform.Translate (Vector3.up * Time.deltaTime * upSpeed);
    }

    private void SpawnBlock()
    {
        float w = spawn_square_width / 2f;
        float x = Random.Range(transform.position.x - w, transform.position.x + w);
        float z = Random.Range(transform.position.z - w, transform.position.z + w);
        Vector3 pos = new Vector3(x, transform.position.y, z);
        Transform block = (Transform)Instantiate(block_prefab, pos, Quaternion.identity);

        float scale = Random.Range(width_min, width_max);
        block.transform.localScale = new Vector3(scale, scale, scale);
		c = Random.Range (0, 5);
		switch(c){
		case 0: block.transform.renderer.material.color = Color.red;
			break;
		case 1: block.transform.renderer.material.color = Color.green;
			break;
		case 2: block.transform.renderer.material.color = Color.blue;
			break;
		case 3: block.transform.renderer.material.color = Color.yellow;
			break;
		case 4: block.transform.renderer.material.color = Color.cyan;
			break;
		default: break;
		}
    }
    private void SetTimer()
    {
        spawn_timer = Random.Range(spawn_time_min, spawn_time_max);
    }
}
