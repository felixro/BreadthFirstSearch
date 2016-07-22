using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour 
{
    public ColorPicker colorPicker;
    
    private List<Cube> neighbours;
    private bool isObstacle;
    private Renderer renderer;

    public void Awake()
    {
        neighbours = new List<Cube>();
        renderer = GetComponent<Renderer>();
    }

    public void PaintCube(Color color)
    {
        renderer.material.color = color;
    }

    public void AddNeighbour(Cube cube)
    {
        if (!cube.isObstacle)
        {
            neighbours.Add(cube);
        }
    }

    public List<Cube> GetNeighbours()
    {
        return neighbours;
    }

    public void SetObstacle(bool isObstacle)
    {
        this.isObstacle = isObstacle;

        if(isObstacle)
        {
            PaintCube(colorPicker.GetObstacleColor());
        }
        else
        {
            PaintCube(colorPicker.GetOriginalColor());
        }
    }

    public bool IsObstacle()
    {
        return isObstacle;
    }
}
