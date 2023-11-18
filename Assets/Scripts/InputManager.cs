using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Rendering.Universal.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity;
    [SerializeField]
    private SongManager _songManager;
    [SerializeField]
    private int _row = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        if (value.Get<Vector2>().x > _mouseSensitivity)
        {
            _row = Math.Min(_row + 1, 2);
        }
        else if(value.Get<Vector2>().x < -_mouseSensitivity)
        {

            _row = Math.Max(_row - 1, 0);
        }

        _songManager.SetCurrentActionZone(_row);

    }
}
