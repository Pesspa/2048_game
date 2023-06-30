using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public string name;
    public int dificulty;
    public static PlayerSettings instance;
    public void setName(string inputedName)
    {
        name = inputedName;
    }
    public void setDificulty(int inputedDificalty)
    {
        dificulty = inputedDificalty + 1;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
