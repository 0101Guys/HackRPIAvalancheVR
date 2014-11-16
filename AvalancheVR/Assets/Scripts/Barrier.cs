using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{

    public float speed = 0.5f;
    private float player_height_req = 3;
    public PlayerMove playermove;
    private bool move = false;


	public void Update()
    {

        if (move)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            if (playermove.GetMaxHeightClimbed() > player_height_req)
                move = true;
        }
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {   
            Player p = collider.GetComponent<Player>();
            p.Kill();
           
        }
    }
}
