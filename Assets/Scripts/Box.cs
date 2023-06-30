using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : PassiveItem
{
    public int health = 2;
    private Vector3 startPosition;
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private GameObject _destroyEffect;
    [SerializeField] private Animator _animator;
    void Start()
    {
        SetHealth(health);
        startPosition = transform.position;
    }
    private void Update()
    {

    }
    public override void OnAffect()
    {
        base.OnAffect();
        health--;
        Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        _animator.SetTrigger("Shake");
        SetHealth(health);
        if (health < 0)
            Die();
        else
            SetHealth(health);
    } 
    public void SetHealth(int value)
    {
        for(int i = 0; i < _levels.Length; i++)
        {
            _levels[i].SetActive(i <= value);
        }
    }
    public void Die()
    {
        score.AddOne();
        targets.SetTarget();
        Destroy(gameObject);
    }
}
