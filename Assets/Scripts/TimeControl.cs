using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private const float DefaultGameSpeed = 1;
    [SerializeField] private float increasedGameSpeed = 2;
    private void Update()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            Time.timeScale = increasedGameSpeed;
        }
        else
        {
            Time.timeScale = DefaultGameSpeed;
        }
    }
}
