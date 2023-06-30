using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public Transform cameraTransform;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        LookOnCamera();
    }
    public void LookOnCamera()
    {
        Vector3 targetRotation = cameraTransform.position - transform.position;
        Vector3 targetScaleYZ = new Vector3(0f, targetRotation.y, targetRotation.z);
        transform.rotation = Quaternion.LookRotation(-targetScaleYZ);
    }
}
