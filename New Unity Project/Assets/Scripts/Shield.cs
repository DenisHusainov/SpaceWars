using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float _rotationsSecond = 0.1f;

    [Header("Set Denamically")]
    [SerializeField] private float _levelShown = 0;

    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        int _currentLevel = Mathf.FloorToInt(Hero.Instance._shialdLevel);
        if (_levelShown !=_currentLevel)
        {
            _levelShown = _currentLevel;
            _material.mainTextureOffset = new Vector2(0.2f * _levelShown, 0);
        }
        float _zRot = -(_rotationsSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, _zRot);
    }
}
