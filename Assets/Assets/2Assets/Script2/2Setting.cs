using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting2 : MonoBehaviour
{
    public Button pauseButton2;
    public Button resumeButton2;
    public Button returnButton2;

    public GameObject menu2;

    public static Setting2 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        menu2.SetActive(false);

        pauseButton2.onClick.AddListener(PauseGame2);
        resumeButton2.onClick.AddListener(ResumeGame2);
        returnButton2.onClick.AddListener(ReturnGame2);
    }

    private void PauseGame2()
    {
        Debug.Log("PauseGame2");
        menu2.SetActive(true);
        Time.timeScale = 0f;
        pauseButton2.gameObject.SetActive(false);
    }

    private void ResumeGame2()
    {
        Debug.Log("ResumeGame2");
        menu2.SetActive(false);
        Time.timeScale = 1f;
        pauseButton2.gameObject.SetActive(true);
    }

    private void ReturnGame2()
    {
        Time.timeScale = 1f;
        Debug.Log("ReturnGame2");
        SceneManager.LoadScene("Main_Scene");
    }
}
