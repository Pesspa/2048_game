using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private Transform _tube;
    [SerializeField] private ActiveItem _ballPrefab;

    [SerializeField] private ActiveItem _itemInTube;
    [SerializeField] private ActiveItem _itemInSpawner;

    [SerializeField] private Transform _rayTransform;
    [SerializeField] LayerMask _layerMask;

    [SerializeField] private Level _level;
    private void Start()
    {
        CreateItemInTube();
        StartCoroutine(MoveToSpawner());
    }
    public void CreateItemInTube()
    {
        int _itemLevel = Random.Range(0, 4);
        _itemInTube = Instantiate(_ballPrefab, _tube.position, Quaternion.identity);
        _itemInTube.SetLevel(_itemLevel);
        _itemInTube.SetKinematic();
        
    }
    private IEnumerator MoveToSpawner()
    {
        _itemInTube.transform.parent = _spawner;
        for(float time = 0f; time > 1f; time += Time.deltaTime)
        {
            Debug.Log(time);
//            _itemInTube.transform.position = Vector3.Lerp(_tube.position, _spawner.position, time / 3f);
            yield return null;
        }
        _itemInSpawner = _itemInTube;
        _rayTransform.gameObject.SetActive(true);
        _itemInTube = null;
        CreateItemInTube();
        _itemInSpawner.transform.localPosition = Vector3.zero;
    }
    void Update()
    {
        Ray ray = new Ray(_spawner.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _rayTransform.localScale = new Vector3(1f, hit.distance, 1f);

        }
        if (_itemInSpawner != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                _rayTransform.gameObject.SetActive(false);
                _itemInSpawner.Drop();
                _itemInSpawner = null;
                _level.spendBalls();
            }
        }
        else
        {
            StartCoroutine(MoveToSpawner());
        }
    }
}
