using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeightText : MonoBehaviour 
{
    Text textComponent;

    void Start() {
        textComponent = GetComponent<Text>();
    }

    public void SetSliderValue(float sliderValue) 
    {
        textComponent.text = "Weight (" + sliderValue + ")";
    }
}
