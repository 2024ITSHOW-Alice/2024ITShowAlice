using UnityEngine;

public class Trap : MonoBehaviour
{
    private Transform myTransform;
    private TrapSpawner trapSpawner;
    private Camera mainCamera;

    void Start()
    {
        myTransform = transform;
        trapSpawner = FindObjectOfType<TrapSpawner>();
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found.");
        }
    }

    void Update()
    {

        myTransform.Translate(0, 0.009f, 0); // 매 프레임마다 위로 이동

        // 장애물이 메인 카메라 뷰포트를 벗어났는지 확인
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(myTransform.position);
        if (viewportPosition.y > 1 || viewportPosition.x < 0 || viewportPosition.x > 1)
        {
            Destroy(gameObject); // 뷰포트를 벗어나면 파괴
        }
    }
}
