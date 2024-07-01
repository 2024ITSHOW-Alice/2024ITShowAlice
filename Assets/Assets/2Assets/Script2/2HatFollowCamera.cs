using UnityEngine;

public class HatFollowCamera : MonoBehaviour
{
    public float xOffset;// = -2.0f;  // 카메라의 x 축에서의 오프셋 (왼쪽으로 이동)
    public float yOffset;// = 4.0f;   // 카메라의 y 축에서의 오프셋
    public GameObject radar;       // Radar 오브젝트

    private Transform cameraTransform;

    void Start()
    {
        // 카메라의 Transform을 가져옵니다.
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Hat의 위치를 카메라의 위치를 기준으로 설정합니다.
        Vector3 newPosition = new Vector3(cameraTransform.position.x + xOffset, cameraTransform.position.y + yOffset, transform.position.z);
        transform.position = newPosition;

        // Radar의 위치를 Hat의 위치와 동일하게 설정합니다.
        if (radar != null)
        {
            radar.transform.position = newPosition;
        }
    }
}
