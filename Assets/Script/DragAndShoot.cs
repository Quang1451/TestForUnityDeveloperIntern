using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private int curBounces = 0;
    private int maxBounces = 6;
    private Rigidbody rb;
    private bool mouseDown = false;
    private GameOver gameOver;

    Vector3 Force;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOver = FindObjectOfType<GameOver>();
        if (gameOver == null)
        {
            Debug.LogError("gameOver component not found.");
        }
    }

     private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(-(mouseReleasePos - mousePressDownPos));
    }

    private float forceMultiplier = 6f;
    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;

        rb.AddForce(new Vector3(Force.x, 0, Force.y) * forceMultiplier);
        isShoot = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider>() != null)
        {
            if (curBounces > maxBounces)
                gameOver.HandleGameOver();
                //curBounces++;
            else
                curBounces++;
        }
    }

    public Vector3 ShootPosition()
    {
        return rb.position;
    }

    public Vector3 ShootVelocity()
    {
        Vector3 Force = -(Input.mousePosition - mousePressDownPos);
        return new Vector3(Force.x, 0, Force.y) * forceMultiplier;
    }

    public bool isMouseDown()
    {
        return mouseDown;
    }

    public bool checkShoot()
    {
        return isShoot;
    }


}