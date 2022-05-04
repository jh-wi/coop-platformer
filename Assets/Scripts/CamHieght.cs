using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHieght : MonoBehaviour {
	public float y = 17;
	
    void Update() {
        if (transform.position.y > y) {
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
    }
}
