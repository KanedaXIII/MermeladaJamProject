using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Rendering.Universal.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensibility = 1;
    [SerializeField] 
    private float _scaleSensibility=10f;
    [SerializeField]
    private SongManager _songManager;
    [SerializeField]
    private int _row = 0;

    private float _amountXpos = 0;
    private void OnPlayNote()
    {
        if (_songManager.ActivateRow())
        {
            Debug.Log("Niceeee!!!!");
        }
        else
        {
            Debug.Log("Bad!!!!");
        }
    }

    private void OnChangeActiveRow(InputValue value)
    {
        _amountXpos =+ value.Get<Vector2>().x * _mouseSensibility;

        _row = 1;

        Debug.Log("Amount X : "+_amountXpos);

        if (_scaleSensibility > _amountXpos)
        {
            _row = 2;
        }
        else if (-_scaleSensibility < -_amountXpos)
        {
            _row = 0;
        }
        _songManager.SetCurrentActionZone(_row);

        if (_amountXpos < (-_scaleSensibility*2))
        {
            Debug.Log("Works");
            _amountXpos = (-_amountXpos*2);
        }
        else if(_amountXpos > (_scaleSensibility * 2))
        {
            _amountXpos = ( _amountXpos * 2);
        }
        //if (n > (_mouseSensitivity + nSensitivity))
        //{
        //    _row = Math.Min(_row + 1, 2);
        //    nSensitivity = 200;
        //    _songManager.SetCurrentActionZone(_row);
        //}
        //else if (n < -(_mouseSensitivity + nSensitivity))
        //{
        //    _row = Math.Max(_row - 1, 0);
        //    nSensitivity = 200;
        //    _songManager.SetCurrentActionZone(_row);
        //}
    }
}
