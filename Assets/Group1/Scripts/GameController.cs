using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminatorEnvirment : MonoBehaviour
{
    [SerializeField] private GameObject _final;
    [SerializeField] private GameObject[] _others;
    [SerializeField] private GameObject _active;
    [SerializeField] private Player _player;

    private GameObject[] _availables;
    private int _countEnemys;

    private void Start()
    {
        _countEnemys = FindObjectsOfType<Enemy>().Length;
        _availables = DefineAvailables(_others);
    }

    private void Update()
    {
        CheckObject();
    }

    private GameObject[] DefineAvailables(GameObject[] gameObjects)
    {
        GameObject[] availables = new GameObject[0];

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                GameObject[] template = new GameObject[availables.Length + 1];
                for (int j = 0; j < availables.Length; j++)
                {
                    template[j] = availables[j];
                }
                availables = template;
                availables[availables.Length - 1] = gameObjects[i];
            }
        }
        return availables;
    }    

    private void CheckObject()
    {
        for (int i = 0; i < _availables.Length; i++)
        {
            if (Vector3.Distance(_active.transform.position, _availables[i].transform.position) < 0.2f)
            {
                if (_availables[i].name == "enemy")
                {
                    Destroy(_availables[i]);
                    _countEnemys--;
                    CheckEndGame();
                }
                else if (_availables[i].name == "speed")
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
