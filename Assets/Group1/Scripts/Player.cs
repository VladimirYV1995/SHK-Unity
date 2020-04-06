using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private float _countTime = 2;

    private bool _onCorutine;

    public bool OnCorutine => _onCorutine;

    private void Update()
    {
        TryMove();
    }    

    private void TryMove()
    {
        Vector2 direction = CreateDirection();
        if (direction != Vector2.zero)
        {
            _transform.Translate(direction * _speed * Time.deltaTime);
        }       
    }

    private Vector2 CreateDirection()
    {
        int x = CalculateValueAxis(Input.GetAxis("Horizontal"));
        int y = CalculateValueAxis(Input.GetAxis("Vertical"));
        return new Vector2(x, y);
    }

    private int CalculateValueAxis(float valueAxis)
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