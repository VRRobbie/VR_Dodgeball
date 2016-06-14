using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class ShaderChange : NetworkBehaviour {


	public Shader highlight;
	public GameObject bullet;

	// Update is called once per frame
	void Update () {
		highlight = Shader.Find("Highlight");
		bullet.GetComponent<Renderer> ().material.shader = highlight;
	}
}
