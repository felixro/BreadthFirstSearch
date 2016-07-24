using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour 
{	
    public GridCreator gridCreator;
    public ColorPicker colorPicker;
    public WeightSelector weightSelector;

    private bool isAddingObstacle = false;

    private bool moveStart = true;

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            CheckTouched();
        }
	}

    void CheckTouched()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Cube hitCube = hit.collider.gameObject.GetComponent<Cube>();

            if(isAddingObstacle)
            {
                if (weightSelector)
                {
                    hitCube.SetObstacle(
                        weightSelector.GetCurrentWeightColor(),
                        weightSelector.GetCurrentWeight()
                    );
                }
                else
                {
                    hitCube.SetObstacle(colorPicker.GetObstacleColor(), 1);
                }

                return;
            }
                
            if (moveStart)
            {
                gridCreator.SetStartCube(hitCube);
            }
            else
            {
                gridCreator.SetEndCube(hitCube);   
            }
        }
    }

    public void ToggleObstacleCreation()
    {
        isAddingObstacle = !isAddingObstacle;
    }

    public void SetMoveStart(bool state)
    {
        moveStart = state;
    }
}
