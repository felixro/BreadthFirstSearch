using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BFSPathfinding : MonoBehaviour 
{
    public GridCreator gridCreator;
    public ColorPicker colorPicker;

    private Queue<Cube> frontier;
    private Dictionary<Cube, Cube> cameFrom;
    private List<Cube> path;

    public void StartBFS()
    {
        frontier = new Queue<Cube>();
        cameFrom = new Dictionary<Cube, Cube>();

        gridCreator.AddNeighbours();

        RunBFS();
    }
        
    public void StopBFS()
    {
        StopAllCoroutines();
    }

    private void RunBFS()
    {
        Cube start = gridCreator.GetStartCube();
        Cube end = gridCreator.GetEndCube();

        frontier.Enqueue(start);
        cameFrom.Add(start, null);

        Cube current = null;
        while (frontier.Count != 0)
        {
            current = frontier.Dequeue();

            if (current == end)
            {
                break;
            }

            List<Cube> neighbours = current.GetNeighbours();
            neighbours.ForEach(delegate(Cube next)
            {
                if (!cameFrom.ContainsKey(next))
                {
                    frontier.Enqueue(next);
                    cameFrom.Add(next, current);
                    if (gridCreator.GetEndCube() != next)
                    {
                        next.PaintCube(colorPicker.GetVisitedColor());
                    }
                }
            });
        }

        CalculatePath();
    }

    private void CalculatePath()
    {
        Cube start = gridCreator.GetStartCube();
        Cube current = gridCreator.GetEndCube();
        path = new List<Cube>();

        path.Add(current);

        while (current != start)
        {
            current = cameFrom[current];
            path.Add(current);
        }

        path.Reverse();

        StartCoroutine("FollowPath");
    }

    IEnumerator FollowPath() 
    {
        for (int i = 0; i < path.Count; i++)
        {
            Cube cube = path[i];

            gridCreator.SetStartCube(cube);

            yield return new WaitForSeconds(.2f);
        }
    }
}
