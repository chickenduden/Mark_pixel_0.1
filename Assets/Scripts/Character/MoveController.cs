using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector3 _leftFlip = new Vector3(0, 180, 0);
    private Vector2 _horizontalVelocity;
    private float _horizontalSpeed;
    private float _signPreviosFrame;
    private float _signCurrentFrame;
   

    public float MoveSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
        Flip();
        Animate();
    }

    private void Move()
    {
        _horizontalVelocity.Set(_horizontalSpeed * MoveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = _horizontalVelocity;
    }

    private void Flip()
    {
        _signCurrentFrame = _horizontalSpeed == 0 ? _signPreviosFrame : Mathf.Sign(_horizontalSpeed);

        if (_signCurrentFrame != _signPreviosFrame)
        {
            transform.rotation = Quaternion.Euler(_horizontalSpeed < 0 ? _leftFlip : Vector3.zero);
        }

        _signPreviosFrame = _signCurrentFrame;
    }

    private void Animate()
    {
        _animator.SetBool("IsRun", _horizontalSpeed != 0 ? true : false);
    }
}
