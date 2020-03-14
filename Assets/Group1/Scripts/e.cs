using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _radiusTarget = 4;

    private Vector3 _target;
   
    private void Start()
    {        
        _target = _transform.position;
    }
   
    private void Update()
    {
         MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (_transform.position == _target)
        {
            _target = Random.insideUnitCircle * _radiusTarget;
        }

        _transform.position = Vector3.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
    }

   
}
