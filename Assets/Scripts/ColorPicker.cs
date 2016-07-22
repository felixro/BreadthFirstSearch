using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour 
{
    public Color originalColor;
    public Color visitedColor;
    public Color startColor;
    public Color obstacleColor;

    public Color GetOriginalColor()
    {
        return originalColor;
    }

    public Color GetVisitedColor()
    {
        return visitedColor;
    }

    public Color GetStartColor()
    {
        return startColor;
    }

    public Color GetObstacleColor()
    {
        return obstacleColor;
    }
}
