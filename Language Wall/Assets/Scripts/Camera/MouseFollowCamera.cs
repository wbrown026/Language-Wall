using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LW.Extentions;

namespace LW.Cameras
{
    public class MouseFollowCamera : MonoBehaviour
    {
        #region Public Variables
        public Vector2 bottomLeftCoordinate;
        public Vector2 topRightCoordinate;
        #endregion

        #region Private Variables
        private Vector2 _originCoordinate;
        private Vector2 _topRightScreenCoordinate;
        #endregion

        #region Built In Methods
        private void Start()
        {
            // Set Private Variables
            _originCoordinate = new Vector2(0.0f, 0.0f);
            _topRightScreenCoordinate = new Vector2(Screen.width, Screen.height);
        }

        private void Update()
        {
            // Update Camera Position
            float newX = Input.mousePosition.x.Map(_originCoordinate.x, 
                                                   bottomLeftCoordinate.x, 
                                                   _topRightScreenCoordinate.x,
                                                   topRightCoordinate.x);
            float newY = Input.mousePosition.y.Map(_originCoordinate.y,
                                                   bottomLeftCoordinate.y,
                                                   _topRightScreenCoordinate.y,
                                                   topRightCoordinate.y);
            transform.position = new Vector3(newX, newY, transform.position.z);
        }
        #endregion
    }
}
