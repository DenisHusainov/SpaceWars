using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Hero Instance;

    [Header("Set in Inspetcor")]
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _rollMult = -45f;
    [SerializeField] private float _pichMult = 30;

    [Header("Set Dynamically")]
    public float _shialdLevel = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Пытается создать второй экземлпяр класса Hero");
            Destroy(gameObject); // может быть ошибка
            
        }
    }

    private void Update()
    {
        // Извлечь информацию из класса Input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Изменить transform.position, опираясь на информацию по осям
        Vector3 _pos = transform.position;
        _pos.x += xAxis * _speed * Time.deltaTime;
        _pos.y += yAxis * _speed * Time.deltaTime;
        transform.position = _pos;

        transform.rotation = Quaternion.Euler(xAxis * _pichMult, yAxis * _rollMult, 0);
    }
}
