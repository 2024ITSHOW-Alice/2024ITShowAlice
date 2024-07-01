using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moveani : MonoBehaviour
{
    private float delayTime = 3f; // 2초 지연 시간

    private void Start()
    {
        Debug.Log("애니시작");
        StartCoroutine(DelayedSceneTransition());
    }

    private IEnumerator DelayedSceneTransition()
    {
        yield return new WaitForSeconds(delayTime);
        OnSuccessAnimationEnd();
    }

    private void OnSuccessAnimationEnd()
    {
        Debug.Log("신");
        SceneManager.LoadScene("Ending_happy2");

    }
}
