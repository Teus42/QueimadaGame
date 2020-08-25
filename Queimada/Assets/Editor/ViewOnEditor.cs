using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (PlayerMovement))]


public class ViewOnEditor : Editor
{
    
    void OnSceneGUI()
    {
        PlayerMovement pm = (PlayerMovement)target;
        Handles.color = Color.cyan;

        Handles.DrawWireArc(pm.areaCheck.position, Vector3.up, Vector3.forward, 360, pm.areaDistance);
        
        Handles.DrawWireArc(pm.groundCheck.position, Vector3.forward, Vector3.up, 360, pm.groundDistance);

        
    }
}
