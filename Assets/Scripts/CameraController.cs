using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Transform playerTransform;
	Vector3 cameraUpdate;
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("_playerController").transform;
		transform.position = new Vector3(playerTransform.position.x+15,playerTransform.position.y+30,playerTransform.position.z-15);
	}
	
	// Update is called once per frame
	void Update () {
		cameraUpdate = new Vector3(playerTransform.position.x+15,playerTransform.position.y+30,playerTransform.position.z-15);
		transform.position = Vector3.Lerp(transform.position,cameraUpdate,0.3f);
	}
}
