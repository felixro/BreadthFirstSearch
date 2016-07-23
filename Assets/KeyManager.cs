using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour 
{	
	void Update () 
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Application.LoadLevel("main");
        }
	}
}
