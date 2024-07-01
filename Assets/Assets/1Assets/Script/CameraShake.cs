using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPos;

    private void Awake()
    {
        originalPos = transform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            transform.localPosition = originalPos + (Vector3)Random.insideUnitCircle * shakeAmount;
            elapsedTime += Time.deltaTime;
            shakeAmount = Mathf.Lerp(shakeAmount, 0f, decreaseFactor * Time.deltaTime);
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
