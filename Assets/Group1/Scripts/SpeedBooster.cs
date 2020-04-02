using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speedBoostDistance = 0.2f;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Vector3.Distance(_transform.position, _player.transform.position) < _speedBoostDistance && _player.OnCorutine == false)
        {
            _player.IncreaseSpeed();
        }
    }
}
