using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : Interactable {
	
	[SerializeField] GameObject interactParticles;
	[SerializeField] float magnetForce = 1;
	
	Rigidbody2D rb;

	Coroutine followRoutine;
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	protected override void OnInteract(ObstacleController obsCtrl) {
		if (obsCtrl.playerType == ObstacleController.PlayerType.Bear) {
			rb.bodyType = RigidbodyType2D.Dynamic;
			GameObject particles = Instantiate(interactParticles, transform.position, Quaternion.identity);
			Destroy(particles, 5);
			followRoutine = StartCoroutine(FollowBear(obsCtrl));
		} else {
			//TODO: put glasses on bear
			StopAllCoroutines();
			transform.SetParent(obsCtrl.transform);
			//rb.bodyType = RigidbodyType2D.Kinematic;
			Destroy(rb);
			transform.localPosition = Vector3.back;
		}
	}
	
	IEnumerator FollowBear(ObstacleController obsCtrl) {
		while (true) {
			yield return null;
			rb.AddForce((obsCtrl.transform.position - transform.position) * magnetForce);
		}
	}
	
}
