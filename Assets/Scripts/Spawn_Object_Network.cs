using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Spawn_Object_Network : NetworkBehaviour {


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
		//NetworkServer.Spawn (spawnObject);
	}
}
