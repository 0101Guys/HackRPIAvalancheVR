using UnityEngine;
using System.Collections;

public class DeadScreen : MonoBehaviour 
{
    public TextMesh score_text;

    public void Start()
    {
        score_text.text = GameManager.GetFinalClimbHeight().ToString() + "m";
    }
}
