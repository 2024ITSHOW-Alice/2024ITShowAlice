using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Happy_set : MonoBehaviour
{
    public Button set_btn3; // �Ͻ� ���� ��ư
    public Button x_btn3; // �簳 ��ư
    public Button return_btn3; // ó������ ���� ��ư

    public GameObject menu3;
    public GameObject Opening;

    private bool isPaused = false; // ���� ���� �÷���

    private void Start()
    {
        set_btn3.onClick.AddListener(PauseGame3);
        x_btn3.onClick.AddListener(ResumeGame3);
        return_btn3.onClick.AddListener(ReturnGame3);
        menu3.SetActive(false);
    }

    private void PauseGame3()
    {
        menu3.SetActive(true);
        isPaused = true;
        Opening.GetComponent<Happytalk>().enabled = false;
        Debug.Log("����â Ŭ��");

    }

    private void ResumeGame3()
    {

        isPaused = false;
        menu3.SetActive(false);
        Opening.GetComponent<Happytalk>().enabled = true;
        Debug.Log("�ݱ� ��ư button was clicked!");

    }
    private void ReturnGame3()
    {
        Debug.Log("ó������ ���ư���");

        SceneManager.LoadScene("Main_Scene");
    }
}
