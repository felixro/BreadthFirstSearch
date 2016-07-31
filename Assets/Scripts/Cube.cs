using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using felixro;

public class Cube : MonoBehaviour , IComparable<Cube>
{    
    private int weight;
    private bool isObstacle;

    private List<Cube> neighbours;
    private Renderer objRenderer;

    public void Awake()
    {
        weight = 1;
        isObstacle = false;

        neighbours = new List<Cube>();
        objRenderer = GetComponent<Renderer>();
    }

    public void PaintCube(Color color)
    {
        objRenderer.material.color = color;
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
        this.weight = weight;
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

    public int GetWeight()
    {
        return weight;
    }

    public void SetWeight(int weight)
    {
        this.weight = weight;
    }

    public int CompareTo(Cube obj) 
    {
        if (obj == null)
        {
            throw new ArgumentNullException();
        };

        int otherWeight = ((Cube)obj).GetWeight();

        if (weight == otherWeight)
        {
            return 0;
        }

        if (weight > otherWeight)
        {
            return 1;
        }

        return -1;
    }
}
