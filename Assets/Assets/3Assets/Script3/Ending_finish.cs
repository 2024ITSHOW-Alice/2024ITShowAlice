using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_finish : MonoBehaviour
{
     public float transitionDuration = 5f; // 화면 전환 시간 (5초)

    private void Start()
    {
        StartCoroutine(TransitionToNextScene());
    }

    private System.Collections.IEnumerator TransitionToNextScene()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f; // 초기에 화면을 완전히 어둡게 설정

        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            // 5초 동안 서서히 화면을 밝게 만듦
            canvasGroup.alpha = elapsedTime / transitionDuration;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f; // 화면을 완전히 밝게 만듦

        // 5초가 지나면 다음 씬으로 이동
        SceneManager.LoadScene(7);
    }
}
