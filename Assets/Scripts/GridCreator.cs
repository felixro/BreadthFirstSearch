using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridCreator : MonoBehaviour 
{
    public GameObject cubePrefab;
    public ColorPicker colorPicker;

    public Cube[,] cubes;

    public int width = 20;
    public int height = 20;

    public float offset = 0.01f;

    private static Cube curStartCube;
    private static Cube curEndCube;

    private Transform cubeTransform;

    public void Awake()
    {
        cubeTransform = transform.FindChild("Cubes");
        BuildGrid();
    }

    public void BuildGrid()
    {
        curStartCube = null;
        curEndCube = null;

        Cleanup();

        cubes = new Cube[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++) 
            {
                GameObject instantiated = (GameObject)Instantiate(cubePrefab, new Vector3(i + i * offset, 0, j + j * offset), Quaternion.identity);
                Cube curCube = instantiated.GetComponent<Cube>();
                curCube.PaintCube(colorPicker.GetOriginalColor());

                instantiated.transform.SetParent(cubeTransform);

                cubes[i,j] = curCube;
            }
        }

        SetStartCube(cubes[width/2, height/2]);
        SetEndCube(cubes[width/3, height/3]);
    }
       
    private void Cleanup()
    {
        List<GameObject> toDelete = new List<GameObject>();

        foreach(Transform child in cubeTransform) 
        {
            toDelete.Add(child.gameObject);
        }

        toDelete.ForEach(delegate(GameObject obj)
        {
            Destroy(obj);
        });
    }

    public void AddNeighbours()
    {
        if (cubes.Length == 0)
        {
            Debug.Log("No cubes found");

            return;
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++) 
            {
                Cube curCube = cubes[i,j];

                if (i > 0)
                {
                    curCube.AddNeighbour(cubes[i-1,j]);
                }
                if (j > 0)
                {
                    curCube.AddNeighbour(cubes[i,j-1]);
                }
                if (i < width - 1)
                {
                    curCube.AddNeighbour(cubes[i+1,j]);
                }
                if (j < height - 1)
                {
                    curCube.AddNeighbour(cubes[i,j+1]);
                }
            }
        }
    }

    public void SetStartCube(Cube cube)
    {
        if (curStartCube)
        {
            Renderer renderer = curStartCube.GetComponent<Renderer>();
            renderer.material.color = colorPicker.GetOriginalColor();
        }

        curStartCube = cube;

        {
            Renderer renderer = curStartCube.GetComponent<Renderer>();
            renderer.material.color = colorPicker.GetStartColor();
        }
    }

    public void SetEndCube(Cube cube)
    {
        if (curEndCube)
        {
            Renderer renderer = curEndCube.GetComponent<Renderer>();
            renderer.material.color = colorPicker.GetOriginalColor();
        }

        curEndCube = cube;

        {
            Renderer renderer = curEndCube.GetComponent<Renderer>();
            renderer.material.color = colorPicker.GetEndColor();
        }
    }

    public Cube GetStartCube()
    {
        return curStartCube;
    }

    public Cube GetEndCube()
    {
        return curEndCube;
    }
}
