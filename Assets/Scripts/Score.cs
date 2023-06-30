using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject winWindow;
    [SerializeField] private Targets targets;
    public int scoreCount;
    public TextMeshProUGUI countText;
    public Transform imageTransform;
    public AnimationCurve animationCurve;

    private void Start()
    {
        targets.SetTarget();
        scoreCount = targets.itemList.Count;
        Setup();
    }
    [ContextMenu("AddOne")]
    public void AddOne()
    {
        scoreCount--;
        if(scoreCount <= 0)
        {
            scoreCount = 0;
            winWindow.SetActive(true);
        }
        StartCoroutine(CurveAnimation());
        countText.text = scoreCount.ToString();
    }

    public void Setup()
    {
        countText.text = scoreCount.ToString();
    }
    public IEnumerator CurveAnimation()
    {
        for(float t = 0; t < 1f; t += Time.deltaTime * 2f)
        {
            float size = animationCurve.Evaluate(t);
            imageTransform.localScale = Vector3.one * size;
            yield return null;
        }
        imageTransform.localScale = Vector3.one;
    }
}

