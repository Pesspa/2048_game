using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : PassiveItem
{
    [SerializeField] private GameObject destroyEffect;
    [ContextMenu("Die")] 
    public override void OnAffect()
    {
        base.OnAffect();
        Die();
    }

    public void Die()
    {
        score.AddOne();
        targets.SetTarget();
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
