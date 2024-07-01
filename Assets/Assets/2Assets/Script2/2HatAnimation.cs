using UnityEngine;
using System.Collections;

public class HatAnimation : MonoBehaviour
{
    public Sprite EyesClosed; // 눈을 감은 상태의 이미지
    public Sprite EyesOpen;   // 눈을 뜬 상태의 이미지
    public Sprite Radar;      // Radar 오브젝트

    private SpriteRenderer spriteRenderer;
    private PlayerHideCheck playerHideCheck;
    private GameOverManager gameOverManager;
    private GameStart gameStart;
    private SceneTransition sceneTransition;
    private GameSound2 gameSound; // GameSound2 스크립트 참조 추가

    private Coroutine animateHatCoroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHideCheck = FindObjectOfType<PlayerHideCheck>();
        gameOverManager = FindObjectOfType<GameOverManager>();
        gameStart = FindObjectOfType<GameStart>();
        sceneTransition = FindObjectOfType<SceneTransition>();
        gameSound = FindObjectOfType<GameSound2>(); // GameSound2 초기화

        if (gameSound == null)
        {
            Debug.LogError("Scene에 GameSound2 스크립트가 없습니다.");
        }
    }

    void Update()
    {
        // 게임이 시작되면 코루틴을 시작하고, 멈추면 코루틴을 중지
        if (gameStart.GameRunning && animateHatCoroutine == null)
        {
            animateHatCoroutine = StartCoroutine(AnimateHatRoutine());
        }
        else if (!gameStart.GameRunning && animateHatCoroutine != null)
        {
            StopCoroutine(animateHatCoroutine);
            animateHatCoroutine = null;
        }
    }

    IEnumerator AnimateHatRoutine()
    {
        while (true)
        {
            // 눈을 감은 상태로 변경
            spriteRenderer.sprite = EyesClosed;
            yield return new WaitForSeconds(3f);

            // 눈을 뜬 상태로 변경
            spriteRenderer.sprite = EyesOpen;
            yield return new WaitForSeconds(0.8f); // 눈을 뜨고 나서 2초 후에 Radar 활성화
            spriteRenderer.sprite = Radar;

            // Play radar sound
            if (gameSound != null)
            {
                gameSound.PlayRadarSound(); // 새로운 오디오 클립을 재생하는 메서드 호출
            }

            // Radar가 활성화된 동안에만 플레이어가 숨었는지 확인
            float radarActiveTime = 1.5f; // Radar가 활성화된 시간
            float elapsedTime = 0f;

            while (elapsedTime < radarActiveTime)
            {
                if (!playerHideCheck.IsPlayerHiding())
                {
                    gameOverManager.ShowGameOver();
                    yield break; // 코루틴 종료
                }

                elapsedTime += Time.deltaTime;
                yield return null; // 한 프레임 대기
            }

            // Radar를 비활성화하고 다시 시작
            spriteRenderer.sprite = EyesClosed; // 눈을 감은 상태로 초기화
            yield return new WaitForSeconds(1f); // 눈을 감은 상태로 1초 대기
        }
    }
}
