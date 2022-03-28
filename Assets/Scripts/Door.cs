using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	
	[SerializeField] Collider2D solidCol;
	
	void OnTriggerEnter2D(Collider2D col) {
		BearController bear = col.GetComponent<BearController>();
		if (bear != null) {
			GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			Destroy(solidCol);
		}
	}
	
}
