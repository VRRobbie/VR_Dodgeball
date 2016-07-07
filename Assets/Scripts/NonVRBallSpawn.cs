using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NonVRBallSpawn : NetworkBehaviour 
{

    public GameObject dodgeballPrefab;
    public Transform dodgeballSpawn;
    public float throwForce;
	

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            CmdThrowBall();
        }
    }

    [Command]
    void CmdThrowBall()
        {
            var dodgeball = (GameObject)Instantiate (dodgeballPrefab, dodgeballSpawn.position, dodgeballSpawn.rotation);
            //bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 6;
            dodgeball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
            NetworkServer.Spawn (dodgeball);
        }
}
