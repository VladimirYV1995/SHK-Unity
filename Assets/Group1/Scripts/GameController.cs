using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private static GameController Controller;

    [SerializeField] private GameObject _go;
    [SerializeField] private GameObject[] _b;
    [SerializeField] private GameObject _a;
    [SerializeField] private Player _player;

    private GameObject[] _nonZeroB;   
    private Vector3[] _positionsB;
    private Vector3 _positionA;

    private void Start()
    {
        Controller = this;

        _nonZeroB = InitNonZeroObjects(_b);
        _positionsB = InitPositions(_nonZeroB);
        _positionA = _a.transform.position;
    }

    private void Update()
    {
        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            _go.SetActive(true);
            enabled = false;
        }

        CheckObject();
    }

    private GameObject[] InitNonZeroObjects(GameObject[] gameObjects)
    {
        GameObject[] nonZeroObjects = new GameObject[0];

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                GameObject[] template = new GameObject[nonZeroObjects.Length + 1];
                for (int j = 0; j < nonZeroObjects.Length; j++)
                {
                    template[j] = nonZeroObjects[j];
                }
                nonZeroObjects = template;
                nonZeroObjects[nonZeroObjects.Length - 1] = gameObjects[i];
            }
        }
        return nonZeroObjects;
    }

    private Vector3[] InitPositions(GameObject[] gameObjects)
    {
        Vector3[] positions = new Vector3[gameObjects.Length];
        
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = gameObjects[i].transform.position;
        }

        return positions;
    }

    private void CheckObject()
    {
        for (int i = 0; i < _positionsB.Length; i++)
        {
            if (Vector3.Distance(_positionA, _positionsB[i]) < 0.2f)
            {
                if (_nonZeroB[i].name == "enemy")
                {
                    Destroy(_nonZeroB[i]);
                }
                else if (_nonZeroB[i].name == "speed")
                {
                    _player.IncreaseSpeed();
                }
            }
        }
        
    }

}
