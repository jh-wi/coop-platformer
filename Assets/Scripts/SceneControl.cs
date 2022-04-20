//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void NextScene(){
        SceneManager.LoadScene("main");
    }
    public void goBack(){
        SceneManager.LoadScene("Start Menu");
    }

    public void CreditScene(){
        SceneManager.LoadScene("Credits");
    }
}
