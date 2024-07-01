using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DigSet_end : MonoBehaviour
{
    public Button set_btn; // �Ͻ� ���� ��ư
    public Button x_btn; // �簳 ��ư
    public Button return_btn; // ó������ ���� ��ư

    public GameObject menu;
    public GameObject Dialog;

    private bool isPaused = false; // ���� ���� �÷���

    private void Start()
    {
        set_btn.onClick.AddListener(PauseGame);
        x_btn.onClick.AddListener(ResumeGame);
        return_btn.onClick.AddListener(ReturnGame);
        menu.SetActive(false);
    }

    private void PauseGame()
    {
        menu.SetActive(true);
        isPaused = true;
        Dialog.GetComponent<happy3>().enabled = false;
        Debug.Log("����â Ŭ��");

    }

    private void ResumeGame()
    {

        isPaused = false;
        menu.SetActive(false);
        Dialog.GetComponent<happy3>().enabled = true;
        Debug.Log("�ݱ� ��ư button was clicked!");

    }
    private void ReturnGame()
    {
        Debug.Log("ó������ ���ư���");

        SceneManager.LoadScene("Main_Scene");
    }
}
