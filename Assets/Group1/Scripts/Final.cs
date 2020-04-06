using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final: MonoBehaviour
{
    [SerializeField] private GameObject _final;
    [SerializeField] private Enemy[] _enemies;

    private int _countEnemys;

    private void Start()
    {
        _countEnemys = _enemies.Length;
    }

    public void CheckEndGame()
    {
        _countEnemys--;

        if (_countEnemys == 0)
        {
            _final.SetActive(true);
            enabled = false;
        }
    }
}