using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private float _CountTime = 2;

    private void Update()
    {  
        if (Input.anyKey)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                float directionX = 0;
                float directionY = 0;

                if (Input.GetAxis("Horizontal") != 0)
                {
                    directionX = Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal"));
                }
                if (Input.GetAxis("Vertical") != 0)
                {
                    directionY = Input.GetAxis("Vertical") / Mathf.Abs(Input.GetAxis("Vertical"));
                }
                _transform.Translate(new Vector3(directionX, directionY, 0) * _speed * Time.deltaTime);
            }
        }
    }

    public void IncreaseSpeed()
    {
        _speed *= 2;
        StartCoroutine(ReduceSpeed(_CountTime));
    }

    private IEnumerator ReduceSpeed(float time)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        _speed /= 2;
        StopCoroutine(ReduceSpeed(time));
    }
}
