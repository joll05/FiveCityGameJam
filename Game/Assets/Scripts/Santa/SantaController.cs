using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SantaController : MonoBehaviour
{
    public static SantaController instance;
    
    [Tooltip("Set this to the parent of all the points.")]
    public Transform points;
    
    public float WalkingSpeed = 1f;
    public float RotationSpeed = 1f;
    public float SpeedMultiplier = 1f;
    
    public SantaState state;

    Rigidbody rb;
    Path path;
    int currentPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        Vector3[] positions = new Vector3[points.childCount];

        for (int i = 0; i < points.childCount; i++)
        {
            Transform point = points.GetChild(i);
            positions[i] = point.position;
        }        

        path = new Path(positions);
        Destroy(points.gameObject);

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveSanta();
        RotateSanta();
    }

    void MoveSanta()
    {
        if (state != SantaState.Moving) return;

        Vector3 direction = path.points[currentPoint] - transform.position;
        direction.Normalize();

        rb.MovePosition(rb.position + direction * WalkingSpeed * SpeedMultiplier * Time.fixedDeltaTime);

        if (Vector3.Distance(rb.position, path.points[currentPoint]) < 0.05f)
        {
            currentPoint++;
            state = SantaState.Rotating;
        }
    }

    void RotateSanta()
    {
        if (state != SantaState.Rotating) return;

        Quaternion targetRotation = Quaternion.LookRotation(path.points[currentPoint] - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * SpeedMultiplier);

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f) state = SantaState.Moving;
    }
}

public enum SantaState
{
    Moving,
    Rotating,
    Trapped,
}

[System.Serializable]
public struct Path
{
    public readonly Vector3[] points;

    public readonly float length;

    public Path(Vector3[] points) : this()
    {
        //Set points
        this.points = points;

        //Calculate length
        this.length = 0;

        for (int i = 0; i < points.Length - 1; i++)
        {
            this.length += Vector3.Distance(points[i], points[i + 1]);
        }
    }
}
