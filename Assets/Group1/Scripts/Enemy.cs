using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Player _player;
    [SerializeField] private Final _final;
    [SerializeField] private float _deleteDistance = 0.2f;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _radiusInstantiate = 4;

    private Vector3 _target; 

    private void Start()
    {
        _target = _transform.position;
    }

    private void Update()
    {       
        if (Vector3.Distance(_transform.position, _player.transform.position) < _deleteDistance)
        {
            Delete();            
        }
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (_transform.position == _target)
        {
            _target = Random.insideUnitCircle * _radiusInstantiate;
        }
        _transform.position = Vector3.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
    }

    public void Delete()
    {
        _final.CheckEndGame();
        Destroy(gameObject);      
    }
}
