using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    public UndoCommand undo;

    private void Awake() 
    {
        undo = new UndoCommand();
    }

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            undo.Invoke();
        }
    }
}
