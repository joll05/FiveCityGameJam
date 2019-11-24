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
    public float SpeedDecrease = 1f;

    public GameObject lvl_1;
    public GameObject lvl_2;
    public GameObject lvl_3;

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

        if(SpeedMultiplier > 1)
        {
            SpeedMultiplier -= SpeedDecrease * Time.fixedDeltaTime;
        }
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            Camera.main.GetComponent<CameraScript>().currentLvl += 1;

            if (Camera.main.GetComponent<CameraScript>().currentLvl == 2)
            {
                lvl_1.SetActive(false);
                lvl_2.SetActive(true);
            }
            if (Camera.main.GetComponent<CameraScript>().currentLvl == 3)
            {
                lvl_2.SetActive(false);
                lvl_3.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ScoreManager.ChangeScore(30);
            SpeedMultiplier += (2 - SpeedMultiplier) * 0.5f;
        }
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
