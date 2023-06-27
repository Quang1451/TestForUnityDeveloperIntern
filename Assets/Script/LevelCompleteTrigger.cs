using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    public Canvas nextLevelCanvas;
    public string nextSceneName;

    void Start()
    {
        nextLevelCanvas = GameObject.Find("NextLevelCanvas").GetComponent<Canvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            nextLevelCanvas.enabled = (true);
            Time.timeScale = 0f;
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
        Time.timeScale = 1f; 
    }
}