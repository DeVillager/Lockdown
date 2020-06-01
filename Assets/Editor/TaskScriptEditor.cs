using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

[CustomEditor(typeof(Task))]
public class TaskScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Task task = (Task)target;
        task.description = EditorGUILayout.TextField("Description:", task.description);
        task.taskType = (TaskType)EditorGUILayout.EnumPopup("Task Type", task.taskType);

        if (task.taskType == TaskType.Value)
        {
            task.valueType = (ValueType)EditorGUILayout.EnumPopup("Value Type", task.valueType);
            task.requiredAmount = EditorGUILayout.IntField("Required Amount:", task.requiredAmount);
        }
        else
        {
            task.taskAction = (TaskAction)EditorGUILayout.EnumPopup("Task Action", task.taskAction);
        }
    }
}
