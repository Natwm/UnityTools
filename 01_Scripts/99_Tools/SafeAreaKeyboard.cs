using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Blacktool.UI
{
    public class SafeAreaKeyboard : MonoBehaviour
    {
        private int _keyboardHeight;
        private int _screenHeight;
        private bool _up = false;
        private bool _isBusy;

        public Canvas FeedbackCanvasContainer;
        
        private Vector3 _originalPosition;
        
        private TweenerCore<Vector3,Vector3,VectorOptions> m_MovePanel_Tween;
                 private Coroutine m_MoveCoroutine;

        
        public void Start()
        {
            _screenHeight = Screen.height;
            _originalPosition = transform.localPosition;
        }
        
        public void MoveUI()
        {
            if (_isBusy)
                return;
            _isBusy = true;
            
            m_MoveCoroutine = StartCoroutine(DelayMoveUI());
        }

        public IEnumerator DelayMoveUI()
        {
            yield return new WaitForSeconds(0.1f);
            _keyboardHeight = GetKeyboardHeight;

            var screenSize = RectTransformUtility.PixelAdjustRect(GetComponent<RectTransform>(), FeedbackCanvasContainer);
            
            var value = (Screen.height - screenSize.height)/2;
            
            
            if (_keyboardHeight <= 0)
            {
                _up = false;
                GetComponent<RectTransform>().DOMoveY(_originalPosition.y,0.5f);
            }
            else if (!_up)
            {
                _up = true;
                GetComponent<RectTransform>().DOLocalMoveY(value,0.5f);
            }
            _isBusy = false;
        }
        
        
        private int GetKeyboardHeight
        {
            get
            {
#if !UNITY_EDITOR && UNITY_ANDROID

                using ( var unityPlayer = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" ) )
                {
                    var view = unityPlayer
                        .GetStatic<AndroidJavaObject>( "currentActivity" )
                        .Get<AndroidJavaObject>( "mUnityPlayer" )
                        .Call<AndroidJavaObject>( "getView" )
                    ;

                    using ( var rect = new AndroidJavaObject( "android.graphics.Rect" ) )
                    {
                        view.Call( "getWindowVisibleDisplayFrame", rect );

                        return Screen.height - rect.Call<int>( "height" );
                    }
                }
#else
                return ( int )TouchScreenKeyboard.area.height;
#endif
            }
        }

        private void ResetPosition()
        {
            if(_originalPosition == null)
                _originalPosition = transform.localPosition;

            //Check if there is a coroutine running ( there is only one coroutine in this script and its used to move the panel up)
            // if there is one, stop the current movement.
            if (m_MoveCoroutine != null)
            {
                StopCoroutine(m_MoveCoroutine);
                m_MoveCoroutine = null; // set it to null for not stopping it 
            }

            //Reset position of the GameObject at its initial position on the Y axis
            _up = false;
            GetComponent<RectTransform>().DOMoveY(_originalPosition.y, 0.1f);
            _isBusy = false;
        }
        
        private void OnEnable()
        {
            ResetPosition();
        }
    }
}
