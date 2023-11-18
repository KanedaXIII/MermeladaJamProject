using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private  Row _testRowl;
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
        if ( _testRowl.activeActionZone() )
        {
            Debug.Log("Niceeee!!!!");
        }
        else
        {
            Debug.Log("Bad!!!!");
        }
    }

    private void OnChangeActiveRow()
    {
        Debug.Log("Row");

    }
}
