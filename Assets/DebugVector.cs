using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DebugVector : MonoBehaviour
{
    Vector3 _prevPos;
    Vector3 _pos;
    
    private Vector3 _direction = Vector3.up;
    
    public Vector3 forwardPosition { get { return transform.forward; }}

    
    public Vector3 MoveDirection { get { return (_pos - _prevPos).normalized; } }
    
    public Vector3 BladeDirection { get { return transform.rotation * _direction.normalized; } }

    public Vector3 normals { get { return Vector3.Cross(MoveDirection, BladeDirection);}}
    // Start is called before the first frame update
    private void Update()
    {
        _prevPos = _pos;
        _pos = transform.position;
    }
}

[CustomEditor(typeof(DebugVector))]
public class DebugVectorGUI : Editor {
 
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DebugVector debugVector = (DebugVector)target;
         
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.Vector3Field("Forward Position", debugVector.forwardPosition);
        EditorGUILayout.Vector3Field("Move Direction", debugVector.MoveDirection);
        EditorGUILayout.Vector3Field("Blade Direction", debugVector.BladeDirection);
        EditorGUILayout.Vector3Field("Normals", debugVector.normals);
        EditorGUI.EndDisabledGroup();
    }
}
