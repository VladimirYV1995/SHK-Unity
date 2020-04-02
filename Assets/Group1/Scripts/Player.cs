using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _final;
    [SerializeField] private float _speed;
    [SerializeField] private float _countTime = 2;

    private int _countEnemys;
    private bool _onCorutine;

    public bool OnCorutine => _onCorutine;

    private void Start()
    {
        _countEnemys = FindObjectsOfType<Enemy>().Length;
    }

    private void Update()
    {
        TryMove();
    }    

    private void TryMove()
    {
        Vector2 direction = DeterminateDirection();
        if (direction != Vector2.zero)
        {
            _transform.Translate(direction * _speed * Time.deltaTime);
        }       
    }

    private Vector2 DeterminateDirection()
    {
        int x = DeterminateAxis(Input.GetAxis("Horizontal"));
        int y = DeterminateAxis(Input.GetAxis("Vertical"));
        return new Vector2(x, y);
    }

    private int DeterminateAxis(float valueAxis)
    {
        if(valueAxis != 0 )
        {
            return (int) (valueAxis / Mathf.Abs(valueAxis));
        }
        else
        {
            return 0;
        }
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

    public void IncreaseSpeed()
    {
        _speed *= 2;
        _onCorutine = true;
        StartCoroutine(ReduceSpeed(_countTime));
    }

    private IEnumerator ReduceSpeed(float time)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        _speed /= 2;
        _onCorutine = false;
        StopCoroutine(ReduceSpeed(time));
    }    
}