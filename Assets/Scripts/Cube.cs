using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using felixro;

public class Cube : MonoBehaviour
{    
    private Weight weight;
    private bool isObstacle;

    private List<Cube> neighbours;
    private Renderer renderer;

    public void Awake()
    {
        weight = new Weight(1, this);
        isObstacle = false;

        neighbours = new List<Cube>();
        renderer = GetComponent<Renderer>();
    }

    public void PaintCube(Color color)
    {
        renderer.material.color = color;
    }

    public void AddNeighbour(Cube cube, bool canWalkThroughObstacles)
    {
        if (!cube.isObstacle || canWalkThroughObstacles)
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
        this.weight.SetWeight(weight);
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

    public Weight GetWeight()
    {
        return weight;
    }

    public void SetWeight(int weight)
    {
        this.weight.SetWeight(weight);
    }
}
