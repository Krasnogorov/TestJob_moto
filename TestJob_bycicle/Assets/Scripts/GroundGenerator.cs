//
//  GroundGenerator.cs
//  TestJob_Bicycle
//
//  Created by Sergey Krasnogorov on 11/18/19.
//  Copyright © 2019 Sergey Krasnogorov. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Generator of ground elements
 */
public class GroundGenerator : MonoBehaviour
{
    /// link of prefab of ground
    [SerializeField]
    private GameObject _groundPrefab = null;
    /// link to list of gorund objects
    [SerializeField]
    private List<GameObject> _objects = null;
    /// instance of class
    private static GroundGenerator _instance = null;
    public static GroundGenerator Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GenerateStartList();    
    }
    /**
     * Generate list of new tiles
     */
    public void GenerateStartList()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject lastObj = _objects[_objects.Count - 1];
            Vector3 lastPos = lastObj.transform.position;
            GameObject obj = GameObject.Instantiate(_groundPrefab, lastObj.transform.parent);
            int randValue = Random.Range(0, 100);
            float addValue = 0.0f;
            if (randValue > 70 && randValue < 85)
            {
                addValue = 1.0f;
            }
            else if (randValue >= 85 && randValue < 100)
            {
                addValue = -1.0f;
            }

            if (lastObj.transform.eulerAngles.z > 300.0f)
            {
                addValue -= 1.7f;
            }
            else if (lastObj.transform.eulerAngles.z > 0.1f && lastObj.transform.eulerAngles.z < 40.0f)
            {
                addValue += 1.7f;
            }
            obj.transform.position = new Vector3(lastPos.x + 5.0f, lastPos.y + addValue, lastPos.z);

            if (randValue > 70 && randValue < 85)
            {
                obj.transform.eulerAngles = new Vector3(0, 0, 23);
            }
            else if (randValue >= 85 && randValue < 100)
            {
                obj.transform.eulerAngles = new Vector3(0, 0, -23);
            }
            _objects.Add(obj);
        }
    }
    /**
     * Callback for objects which became is visible
     * @param obj - object which is visible now
     */
    public void ObjectIsVisible(GameObject obj)
    {
        if (obj == _objects[_objects.Count - 1])
        {
            GenerateStartList();
        }
    }
}
