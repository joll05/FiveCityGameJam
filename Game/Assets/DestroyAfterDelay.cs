using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float Time = 1;

    void Start()
    {
        Invoke("DestroySelf", Time);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
