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
    [Header("Controls")]
    [SerializeField]
    [Range(0f, 1f)]
    private float _mouseSensibility = 1;
    [SerializeField] 
    private float _scaleSensibility=10f;
    [SerializeField]
    private SongManager _songManager;
    [SerializeField]
    private int _row = 0;
    private float _amountXpos = 0;

    #region Action
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
        float xN = value.Get<Vector2>().x;
        
        _amountXpos = +xN * _mouseSensibility;
        //_row = 1;

        Debug.Log("Amount X : " + _amountXpos);

        if (_scaleSensibility < _amountXpos)
        {
            //_row = 2;
            _row = Math.Min(_row + 1, 2);
        }
        else if (-_scaleSensibility > _amountXpos)
        {
            //_row = 0;
            _row = Math.Max(_row - 1, 0);
        }
        _songManager.SetCurrentActionZone(_row);

        if (_amountXpos < (-_scaleSensibility * 2))
        {
            Debug.Log("Works");
            _amountXpos = (-_amountXpos * 2);
        }
        else if (_amountXpos > (_scaleSensibility * 2))
        {
            _amountXpos = (_amountXpos * 2);
        }
    }
    #endregion
}
