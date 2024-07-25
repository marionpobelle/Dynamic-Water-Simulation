using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] float _amplitude = 1f;
    [SerializeField] float _length = 2f;
    [SerializeField] float _speed = 1f;
    [SerializeField] float _offset = 0f;

    public static WaveHandler Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Debug.Log("Instance of WaveHandler already exists, destroying object !");
            Destroy(this);
        }
    }

    private void Update()
    {
        _offset += Time.deltaTime * _speed;
    }

    public float GetWaveHeight(float posX)
    {
        return _amplitude * Mathf.Sin(posX / _length + _offset);
    }
}
