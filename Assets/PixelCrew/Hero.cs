using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private float _horizontalDirection;
    private float _verticalDirection;
    [SerializeField] private float _speed;
    
    public void SetHorizontalDirection(float horizontalDirection)
    {
        _horizontalDirection = horizontalDirection;
    }

    public void SetVerticalDirection(float verticalDirection)
    {
        _verticalDirection = verticalDirection;
    }

    private void Update()
    {
        if (_horizontalDirection != 0)
        {
            var delta = _horizontalDirection * _speed * Time.deltaTime;
            var newXPosition = transform.position.x + delta;
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }

        if (_verticalDirection != 0)
        {
            var delta = _verticalDirection * _speed * Time.deltaTime;
            var newYPosition = transform.position.y + delta;
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
    }

    public void SaySomething()
    {
        Debug.Log("Say Something");
    }
}
