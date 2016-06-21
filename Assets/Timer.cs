using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float time = 90.0f;
	TextMesh textNum;
	int minutes;
	int seconds;
	// Use this for initialization
	void Start () 
	{
		textNum = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		minutes = (int)time / 60;
		seconds = (int)time % 60;
		if (time > 0) 
		{
			time -= Time.deltaTime;
			if (seconds < 10) 
			{
				textNum.text = "" + minutes + ":0" + seconds;
			} else 
			{
				textNum.text = "" + minutes + ":" + seconds;
			}
		}
	}
}
