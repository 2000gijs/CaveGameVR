using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour {

	public float objectsstored;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "MiniOre") {
			objectsstored++;
			Destroy(collision.gameObject);
		}
	}

	

}
