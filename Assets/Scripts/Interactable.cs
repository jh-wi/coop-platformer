using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
	
	protected bool birdInteracted = false;
	protected bool bearInteracted = false;
	
	void OnTriggerEnter2D(Collider2D col) {
		ObstacleController obsCtrl = col.GetComponent<ObstacleController>();
		if (obsCtrl != null) {
			ObstacleController.PlayerType playerType = obsCtrl.playerType;
			if (playerType == ObstacleController.PlayerType.Bird && !birdInteracted) {
				OnInteract(obsCtrl);
				birdInteracted = true;
			} else if (playerType == ObstacleController.PlayerType.Bear && !bearInteracted) {
				OnInteract(obsCtrl);
				bearInteracted = true;
			}
		}
	}
	
	protected abstract void OnInteract(ObstacleController obsCtrl);
	
}
