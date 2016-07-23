using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour 
{	
    public GridCreator gridCreator;
    private bool isAddingObstacle = false;

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            CheckTouched(MouseButton.LEFT);
        }
        else if (Input.GetMouseButton(1))
        {
            CheckTouched(MouseButton.RIGHT);    
        }
	}

    void CheckTouched(MouseButton type)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Cube hitCube = hit.collider.gameObject.GetComponent<Cube>();

            if(isAddingObstacle)
            {
                hitCube.SetObstacle(true);
            }
            else if (type == MouseButton.LEFT)
            {
                gridCreator.SetStartCube(hitCube);
            }
            else if (type == MouseButton.RIGHT)
            {
                gridCreator.SetEndCube(hitCube);
            }
        }
    }

    public void ToggleObstacleCreation()
    {
        isAddingObstacle = !isAddingObstacle;
    }

    enum MouseButton
    {
        LEFT, RIGHT
    }
}
