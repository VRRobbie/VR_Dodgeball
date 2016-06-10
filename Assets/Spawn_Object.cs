using UnityEngine;
using System.Collections;

public class Spawn_Object : MonoBehaviour {


	public Transform spawnpoint;
	public GameObject spawnObject;

	void Start () 
	{
		Spawn ();
	}
	
	void Spawn ()
	{
		Instantiate (spawnObject, spawnpoint.position, spawnpoint.rotation);
	}
}
