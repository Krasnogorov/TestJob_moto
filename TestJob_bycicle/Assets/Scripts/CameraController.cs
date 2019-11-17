//
//  CameraController.cs
//  TestJob_Bicycle
//
//  Created by Sergey Krasnogorov on 11/18/19.
//  Copyright © 2019 Sergey Krasnogorov. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controller of camera
 */
public class CameraController : MonoBehaviour
{
    /// link to target transform
    [SerializeField]
    private Transform _targetTransform = null;

    private void FixedUpdate()
    {
        transform.position = new Vector3(_targetTransform.position.x, _targetTransform.position.y, transform.position.z);
    }
}
