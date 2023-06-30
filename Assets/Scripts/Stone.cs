using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : PassiveItem
{
    [SerializeField] private GameObject _DestroyEffect;
    [SerializeField] private int _level;
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private Stone _stonePrefab;
    public override void OnAffect()
    {
        base.OnAffect();
        if(_level > 0)
        {
            for(int i = 0; i < 2; i++)
            {
                CreateNewRock(_level - 1);
            }
        }
    }
    public void CreateNewRock(int level)
    {
        Stone newStone = Instantiate(_stonePrefab, transform.position, Quaternion.identity);
        newStone.SetLevel(level);
    }
    public void SetLevel(int level)
    {

    }
}
