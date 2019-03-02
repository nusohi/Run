using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RepeatMove))]
public class RepeatMoveEditor : Editor
{
    private RepeatMove _RepeatMove;

    public override void OnInspectorGUI() {

        _RepeatMove = (RepeatMove)target;

        _RepeatMove.type = (VHType)EditorGUILayout.EnumPopup("Type", _RepeatMove.type);

        //EditorGUILayout.BeginHorizontal();
        if (_RepeatMove.type == VHType.UpDown) {
            _RepeatMove.Up = EditorGUILayout.FloatField("Up", _RepeatMove.Up);
            _RepeatMove.Down = EditorGUILayout.FloatField("Down", _RepeatMove.Down);
        }
        else {
            _RepeatMove.Left = EditorGUILayout.FloatField("Left", _RepeatMove.Left);
            _RepeatMove.Right = EditorGUILayout.FloatField("Right", _RepeatMove.Right);

        }
        //EditorGUILayout.EndHorizontal();
        

        _RepeatMove.Duration = EditorGUILayout.FloatField("Duration", _RepeatMove.Duration);

        if (GUI.changed) {
            EditorUtility.SetDirty(target);
        }
    }


}
