using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saddle : MonoBehaviour
{
    [SerializeField] private Transform _saddle;
    [SerializeField] private Transform[] _positionStrip;
    [SerializeField] private Transform _default;

    private LineRenderer[] _strips;

    private void Awake()
    {
        _strips = _saddle.GetComponentsInChildren<LineRenderer>();
    }

    private void Start()
    {
        for(int i = 0; i < _strips.Length; i++)
        {
            _strips[i].positionCount = 2;
            _strips[i].SetPosition(0, _positionStrip[i].position);
        }

        ResetStrips();
    }

    public void ResetStrips()
    {
        SetSaddlePosition(_default.position);
    }

    public void SetSaddlePosition(Vector3 target)
    {
        foreach(var strip in _strips)
        {
            strip.SetPosition(1, target);
        }

        _saddle.position = target;
    }
}
