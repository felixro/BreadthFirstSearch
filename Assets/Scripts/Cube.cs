using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour 
{    
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

    public void SetObstacle(Color color)
    {
        this.isObstacle = true;

        PaintCube(color);
    }

    public bool IsObstacle()
    {
        return isObstacle;
    }
}
