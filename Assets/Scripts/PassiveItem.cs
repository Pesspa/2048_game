using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    [SerializeField] protected Score score;
    [SerializeField] protected Targets targets;
    public virtual void OnAffect()
    {

    } 
}
