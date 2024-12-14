using UnityEngine;

public class ClickDetection : MonoBehaviour // works 
{
    private Camera cam;
    public void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        LookForUnit();
    }
    public void UnitSelected(Vector2 coordinates)
    {
        GlobalEvents<Vector2>.coordinates.Execute(coordinates);
        GlobalEvents<bool>.tiles.Execute(true);
    }
    public void TileSelected()
    {
        GlobalEvents<bool>.tiles.Execute(false);
    }
    public void LookForUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hits = Physics2D.GetRayIntersection(ray);
            if (hits != false)
            {
                Vector2 coordinates = hits.collider.transform.position;

                if (hits.collider.attachedRigidbody != null)
                    UnitSelected(coordinates);
                else
                {
                    TileSelected();
                }
            }
        }

    }
}

