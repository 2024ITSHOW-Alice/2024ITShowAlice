using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changer : MonoBehaviour
{
    public void ChangeTo3_inGame()
    {
        SceneManager.LoadScene("3_inGame");
    }
}
