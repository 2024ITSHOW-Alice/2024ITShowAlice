using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoChanger : MonoBehaviour
{
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}

