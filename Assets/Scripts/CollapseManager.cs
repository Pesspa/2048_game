using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseManager : MonoBehaviour
{
    public static CollapseManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void Collapse(ActiveItem itemA, ActiveItem itemB)
    {
        StartCoroutine(ProcessOfColapse(itemA, itemB));
    }
    IEnumerator ProcessOfColapse(ActiveItem itemA, ActiveItem itemB)
    {
        itemA.SetKinematic();       
        for(float t = 0; t <= 1f; t += Time.deltaTime / 0.1f)
        {
            Vector3 StartPosition = itemB.transform.position;
            itemA.transform.position = Vector3.Lerp(StartPosition, itemB.transform.position, t);
            yield return null;
        }
        itemA.transform.position = itemB.transform.position;
        itemA.Die();
        itemB.Increase();  
        ExplodeBall(itemB.transform.position, itemB.radius + 0.2f);
    }
    public void ExplodeBall(Vector3 position, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius);
        for(int i = 0; i < colliders.Length; i++)
        {
            PassiveItem passiveItem = colliders[i].GetComponent<PassiveItem>();
            if (colliders[i].attachedRigidbody)
            {
                passiveItem = colliders[i].attachedRigidbody.GetComponent<PassiveItem>();
                passiveItem.OnAffect();
            }
            if (passiveItem != null)
            {
                passiveItem.OnAffect();
            }
        }
    }
}
