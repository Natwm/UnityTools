using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

    public static class TradTool 
    {
        
        public static I2.Loc.Localize CheckTradOnButton(UnityEngine.UI.Button buttonToTrad)
        {
            var textButton = buttonToTrad.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            return CheckTraductionElement(textButton);
        }
        
        public static I2.Loc.Localize CheckTraductionElement(TMP_Text stringToTrad)
        {
            var stringTrad = stringToTrad.gameObject.GetComponent<I2.Loc.Localize>();
        
            if(stringTrad == null)
                return stringToTrad.gameObject.AddComponent<I2.Loc.Localize>();

            return stringTrad;
        }
        
        public static void ApplyTraduction (GameObject objToTrad, string tradKey)
        {

            UnityEngine.UI.Button buttonComponent = objToTrad.GetComponent<UnityEngine.UI.Button>();
            bool isButton = buttonComponent != null;

            if (isButton)
            {
                PickTraductionOnButton(buttonComponent, tradKey);
            }
            else
            {
                TMP_Text pickText = objToTrad.GetComponent<TMP_Text>();
                PickTraductionOnText(pickText,tradKey);
            }

        }
        
        public static void PickTraductionOnText (TMP_Text stringToTrad, string tradKey)
        {
            if (ThereIsNoTrad(tradKey))
            {
                stringToTrad.text = "";
                return;
            }
            
            var stringTrad = stringToTrad.gameObject.GetComponent<I2.Loc.Localize>();

            if (stringTrad == null)
            {
                stringTrad = stringToTrad.gameObject.AddComponent<I2.Loc.Localize>();
                stringTrad.Term = tradKey;
                return;
            }

            stringTrad.Term = tradKey;
        }
        
        public static void PickTraductionOnText (Text stringToTrad, string tradKey)
        {
            var stringTrad = stringToTrad.gameObject.GetComponent<I2.Loc.Localize>();

            if (stringTrad == null)
            {
                stringTrad = stringToTrad.gameObject.AddComponent<I2.Loc.Localize>();
                stringTrad.Term = tradKey;
                return;
            }

            stringTrad.Term = tradKey;
        }
        
        public static void PickTraductionOnButton (UnityEngine.UI.Button stringToTrad, string tradKey)
        {
            
            if (ThereIsNoTrad(tradKey))
                return;
            
            
            var stringTrad = GetTextOnButton(stringToTrad).GetComponent<I2.Loc.Localize>();

            if (stringTrad == null)
            {
                stringTrad = GetTextOnButton(stringToTrad).gameObject.AddComponent<I2.Loc.Localize>();
                stringTrad.Term = tradKey;
                return;
            }
            
            stringTrad.Term = tradKey;
        }
        
        /*public static void PickTraductionOnButton (UIButton stringToTrad, string tradKey)
        {
            if (ThereIsNoTrad(tradKey))
                return;
            
            var stringTrad = GetTextOnButton(stringToTrad).GetComponent<I2.Loc.Localize>();

            if (stringTrad == null)
            {
                stringTrad = GetTextOnButton(stringToTrad).gameObject.AddComponent<I2.Loc.Localize>();
                stringTrad.Term = tradKey;
                return;
            }
            
            stringTrad.Term = tradKey;
        }*/

        public static void SetParametterOnObject(GameObject ObjectToInjectParam, string newValue,
            string specificParam = "")
        {
            UnityEngine.UI.Button buttonComponent = ObjectToInjectParam.GetComponent<UnityEngine.UI.Button>();
            bool isButton = buttonComponent != null;

            if (isButton)
            {
                SetParametterOnButton(buttonComponent,specificParam, newValue);
                return;
            }
            else
            {
                TMP_Text textToInjectParam = ObjectToInjectParam.GetComponent<TMP_Text>();
                if (textToInjectParam == null)
                {
                    Debug.LogError("There is no Text attach to this obj");
                    return;
                }
                SetParametterOnText(textToInjectParam,specificParam,newValue);
            }
        }

        public static void SetParametterOnText(TMP_Text textToInjectParam, string newValue, string specificParam = "")
        {
            var paramManager = textToInjectParam.GetComponent<LocalizationParamsManager>();
            if (paramManager == null)
            {
                Debug.LogError("This text doesn't have Params Manager");
                return;
            }
            
            if(string.IsNullOrEmpty(specificParam))
                if(!string.IsNullOrEmpty(paramManager._Params[0].Name))
                    paramManager.SetParameterValue(paramManager._Params[0].Name,newValue);
                else
                {
                    Debug.LogError("This object do not have params ");
                    return;                    
                }

            paramManager.SetParameterValue(specificParam,newValue);
        }

        public static void SetParametterOnButton(UnityEngine.UI.Button ButtonToInjectParam, string newValue, string specificParam = "")
        {
            if (ButtonToInjectParam.gameObject.transform.childCount <= 0)
            {
                Debug.LogError("This Button do not have any child");
                return;
            }
            
            TMP_Text textToTrad = ButtonToInjectParam.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();

            if (textToTrad == null)
            {
                Debug.LogError("This Button do not have any child with a Text Component");
                return;
            }
            
            SetParametterOnText(textToTrad,newValue,specificParam);
        }

        public static bool ThereIsNoTrad(string tradTag)
        {
            return string.IsNullOrEmpty(I2.Loc.LocalizationManager.GetTranslation(tradTag));
        }


        private static TMP_Text GetTextOnButton<T>(T button)
        {
            try
            {
                if (typeof(T).Equals(typeof(UnityEngine.UI.Button)))
                {
                    var value = (UnityEngine.UI.Button)Convert.ChangeType(button, typeof(UnityEngine.UI.Button));

                    if (value.gameObject.transform.childCount <= 0 )
                    {
                        Debug.LogError("There is no Text element as a children");
                        return null;
                    }

                    var component = value.gameObject.GetComponentsInChildren<TMPro.TMP_Text>();

                    if (component.Length <= 0)
                    {
                        Debug.LogError("There isn't text component.");
                        return null;
                    }else if (component.Length > 1)
                    {
                        Debug.LogError("There Too many text element, please select a specific one.");
                        return null;
                    }
                    else
                    {
                        return component[0];
                    }

                }
                /*else if (typeof(T).Equals(typeof(UIButton)))
                {
                    var value = (UIButton)Convert.ChangeType(button, typeof(UIButton));

                    if (value.gameObject.transform.childCount <= 0 )
                    {
                        Debug.LogError("There is no Text element as a children");
                        return null;
                    }

                    var component = value.gameObject.GetComponentsInChildren<TMPro.TMP_Text>();

                    if (component.Length <= 0)
                    {
                        Debug.LogError("There isn't text component.");
                        return null;
                    }else if (component.Length > 1)
                    {
                        Debug.LogError("There Too many text element, please select a specific one.");
                        return null;
                    }
                    else
                    {
                        return component[0];
                    }
                }*/
            }
            catch
            {
                Debug.LogError("The object isn't a Button element");

            }
            
            return null;
        }
    }

