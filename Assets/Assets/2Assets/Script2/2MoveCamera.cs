using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera2 : MonoBehaviour
{
    public Transform target; // player
    public float offsetX; // 카메라의 x 축 위치 조정값(플레이어를 약간 왼쪽으로 고정)
    public float offsetY; // 카메라의 y 축 위치 조정값(플레이어를 약간 밑에 고정)
    public float smoothSpeed = 0.125f; // 카메라 이동 시 부드럽게 이동하기 위한 변수
    
    [HideInInspector] // inspector창에서 숨김
    public bool isCameraFixed = false; // 카메라 고정 여부


void Start()
{
    // 메인 카메라에 오디오 리스너 추가
    Camera mainCamera = Camera.main;
    if (mainCamera != null && mainCamera.GetComponent<AudioListener>() == null)
    {
        mainCamera.gameObject.AddComponent<AudioListener>();
    }

    // 기타 초기화 로직
}

   void LateUpdate()
{
    // 메인 카메라에 오디오 리스너가 없다면 추가
    if (Camera.main != null && Camera.main.GetComponent<AudioListener>() == null)
    {
        Camera.main.gameObject.AddComponent<AudioListener>();
    }

    // 이하 코드는 기존 내용 그대로 유지
    if (!isCameraFixed)
    {
        // 플레이어의 위치를 따라가는 카메라 로직
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    if (Input.GetKeyDown(KeyCode.Escape))
    {
        ReturnToMainMenu();
    }
}


    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("2MainMenuScene");
    }
}
