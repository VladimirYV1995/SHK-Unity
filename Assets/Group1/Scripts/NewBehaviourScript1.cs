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
                Vector3 direction = Vector3.zero;

                if (Input.GetAxis("Horizontal") != 0)
                {
                    direction.x = Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal"));
                }
                if (Input.GetAxis("Vertical") != 0)
                {
                    direction.y = Input.GetAxis("Vertical") / Mathf.Abs(Input.GetAxis("Vertical"));
                }
                _transform.Translate(direction * _speed * Time.deltaTime);
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
