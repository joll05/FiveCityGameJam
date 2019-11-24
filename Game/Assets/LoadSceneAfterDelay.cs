using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterDelay : MonoBehaviour
{
    public float Delay = 15f;

    public int scene;

    void Start()
    {
        Invoke("Load", Delay);
    }

    void Load()
    {
        SceneManager.LoadScene(scene);
    }
}
