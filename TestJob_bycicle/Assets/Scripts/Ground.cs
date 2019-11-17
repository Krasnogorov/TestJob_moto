//
//  Ground.cs
//  TestJob_Bicycle
//
//  Created by Sergey Krasnogorov on 11/18/19.
//  Copyright © 2019 Sergey Krasnogorov. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controller of tile of ground
 */
public class Ground : MonoBehaviour
{
    private void OnBecameVisible()
    {
        GroundGenerator.Instance.ObjectIsVisible(gameObject);
    }
}
