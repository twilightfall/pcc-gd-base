using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Scene3-Advanced");
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}