using UnityEngine;
using UnityEngine.UI;

public class btn_test : MonoBehaviour
{
    public GameObject settingCanvas; // ���� ĵ���� GameObject

    void Start()
    {
        // ���� ĵ������ ó������ ��Ȱ��ȭ ���·� ����ϴ�.
        settingCanvas.SetActive(false);
    }

    public void ShowSettingCanvas()
    {
        Debug.Log("gkgk");
        // ��ư Ŭ�� �� ����Ǵ� �Լ�
        // ���� ĵ������ Ȱ��ȭ ���·� ��ȯ�մϴ�.
        settingCanvas.SetActive(true);
    }
}
