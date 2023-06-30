using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveItem : MonoBehaviour
{
    public int level;
    public float radius;
    public bool isLive = false;

    public Rigidbody rigidbody;

    [SerializeField] protected GameObject _projection;
    [SerializeField] protected Text _text;
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private SphereCollider _trigger;

    [SerializeField] private Animator _ballAnimator;

    [ContextMenu("Increase")]

    private void OnTriggerEnter(Collider other)
    {

        if (other.attachedRigidbody)
        {
            ActiveItem item = other.attachedRigidbody.GetComponent<ActiveItem>();
            if(item)
            {
                if (level == item.level && item.isLive)
                {
                    CollapseManager.instance.Collapse(this, item);
                }
            }
        }
    }
    public void Increase()
    {
        _trigger.enabled = false;
        Invoke(nameof(BallSetTrigger), 0.05f);
        _ballAnimator.SetTrigger("IncreaseLevel");
        level++;
        SetLevel(level);
    }
    public virtual void SetLevel(int Objectlevel)
    {
        level = Objectlevel;
        float number = (int)Mathf.Pow(2, Objectlevel + 1);
        string numberString = number.ToString();

        radius = Mathf.Lerp(0.6f, 1f, level / 10);
        _text.text = numberString;
        _collider.radius = radius;
        _trigger.radius = radius + 0.1f;
        Vector3 ballSkale = Vector3.one * radius * 2;
        _visualTransform.localScale = ballSkale;
    }
    public void BallSetTrigger()
    {
        _trigger.enabled = true;
    }
    public void SetKinematic()
    {   

        rigidbody.isKinematic = true;
//        rigidbody.interpolation = RigidbodyInterpolation.None;
        _trigger.enabled = false;
        _collider.enabled = false;
        isLive = true;
    }
    public void Drop()
    {
        Destroy(_projection.gameObject);
        _collider.enabled = true;
        _trigger.enabled = true;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        rigidbody.isKinematic = false;
        transform.parent = null;
        rigidbody.AddForce(Vector3.down * 200f);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
