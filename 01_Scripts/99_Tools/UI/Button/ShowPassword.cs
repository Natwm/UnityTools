using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


    /// <summary>
    /// This class is used to switch a inputfiel between Standard and password mode
    /// </summary>
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class ShowPassword : MonoBehaviour
    {
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private Sprite visibilityOn;
        [SerializeField] private Sprite visibilityOff;

        private Image _visibilityIcon;


        #region Unity Methods

        private void Awake()
        {
            _visibilityIcon = GetComponent<Image>();
        }

        #endregion // Unity Methods

        #region Public methods

        /// <summary>
        /// Show password inside an inputfield
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ShowPass()
        {
            switch (passwordInput.inputType)
            {
                case TMP_InputField.InputType.Password:
                    _visibilityIcon.sprite = visibilityOn;
                    passwordInput.contentType = TMPro.TMP_InputField.ContentType.Standard;
                    passwordInput.ForceLabelUpdate();
                    break;
                case TMP_InputField.InputType.Standard:
                    _visibilityIcon.sprite = visibilityOff;
                    passwordInput.contentType = TMPro.TMP_InputField.ContentType.Password;
                    passwordInput.ForceLabelUpdate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion // Public methods
    }
