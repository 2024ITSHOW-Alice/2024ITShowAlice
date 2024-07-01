using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moveani : MonoBehaviour
{
    private float delayTime = 3f; // 2�� ���� �ð�

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
        SceneManager.LoadScene("Ending_happy2");

    }
}
