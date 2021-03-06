using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
 	Rigidbody2D rb;
	GameObject treeGate;
	public OrangeTree tree;
	public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

	Coroutine openRoutine;
	
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		treeGate = GameObject.Find("OrangeTree");
	}

	protected override void OnInteract(ObstacleController obsCtrl) {
		if (obsCtrl.playerType == ObstacleController.PlayerType.Bear) {
			//rb = GetComponent<Rigidbody2D>();
			spriteRenderer.sprite = newSprite;
			openRoutine = StartCoroutine(OpenGate(obsCtrl));
		} else {
			//add something for it to barely move, so the player can tell they're not pushing hard enough

			//Destroy(rb);
		}
	}

	IEnumerator OpenGate(ObstacleController obsCtrl) {
		while (true) {
			//treeGate.GetComponent<OrangeTree>().Open(); 
			tree.Open();
			tree.GetComponent<Collider2D>().enabled = false;
			yield return null;
		}
	}
}
