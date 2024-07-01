using UnityEngine;
using UnityEngine.UI;

public class btn_test : MonoBehaviour
{
    public GameObject settingCanvas; // 설정 캔버스 GameObject

    void Start()
    {
        // 설정 캔버스를 처음에는 비활성화 상태로 만듭니다.
        settingCanvas.SetActive(false);
    }

    public void ShowSettingCanvas()
    {
        Debug.Log("gkgk");
        // 버튼 클릭 시 실행되는 함수
        // 설정 캔버스를 활성화 상태로 전환합니다.
        settingCanvas.SetActive(true);
    }
}
