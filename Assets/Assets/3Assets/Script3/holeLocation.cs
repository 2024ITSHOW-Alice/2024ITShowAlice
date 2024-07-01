using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class holeLocation : MonoBehaviour
{
    private Transform goalTrans;

    private float randomX;
    private float randomY;

    void Start()
    {
        goalTrans = GetComponent<Transform>();
        RandomizeGoalPosition();
    }

    void Update()
    {
        goalTrans.position = new Vector3(randomX, randomY, 0.0f);

        Debug.Log(GameManager3.ScoreUp); // ScoreUp ���� �α� ���
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ball"))
        {
            Debug.Log("ball 충돌");
        }
    }

    void RandomizeGoalPosition()
    {
        randomX = UnityEngine.Random.Range(11.5f, 43.5f);
        randomY = UnityEngine.Random.Range(-2.77f, 0.8f);
        goalTrans.position = new Vector3(randomX, randomY, 0.0f);
    }
}
