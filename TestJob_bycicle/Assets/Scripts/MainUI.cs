//
//  MainUI.cs
//  TestJob_Bicycle
//
//  Created by Sergey Krasnogorov on 11/18/19.
//  Copyright © 2019 Sergey Krasnogorov. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Controller of Main UI
 */
public class MainUI : MonoBehaviour
{
    /// link to label with distance
    [SerializeField]
    private Text _distanceLabel = null;
    /// link to label with wheele object
    [SerializeField]
    private GameObject _wheeleLabelObject = null;
    /// link to start point
    [SerializeField]
    private Transform _startPoint = null;
    /// link to bicycle
    [SerializeField]
    private Transform _bicycle = null;

    private void FixedUpdate()
    {
        float distance = Mathf.Abs(_bicycle.position.x - _startPoint.position.x);
        _distanceLabel.text = distance.ToString("N2");
    }
    /**
     * Display or hide wheele label
     */
    public void SetWheelyState(bool state)
    {
        _wheeleLabelObject.SetActive(state);
    }
}
