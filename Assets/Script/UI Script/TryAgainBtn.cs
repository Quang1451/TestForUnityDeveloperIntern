using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryAgainBtn : MonoBehaviour
{
    private Button tryAgainBtn;
    void Start()
    {
        tryAgainBtn = GameObject.Find("TryAgainBtn").GetComponent<Button>();
        tryAgainBtn.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}