using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LW.Cameras
{
    [CustomEditor(typeof(MouseFollowCamera))]
    public class MouseFollowCamera_Editor : Editor
    {
        #region Variables
        private MouseFollowCamera targetCamera;
        #endregion

        #region Methods
        private void OnEnable()
        {
            targetCamera = (MouseFollowCamera)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        private void OnSceneGUI()
        {
            // Camera Constraint Rect
            Rect constraint = new Rect(targetCamera.bottomLeftCoordinate.x ,
                                      targetCamera.bottomLeftCoordinate.y,
                                      targetCamera.topRightCoordinate.x - targetCamera.bottomLeftCoordinate.x,
                                      targetCamera.topRightCoordinate.y - targetCamera.bottomLeftCoordinate.y);
            Handles.DrawSolidRectangleWithOutline(constraint, new Color(1, 0, 0, 0.1f), Color.red);

            // Camera Constraint FreeMoveHandles
            targetCamera.bottomLeftCoordinate = Handles.FreeMoveHandle(new Vector3(targetCamera.bottomLeftCoordinate.x, targetCamera.bottomLeftCoordinate.y, 0),
                                                                       Quaternion.identity,
                                                                       1.0f,
                                                                       Vector3.one,
                                                                       Handles.RectangleHandleCap);
            targetCamera.topRightCoordinate = Handles.FreeMoveHandle(new Vector3(targetCamera.topRightCoordinate.x, targetCamera.topRightCoordinate.y, 0),
                                                                       Quaternion.identity,
                                                                       1.0f,
                                                                       Vector3.one,
                                                                       Handles.RectangleHandleCap);
        }
        #endregion
    }
}
