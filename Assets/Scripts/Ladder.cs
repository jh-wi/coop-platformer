using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    //[SerializeField] int numSticks;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find ("Ladder").transform.localScale = new Vector3(0, 0, 0);
    }
    public void showLadder(bool show) {
         GameObject.Find ("Ladder").transform.localScale = new Vector3(1, 1, 1);
    }
}



