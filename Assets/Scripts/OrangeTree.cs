using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeTree : Interactable
{
	Rigidbody2D rb;
    GameObject treeGate;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;


    // Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody2D>();
        treeGate = GameObject.Find("OrangeTree");
	}

    void ChangeSprite()
    {
         spriteRenderer.sprite = newSprite; 
    }

    public void Open() {
        Debug.Log("open called");
        //transform.Rotate(180f, 0f, 0f); //flip the sprite
        ChangeSprite();
    }

    protected override void OnInteract(ObstacleController obsCtrl) {
            //do nothing
	}
}


	

