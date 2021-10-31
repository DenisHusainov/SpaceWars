using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
/// Предотвращает выход игрового объекта за границы экрана.
/// Важно: работает ТОЛЬКО с ортографической камерой Main Camera в [ 0, 0, 0 ]. 
/// </ summary >
public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float _radius = 1f;

    [Header("Set Dinamically")]
     private float _cammeraWidth = default;
     private float _cammeraHight = default;

    private void Awake()
    {
        _cammeraHight = Camera.main.orthographicSize;
        _cammeraWidth = _cammeraHight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        Vector3 _pos = transform.position;
        if (_pos.x > _cammeraWidth - _radius)
            _pos.x = _cammeraWidth - _radius;

        if (_pos.x < -_cammeraWidth + _radius)
            _pos.x = -_cammeraWidth + _radius;

        if (_pos.y > _cammeraHight - _radius)
            _pos.y = _cammeraHight - _radius;

        if (_pos.y < -_cammeraHight + _radius)
            _pos.y = -_cammeraHight + _radius;

        transform.position = _pos;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 _boundSize = new Vector3(_cammeraWidth * 2, _cammeraHight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, _boundSize);
    }
}

