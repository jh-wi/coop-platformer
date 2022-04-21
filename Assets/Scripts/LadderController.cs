using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{

    public int numSticks = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numSticks == 1) {

        }
        
    }

    public void OnGetStick() {
		numSticks=numSticks+1;
        Debug.Log(numSticks);
	}
}
