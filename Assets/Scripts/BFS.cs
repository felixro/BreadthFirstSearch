using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BFS : MonoBehaviour 
{
    public GridCreator gridCreator;
    public ColorPicker colorPicker;

    private Queue<Cube> frontier;
    private List<Cube> visited;

    public void StartBFS()
    {
        frontier = new Queue<Cube>();
        visited = new List<Cube>();

        gridCreator.AddNeighbours(false);

        StartCoroutine("RunBFS");
    }

    public void StopBFS()
    {
        StopAllCoroutines();
    }

    IEnumerator RunBFS() 
    {
        Cube start = gridCreator.GetStartCube();
        frontier.Enqueue(start);
        visited.Add(start);

        Cube current = null;
        while (frontier.Count != 0)
        {
            current = frontier.Dequeue();
            List<Cube> neighbours = current.GetNeighbours();
            neighbours.ForEach(delegate(Cube cube)
            {
                if (!visited.Contains(cube))
                {
                    frontier.Enqueue(cube);
                    visited.Add(cube);
                    cube.PaintCube(colorPicker.GetVisitedColor());
                }
            });

            yield return new WaitForSeconds(.1f);
        }
    }
}
