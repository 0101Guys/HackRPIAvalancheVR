using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour 
{
    public Transform block_prefab;
	public Transform beatBox_prefab;
    public float spawn_square_width = 10;
	public int c;

    public float width_min = 2, width_max = 3;

    public float spawn_time_max = 2f, spawn_time_min = 0.5f;
    private float spawn_timer;

	private float upSpeed = 2f;
	private Color[] blockAccentColors = new Color[5];
	private int changeAfterXBlocks = 10;
	private int colorIndex = 0;

    public void Start()
    {
        SetTimer();
		//Set Colors
        blockAccentColors[0] = new Color(0.33f, 0.21f, 0.94f, 1);
        blockAccentColors[1] = Color.red;
		blockAccentColors[2] = Color.green;
        blockAccentColors[3] = Color.yellow;
		blockAccentColors[4] = Color.cyan;

        Prewarm();
    }

    private void Prewarm()
    {
        float time_step = 0.02f;

        for (int i = 0; i < 60f * 40f; ++i)
        {
            spawn_timer -= time_step;

            // spawn    
            if (spawn_timer <= 0)
            {
                SpawnBlock();

                // color change
                changeAfterXBlocks -= 1;
                if (changeAfterXBlocks < 0)
                {
                    changeAfterXBlocks = 10;
                    IncreaseColorIndex();
                }

                SetTimer();
            }

            // move the spawner
            transform.Translate(Vector3.up * Time.deltaTime * upSpeed);
        }
    }

    public void Update()
    {
        spawn_timer -= Time.deltaTime;

        // spawn
        if (spawn_timer <= 0)
        {
            SpawnBlock();

            // color change
			changeAfterXBlocks -= 1;
			if (changeAfterXBlocks < 0) {
				changeAfterXBlocks = 10;
				IncreaseColorIndex();
			}
				
            SetTimer();
        }

        // move the spawner
		transform.Translate (Vector3.up * Time.deltaTime * upSpeed);
    }

	private void SpawnBlock()
	{
		float w = spawn_square_width / 2f;
		float x = Random.Range(transform.position.x - w, transform.position.x + w);
		float z = Random.Range(transform.position.z - w, transform.position.z + w);
		Vector3 pos = new Vector3(x, transform.position.y, z);
		
		float spawnDiff =  Random.Range (0.0f, 1.0f);
		Transform block;
		if (spawnDiff < .95f)
			block = (Transform)Instantiate(block_prefab, pos, Quaternion.identity);
		else
			block = (Transform)Instantiate (beatBox_prefab, pos, Quaternion.identity);
		
		float scale = Random.Range(width_min, width_max);
		block.transform.localScale = new Vector3(scale, scale, scale);
		
		if (spawnDiff >= .95f)
			block.gameObject.GetComponent<BeatBox>().startingScaleX = scale;
		/*c = Random.Range (0, 5);
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
		default: break;*/
		
		if (spawnDiff < .95f)
			block.transform.renderer.material.color = blockAccentColors[colorIndex];
		
	}

	private void IncreaseColorIndex() {
		colorIndex += 1;
		if (colorIndex > blockAccentColors.Length-1) {
			colorIndex = 0;
		}
	}
    private void SetTimer()
    {
        spawn_timer = Random.Range(spawn_time_min, spawn_time_max);
    }
}
