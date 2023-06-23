using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Blacktool.UI.Text
{
    /// <summary>
    /// This class is used to allow using clickable text inside a tmp_text element
    /// </summary>
    public class ClickableText : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            var text = GetComponent<TextMeshProUGUI>();
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);

                if (linkIndex > 1)
                {
                    var linkInfo = text.textInfo.linkInfo[linkIndex];
                    var linkId = linkInfo.GetLinkID();

                    print(linkId);

                    Application.OpenURL(linkId);
                }
            }
        }
    }
}