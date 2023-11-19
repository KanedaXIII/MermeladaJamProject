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
    private float _mouseSensitivity;
    [SerializeField]
    private SongManager _songManager;
    [SerializeField]
    private int _row = 0;

    private float _sensitivity = 1.0f;
    private float _previousMouseInput = 0.0f;
    private float _initialSensitivity = 1.0f;
    private float _changeSpeed = 0.1f;
    private float _lastMouseMovementTime;

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
        //float n = value.Get<Vector2>().x * 0.25f;
        //int nSensitivity = 0;
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

        // Obtén el Vector2 de la entrada y normaliza solo en el eje X
        float inputX = value.Get<Vector2>().x;

        // Ajusta la sensibilidad basándote en el valor absoluto del componente x
        _sensitivity = Mathf.Lerp(_sensitivity, _initialSensitivity + Mathf.Abs(inputX), Time.deltaTime * _changeSpeed);

        Debug.Log(inputX - _previousMouseInput + "_" + _sensitivity);

        // Verifica si la dirección de la entrada ha cambiado antes de realizar cambios en _row
        if ((inputX - _previousMouseInput) > _sensitivity || (inputX - _previousMouseInput) < -_sensitivity)
        {
            // Incrementa o decrementa _row basado en el componente x de la entrada y la sensibilidad
            if (inputX > _sensitivity)
            {
                _row = Mathf.Min(_row + 1, 2);
            }
            else if (inputX < -_sensitivity)
            {
                _row = Mathf.Max(_row - 1, 0);
            }

            // Modifica la sensibilidad al entrar en el incremento o decremento de _row
            _sensitivity = 120f + Mathf.Abs(inputX);

            // Actualiza el tiempo del último movimiento del ratón
            _lastMouseMovementTime = Time.time;

            // Actualiza la variable de seguimiento del estado anterior de la entrada del ratón
            _previousMouseInput = inputX;
        }
        else
        {
                _sensitivity = _initialSensitivity;
        }

        // Establece la zona de acción actual en _songManager según el valor actualizado de _row
        _songManager.SetCurrentActionZone(_row);
    }
}
