using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projection : MonoBehaviour
{
    [SerializeField] private Renderer _projectionRenderer;
    [SerializeField] private Text _projectionText;
    [SerializeField] private Transform _projectionTransform;

    public void Setup(float radius, Material material, string number)
    {
        _projectionRenderer.material = material;
        _projectionText.text = number;
        _projectionTransform.localScale = Vector3.one * radius;
    }
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    public void ShowProjection()
    {
        gameObject.SetActive(true);
    }
    public void HideProjection()
    {
        gameObject.SetActive(false);
    }
}
