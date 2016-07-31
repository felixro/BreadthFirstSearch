using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using felixro;

public class BFSPathfinding : MonoBehaviour 
{
    public GridCreator gridCreator;
    public ColorPicker colorPicker;

    private PriorityQueue<Weight> frontier;
    private Dictionary<Cube, Cube> cameFrom;
    private Dictionary<Cube, int> costSoFar;
    private List<Cube> path;

    public void StartBFS()
    {
        frontier = new PriorityQueue<Weight>();
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

        frontier.Enqueue(start.GetWeight());
        cameFrom.Add(start, null);
        costSoFar.Add(start, 0);

        Cube current = null;
        while (frontier.GetCount() != 0)
        {
            current = frontier.Dequeue().GetCube();

            if (current == end)
            {
                break;
            }

            List<Cube> neighbours = current.GetNeighbours();
            neighbours.ForEach(delegate(Cube next)
            {
                int newCost = costSoFar[current] + next.GetWeight().GetWeight();

                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;

                    Weight newWeight = new Weight(newCost, next);

                    frontier.Enqueue(newWeight);
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
