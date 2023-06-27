using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLvBtn : MonoBehaviour
{
    private Button nextLvBtn;

    void Start()
    {
        nextLvBtn = GameObject.Find("NextLevelBtn").GetComponent<Button>();
        nextLvBtn.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;
    }
}