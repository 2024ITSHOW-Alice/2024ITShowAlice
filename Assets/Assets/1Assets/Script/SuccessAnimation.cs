using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessAnimation : MonoBehaviour
{
    private float delayTime = 3f; // 2초 지연 시간

    private void Start()
    {
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
        SceneManager.LoadScene("2TalkScene");

    }
}
