using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private int numberOfBalls;
    [SerializeField] private TextMeshProUGUI ballsCountText;
    private void Start()
    {
        ballsCountText.text = numberOfBalls.ToString();
    }
    public struct Task
    {
       public int count;
       public int level;

    }
    public void spendBalls()
    {
        
        numberOfBalls--;
        ballsCountText.text = numberOfBalls.ToString();
        if(numberOfBalls == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
