//
//  MotoCycleController.cs
//  TestJob_Bicycle
//
//  Created by Sergey Krasnogorov on 11/18/19.
//  Copyright © 2019 Sergey Krasnogorov. All rights reserved.
//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controller of motocycle
 */
public class MotoCycleController : MonoBehaviour
{
    /// link to body
    [SerializeField]
    private Rigidbody2D _body = null;
    /// speed of moto
    [SerializeField]
    private float _speed = 20f;
    /// rotation speed in fly
    [SerializeField]
    private float _rotationSpeed = 2f;
    /// Link to back wheel
    [SerializeField]
    private WheelController _backWheel = null;
    /// Link to front wheel
    [SerializeField]
    private WheelController _frontWheel = null;
    /// Link to UI
    [SerializeField]
    private MainUI _ui = null;
    /// flag is object moving forward
    public bool _move = false;
    /// flag is object moving back
    private bool _moveBack = false;
    /// flag is object on ground 
    public bool _isGrounded = false;
    /// list of current collisions
    private List<GameObject> _currentCollisions = new List<GameObject>();
    /// vounter of wheele effect
    private float _wheeleTimer = 0;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
          _move = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _move = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _moveBack = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _moveBack = false;
        }
#else
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                _move = true;
            }
            else
            {
                _moveBack = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _move = false;
            _moveBack = false;
        }
#endif
    }

    private void FixedUpdate()
    {
        if (_move == true)
        {
            if (_isGrounded)
            {
                _body.AddForce(transform.right * _speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else
            {
                _body.AddTorque(_rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }
        else if (_moveBack)
        {
            if (_isGrounded)
            {
                _body.AddForce(transform.right * (-1) * _speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else
            {
                _body.AddTorque(_rotationSpeed * Time.fixedDeltaTime * (-100f), ForceMode2D.Force);
            }
        }
        if (_backWheel.CollizedObjectCount == 1 && _frontWheel.CollizedObjectCount == 0 ||
            _backWheel.CollizedObjectCount == 0 && _frontWheel.CollizedObjectCount == 1)
        {
            _wheeleTimer += Time.deltaTime;
            if (_wheeleTimer > 0.5f)
            {
                _ui.SetWheelyState(true);
            }            
        }
        else
        {
            _wheeleTimer = 0.0f;
            _ui.SetWheelyState(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            _currentCollisions.Add(collision.gameObject);
            
        }
        _isGrounded = _currentCollisions.Count > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.tag == "Ground")
        {
            _currentCollisions.Remove(collision.gameObject);
        }
        _isGrounded = _currentCollisions.Count > 0;
    }

}
