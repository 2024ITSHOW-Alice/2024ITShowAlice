using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Showani : MonoBehaviour
{
    private float delayTime = 1f; // 2�� ���� �ð�

    private void Start()
    {
        Debug.Log("�ִϽ���");
        StartCoroutine(DelayedSceneTransition());
    }

    private IEnumerator DelayedSceneTransition()
    {
        yield return new WaitForSeconds(delayTime);
        OnSuccessAnimationEnd();
    }

    private void OnSuccessAnimationEnd()
    {
        Debug.Log("��");
        SceneManager.LoadScene("Main_Scene");

    }
}
