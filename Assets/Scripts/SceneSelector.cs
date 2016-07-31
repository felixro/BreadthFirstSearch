using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour 
{
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
