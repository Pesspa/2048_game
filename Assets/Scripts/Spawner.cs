using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 35f;
    [SerializeField] private float _maxXposition = 3f;

    private float _oldMouseX;
    private float _Xposition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMouseX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            float delta = Input.mousePosition.x - _oldMouseX;
            _oldMouseX = Input.mousePosition.x;
            _Xposition += delta * _sensitivity / Screen.width;
            _Xposition = Mathf.Clamp(_Xposition, -_maxXposition, _maxXposition);
            transform.position = new Vector3(_Xposition, transform.position.y, transform.position.z);
        }
    }
}
