using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void setName(string inputedName)
    {
        PlayerSettings.instance.setName(inputedName);
    }
    public void setDificulty(int inputedDificalty)
    {
        PlayerSettings.instance.setDificulty(inputedDificalty);
    }
}
