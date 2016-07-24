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

    public void SetObstacle(Color color, int weight)
    {
        this.isObstacle = true;

        PaintCube(color);

        // returns the textmesh even for disabled components
        TextMesh mesh = GetComponentInChildren<TextMesh>(true);
        mesh.text = "" + weight;
    }

    public bool IsObstacle()
    {
        return isObstacle;
    }
}
