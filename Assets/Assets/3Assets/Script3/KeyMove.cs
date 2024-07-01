using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyMove : MonoBehaviour
{
    public GameObject Key;
    private Vector3 mousePosition;
    private bool isDragging = false;

    void Start()
    {
        
    }

    void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 포인터의 2D 좌표 저장
            mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

            // Key 오브젝트를 클릭했는지 확인
            if (Key.GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                isDragging = true;
            }
        }
        // 마우스 왼쪽 버튼을 뗐을 때
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // 마우스 드래그 중
        if (isDragging)
        {
            // 마우스 포인터의 2D 좌표 업데이트
            mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

            // Key 오브젝트의 위치를 마우스 포인터 위치로 설정
            Key.transform.position = new Vector3(mousePosition.x, mousePosition.y, Key.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
        
    }

     void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
