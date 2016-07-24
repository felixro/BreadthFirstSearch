using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeightDisplay : MonoBehaviour
{
    private List<GameObject> numberObjects;

    public void Start()
    {
        numberObjects = new List<GameObject>();

        Transform[] cubeTransforms = GetComponentsInChildren<Transform>();

        for (int i = 0; i < cubeTransforms.Length; i++)
        {
            TextMesh mesh = cubeTransforms[i].GetComponentInChildren<TextMesh>();

            numberObjects.Add(mesh.gameObject);
        }

        ShowWeight(false);
    }

    public void ShowWeight(bool shouldShow)
    {
        numberObjects.ForEach(delegate(GameObject obj)
        {
            obj.SetActive(shouldShow);
        });
    }
}
