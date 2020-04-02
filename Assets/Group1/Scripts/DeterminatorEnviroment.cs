using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminatorEnviroment : MonoBehaviour
{
    [SerializeField] private GameObject _final;
    [SerializeField] private GameObject[] _others;
    [SerializeField] private Player _player;

    private List<GameObject> _availables;
    private int _countEnemys;

    private void Start()
    {
        _countEnemys = FindObjectsOfType<Enemy>().Length;        
        DefineAvailables();
    }

    private void Update()
    {
        CheckObject();
    }

    private void DefineAvailables()
    {
        _availables = new List<GameObject>();
        foreach (var gameObject in _others)
        {
            if (gameObject != null)
            {
                _availables.Add(gameObject);
            }
        }
    }

    private void CheckObject()
    {
        foreach (var gameObject in _availables)
        {
            if (Vector3.Distance(_player.transform.position, gameObject.transform.position) < 0.2f)
            {
                if (gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    _availables.Remove(gameObject);
                    enemy.Delete();
                    _countEnemys--;
                    CheckEndGame();
                }
                else if (gameObject.name == "speed")
                {
                    _player.IncreaseSpeed();
                }
            }
        }
    }

    private void CheckEndGame()
    {
        if (_countEnemys == 0)
        {
            _final.SetActive(true);
            enabled = false;
        }
    }
}
