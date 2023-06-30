using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ActiveItem
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private BallSettings _ballSettings;
    public override void SetLevel(int Objectlevel)
    {
        base.SetLevel(Objectlevel);
        _renderer.material = _ballSettings.ballMaterials[Objectlevel];
//        _projection.Setup(radius, _ballSettings.ballTransperentMaterials[Objectlevel], )
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
    }
}
