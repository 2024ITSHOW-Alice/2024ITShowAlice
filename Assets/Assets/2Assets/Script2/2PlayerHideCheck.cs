using UnityEngine;

public class PlayerHideCheck : MonoBehaviour
{
    public GameObject[] objects;  // 겹침을 확인할 오브젝트들
    public GameObject EasterEggObject; // EasterEgg 오브젝트
    private Collider2D playerCollider;
    private PlayerControl playerControl;
    private GameStart gameStart;
    public GameObject Table;
    private SceneTransition sceneTransition; // SceneTransition 스크립트 참조
    private MoveCamera2 moveCamera; // MoveCamera2 스크립트 참조

    private bool isTransitioning = false; // Scene 전환 상태를 나타내는 플래그

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerControl = FindObjectOfType<PlayerControl>();
        gameStart = FindObjectOfType<GameStart>();
        sceneTransition = FindObjectOfType<SceneTransition>();
        moveCamera = FindObjectOfType<MoveCamera2>(); // MoveCamera2 스크립트 찾기


 // 초기에 EasterEgg를 보이지 않도록 설정
        if (EasterEggObject != null)
        {
            EasterEggObject.SetActive(false);
        }

        
        SpriteRenderer tableSpriteRenderer = Table.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 매 프레임마다 숨었는지 여부를 확인
        if (gameStart.GameRunning && !isTransitioning && !sceneTransition.IsTransitioning()) // sceneTransition이 전환 중이 아닐 때에만 확인
        {
            IsPlayerHiding();
        }
    }

    public bool IsPlayerHiding()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject obj = objects[i];
            Collider2D objectCollider = obj.GetComponent<Collider2D>();
            if (objectCollider == null)
            {
                continue;
            }

            // 겹치는 영역 계산
            Bounds playerBounds = playerCollider.bounds;
            Bounds objectBounds = objectCollider.bounds;

            float xMin = Mathf.Max(playerBounds.min.x, objectBounds.min.x);
            float xMax = Mathf.Min(playerBounds.max.x, objectBounds.max.x);

            float intersectionWidth = xMax - xMin;

            if (intersectionWidth > 0)
            {
                float playerWidth = playerBounds.size.x;
                float overlapRatio = intersectionWidth / playerWidth;


                if (i == 5 && overlapRatio >= 1f / 10f)
                {   // 플레이어가 objects[5]와 1/10 이상 겹칠 때
                    SpriteRenderer easterEggRenderer = EasterEggObject.GetComponent<SpriteRenderer>();
                    if (easterEggRenderer != null)
                    {
                       EasterEggObject.SetActive(true);
                    }
                }


                if (i == objects.Length - 1 && overlapRatio >= 1f / 10f)
                {   // 플레이어가 마지막 오브젝트와 1/10이상 겹칠시 그림자를 안 보이도록 레이어 조정
                    SpriteRenderer tableSpriteRenderer = Table.GetComponent<SpriteRenderer>();
                    if (tableSpriteRenderer != null)
                    {
                        tableSpriteRenderer.sortingOrder = 6;
                    }
                    // 카메라 고정
                    if (moveCamera != null)
                    {
                        moveCamera.isCameraFixed = true;
                    }
                }
                // 겹치는 조건을 만족하면 scene 전환 효과 시작하며 게임 오버처리 되지 않음 
                if (i == objects.Length - 1 && overlapRatio >= 3f / 4f)
                {
                    Debug.Log("플레이어가 숨었습니다 " + i + ", scene 전환");
                    isTransitioning = true; // Scene 전환 시작 플래그 설정

                    if (sceneTransition != null)
                    {
                        sceneTransition.StartFadeOutAndLoadScene("3_Dig"); 
                    }
                    return true; // IsPlayerHiding에서 true를 반환
                }

                if (playerControl.IsKeyDownPressed && overlapRatio >= 2.9f / 3f)
                {
                    Debug.Log("플레이어가 숨었습니다 " + i);
                    return true; // IsPlayerHiding에서 true를 반환
                }
            }
        }
        return false; // 숨지 않았을 때 false를 반환
    }

    public bool IsTransitioning()
    {
        return isTransitioning;
    }
}
