using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeyManager : MonoBehaviour 
{	
	void Update () 
    {
        if(Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("main");
        }
	}
}
