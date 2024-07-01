using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesChanger : MonoBehaviour
{
    public void ChangeToGame1Scene()
    {
        Debug.Log("yes");
        SceneManager.LoadScene("Game1_Scene");
    }
}
