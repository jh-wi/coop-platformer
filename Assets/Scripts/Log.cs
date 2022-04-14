using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Interactable {
	
	[SerializeField] GameObject interactParticles;
	[SerializeField] float magnetForce = 1;
	
	Rigidbody2D rb;

	Coroutine followRoutine;
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	protected override void OnInteract(ObstacleController obsCtrl) {
		if (obsCtrl.playerType == ObstacleController.PlayerType.Bear) {
			Debug.Log("Player Bear is interacting");
			rb.bodyType = RigidbodyType2D.Dynamic;
			//GameObject particles = Instantiate(interactParticles, transform.position, Quaternion.identity);
			//Destroy(particles, 5);
			followRoutine = StartCoroutine(FollowBear(obsCtrl));
		}
	}
	
	IEnumerator FollowBear(ObstacleController obsCtrl) {
		while (true) {
			yield return null;
			rb.AddForce((obsCtrl.transform.position - transform.position) * magnetForce);
		}
	}
	
}
