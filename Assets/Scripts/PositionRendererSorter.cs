using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField] private int _sortingOrderBase = 1000;
    [SerializeField] private int _offset = 0;
    [SerializeField] bool _runOnlyOnce = false;
    float _timer, _timerMax = .1f;
    Renderer _renderer;
    void Awake()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        if (_renderer == null)
            Debug.LogWarning("PositionRendererSorter.cs: Cannot find Renderer");
    }

    
    void LateUpdate()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = _timerMax;
            _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y - _offset);
            if (_runOnlyOnce == true)
                Destroy(this);
        }
        
    }
}
