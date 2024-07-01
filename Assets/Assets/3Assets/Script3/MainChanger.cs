using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainChanger : MonoBehaviour
{
    public void ChangeMainGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
