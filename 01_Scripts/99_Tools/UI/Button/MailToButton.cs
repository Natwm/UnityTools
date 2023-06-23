using UnityEngine;

namespace Blacktool.UI.Interactable.ButtonElement
{
    /// <summary>
    /// This class is used to send an Email at the m_URL
    /// </summary>
    public class MailToButton : MonoBehaviour
    {
        public string m_URL = "contact@aftergame.fr";
        public string m_Mailsubject = "Contact_FDJ_remontée_utilisateur";
        public string m_MailBody = "Bonjour";

        /// <summary>
        /// Send an Email at the m_URL 
        /// </summary>
        public void MailToURL()
        {
#if UNITY_ANDROID
            Application.OpenURL("mailto:" + m_URL + "?subject=" + m_Mailsubject + "&body=" + m_MailBody);

#elif UNITY_IOS
            m_Mailsubject = m_Mailsubject.Replace(' ', '_');
            m_MailBody = m_MailBody.Replace(' ', '_');
            string subject = WWW.EscapeURL(m_Mailsubject);
            string body = WWW.EscapeURL(m_MailBody);

            Application.OpenURL ("mailto:" + m_URL + "?subject=" + subject + "&body=" + body);

#endif
        }
    }
}