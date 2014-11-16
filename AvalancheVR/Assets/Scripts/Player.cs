using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    private float start_height = 0;


    public void Start()
    {
        start_height = transform.position.y;
    }

    public void Kill()
    {
        GameManager.LoadDeadScreen();
    }

    public float GetHeight()
    {
        return transform.position.y - start_height;
    }
	
}
