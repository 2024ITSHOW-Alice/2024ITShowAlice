using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public GameObject player; // 플레이어 오브젝트에 대한 참조

    private bool isTransitioning = false; // 전환 중인지를 나타내는 플래그

    private void Start()
    {
        fadeImage.gameObject.SetActive(false); // 초기에는 페이드 이미지 비활성화
    }

    public void StartFadeOutAndLoadScene(string sceneName)
    {
        if (!isTransitioning) // 이미 전환 중이 아닐 때만 전환을 시작합니다.
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName));
        }
    }

    public bool IsTransitioning()
    {
        return isTransitioning; // 전환 중인지 여부를 반환하는 메서드
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        isTransitioning = true; // 전환 중임을 표시하여 중복 전환을 방지
        Debug.Log("전환중");
        fadeImage.gameObject.SetActive(true);

        // 플레이어 오브젝트 비활성화
        if (player != null)
        {
            player.SetActive(false);
        }

        float timer = 0f;
        Color fadeColor = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = fadeColor;
            yield return null;
        }

        // 페이드 아웃 완료 후 잠시 대기하여 페이드 효과가 확실히 보이도록 함
        yield return new WaitForSeconds(0.5f);

        // 씬을 로드합니다.
        SceneManager.LoadScene(sceneName);

        // 전환 완료 후 플래그 초기화
        isTransitioning = false;
    }
}
