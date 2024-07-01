using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float gameTime = 130f; // 130초 게임 시간
    private float currentTime;
    public Text GameTimeText;

    private void Start()
    {
        currentTime = gameTime;
        UpdateTimeText();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime; // 시간 감소
        UpdateTimeText();

        if (currentTime <= 0)
        {
            // 시간이 0 이하가 되면 게임 성공 씬으로 이동
            SceneManager.LoadScene("Gamesuccess_Scene");
        }
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // 시간이 0 이하가 되면 "00:00"으로 표시
        if (currentTime <= 0)
        {
            GameTimeText.text = "00:00";
        }
        else
        {
            // 10초 남았을 때 텍스트 색상을 "#dd2a00"으로 변경
            if (currentTime <= 10)
            {
                GameTimeText.color = new Color32(0xdd, 0x2a, 0x00, 0xff);
            }
            else
            {
                GameTimeText.color = Color.white;
            }

            GameTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
