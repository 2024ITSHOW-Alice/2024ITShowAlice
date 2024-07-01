using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float gameTime = 130f; // 130�� ���� �ð�
    private float currentTime;
    public Text GameTimeText;

    private void Start()
    {
        currentTime = gameTime;
        UpdateTimeText();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime; // �ð� ����
        UpdateTimeText();

        if (currentTime <= 0)
        {
            // �ð��� 0 ���ϰ� �Ǹ� ���� ���� ������ �̵�
            SceneManager.LoadScene("Gamesuccess_Scene");
        }
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // �ð��� 0 ���ϰ� �Ǹ� "00:00"���� ǥ��
        if (currentTime <= 0)
        {
            GameTimeText.text = "00:00";
        }
        else
        {
            // 10�� ������ �� �ؽ�Ʈ ������ "#dd2a00"���� ����
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
