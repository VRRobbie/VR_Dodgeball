﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
	public GameObject capsulePlayer;
	public GameObject glassesPlayer;
    public Behaviour[] componentsToDisable;
    //Camera sceneCamera;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) {
            for(int i = 0; i < componentsToDisable.Length; i++) {
                componentsToDisable[i].enabled = false;
            }
        }
			
//		else {
//            sceneCamera = Camera.main;
//            print("Camera turning off: " + sceneCamera.name);
//            if(sceneCamera != null)
//               sceneCamera.gameObject.SetActive(false);
//        }
	}

	public override void OnStartLocalPlayer()
	{
		capsulePlayer.GetComponent<MeshRenderer> ().enabled = false;
		glassesPlayer.GetComponent<MeshRenderer> ().enabled = false;

	}

//    void Update() {
//        if (sceneCamera != null && !sceneCamera.gameObject.activeSelf){
//            sceneCamera.gameObject.SetActive(true);
//        }
//    }
}
