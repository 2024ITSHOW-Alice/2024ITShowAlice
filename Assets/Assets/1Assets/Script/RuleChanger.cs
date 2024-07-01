using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleChanger : MonoBehaviour
{
    public void ChangeToGame1Scene()
    {
        SceneManager.LoadScene("Game1_Scene");
    }
}
