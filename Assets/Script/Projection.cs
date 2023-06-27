using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    LineRenderer lineRenderer;
    private DragAndShoot dragAndShoot;
    private int numOfPoint = 50;
    private float distanceBetweenPoint = 1f;

    //public LayerMask CollidableLayer;
    int layerMask;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        dragAndShoot = GetComponent<DragAndShoot>();
        if (dragAndShoot == null)
        {
            Debug.LogError("DragAndShoot component not found.");
        }
        layerMask = LayerMask.GetMask("CollidableLayer");
    }

    void Update()
    {
        if (dragAndShoot.isMouseDown() && !(dragAndShoot.checkShoot()))
        {
            lineRenderer.positionCount = (int)numOfPoint;
            List<Vector3> points = new List<Vector3>();
            Vector3 startingPosition = dragAndShoot.ShootPosition();
            Vector3 startingVelocity = dragAndShoot.ShootVelocity();

            for (float i = 0; i < numOfPoint; i += distanceBetweenPoint)
            {
                Vector3 newPoint = startingPosition + i * startingVelocity;
                // newPoint.y = 0;
                points.Add(newPoint);

                /*if (Physics.OverlapSphere(newPoint, 2, layerMask).Length > 0)
                {
                    lineRenderer.positionCount = points.Count;
                    break;
                }*/
            }
            lineRenderer.SetPositions(points.ToArray());
        }
        else if (dragAndShoot.checkShoot())
        {
            lineRenderer.enabled = false;
        }
    }
}