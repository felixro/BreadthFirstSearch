using UnityEngine;
using System.Collections;

public class SceneSelector : MonoBehaviour 
{
    public void LoadLevel(string name)
    {
        Application.LoadLevel(name);
    }
}
