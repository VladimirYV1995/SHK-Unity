using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndMovingToTarget : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusTarget;

    private Vector3 _target;
   
    private void Start()
    {
        _speed = 2;
        _radiusTarget = 4;
        _target = Vector3.zero;
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
