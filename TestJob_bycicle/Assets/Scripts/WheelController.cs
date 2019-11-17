//
//  WheelController.cs
//  TestJob_Bicycle
//
//  Created by Sergey Krasnogorov on 11/18/19.
//  Copyright © 2019 Sergey Krasnogorov. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Controller of wheel
 */
public class WheelController : MonoBehaviour
{
    /// List of collized objects
    private List<GameObject> _groundObjects = new List<GameObject>();
    /// Count of collized objects
    public int CollizedObjectCount
    {
        get
        {
            return _groundObjects.Count;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _groundObjects.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _groundObjects.Remove(collision.gameObject);
        }
    }
}
