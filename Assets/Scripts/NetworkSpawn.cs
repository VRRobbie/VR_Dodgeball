using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSpawn : NetworkBehaviour {

	public GameObject dodgeballPrefab;
	public Transform spawnpoint;

	public override void OnStartServer()
	{
		var dodgeball = (GameObject)Instantiate (dodgeballPrefab, spawnpoint.position, spawnpoint.rotation);
		NetworkServer.Spawn (dodgeball);
	}
}
