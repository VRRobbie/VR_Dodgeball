using UnityEngine;
using System.Collections;

public class Spawn_Object : MonoBehaviour {


	public Transform spawnpoint;
	public GameObject spawnObject;
	public int waitSeconds;

	void Start () 
	{
		StartCoroutine (Spawn ());
	}
	
	IEnumerator Spawn ()
	{
		yield return new WaitForSeconds(waitSeconds);
		Instantiate (spawnObject, spawnpoint.position, spawnpoint.rotation);
	}
}
