using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{

    public int numSticks = 0;
    private Ladder ladder;
    void Start()
    {
        ladder = GameObject.FindObjectOfType<Ladder> ();  
    }

    void Update()
    {
        if(numSticks == 5) {
            ladder.showLadder(true);
        }
        
    }

    public void OnGetStick() {
		numSticks=numSticks+1;
        Debug.Log(numSticks);
	}
}
