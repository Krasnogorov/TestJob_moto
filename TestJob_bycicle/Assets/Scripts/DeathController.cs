//
//  DeathController.cs
//  TestJob_Bicycle
//
//  Created by Sergey Krasnogorov on 11/18/19.
//  Copyright © 2019 Sergey Krasnogorov. All rights reserved.
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Controller of death 
 */
public class DeathController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            SceneManager.LoadScene(0);
        }
    }
}
