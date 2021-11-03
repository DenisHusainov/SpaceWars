using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BoundsCheck _boundsCheck;

    [Header("Set in Inspector")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _hp = 100f;
    [SerializeField] private float _score = 100f;
    [SerializeField] private float _fireDelay = 0.3f;

    private void Awake()
    {
        _boundsCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 _pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    private void Update()
    {
        Move();
        // Refactoring
        if (_boundsCheck != null && !_boundsCheck._isOnScreen)
        {
            if ( _pos.y < (_boundsCheck._cammeraHight - _boundsCheck._radius))
            {
                Destroy(gameObject);
            } 
        }
    }

    private void Move() // Возможно необходим вирутал метод 
    {
        Vector3 _tempPos = _pos;
        _tempPos.y -= _speed * Time.deltaTime;
        _pos = _tempPos;
    }
}
