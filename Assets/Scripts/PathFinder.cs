using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using felixro;

public class PathFinder : MonoBehaviour 
{
    public GridCreator gridCreator;
    public ColorPicker colorPicker;

    private PriorityQueue<Cube> frontier;
    private Dictionary<Cube, Cube> cameFrom;
    private Dictionary<Cube, int> costSoFar;
    private List<Cube> path;

    public void StartBFS()
    {
        frontier = new PriorityQueue<Cube>();
        cameFrom = new Dictionary<Cube, Cube>();
        costSoFar = new Dictionary<Cube, int>();

        gridCreator.AddNeighbours(true);

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
        costSoFar.Add(start, 0);

        Cube current = null;
        while (frontier.GetCount() != 0)
        {
            current = frontier.Dequeue();

            if (current == end)
            {
                break;
            }

            List<Cube> neighbours = current.GetNeighbours();
            neighbours.ForEach(delegate(Cube next)
            {
                int newCost = costSoFar[current] + next.GetWeight();

                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;

                    int priority = newCost + heuristic(end, next);

                    next.SetWeight(priority);

                    frontier.Enqueue(next);
                    cameFrom[next] = current;
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
            current.PaintCube(colorPicker.GetVisitedColor());
        }

        path.Reverse();

        StartCoroutine("FollowPath");
    }

    private int heuristic(Cube goal, Cube next)
    {
        float goalX = goal.transform.position.x;
        float goalY = goal.transform.position.y;

        float nextX = next.transform.position.x;
        float nextY = next.transform.position.y;

        return (int)(Mathf.Abs(goalX - nextX) + Mathf.Abs(goalY - nextY));
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
