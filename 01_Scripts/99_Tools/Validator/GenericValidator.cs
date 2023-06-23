using System.Text.RegularExpressions;
using UnityEngine;

namespace Blacktool.Utils.Validator
{
    /// <summary>
    /// This class is used to check if all elements given by the user match a corresponding regex  
    /// </summary>
    public static class GenericValidator
    {
        private const string EmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        private const string PasswordPattern =
            @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[\`\'\""~<>.,:;\[\](){}+=\/\\|#?!@$%^&*_-]).{8,32}$";

        private const string ScanCodePattern =
            @"[0-9]{12}-[0-9]{3}";

        private const string ScanQRCodePattern =
            @"[0-9]{1};FDJ;RDJ;[0-9]{3};[0-9]{8};[0-9]{2};[0-9]{6}";

        private const string ManualScanQRCodePattern =
            @"12 [0-9]{3} [0-9]{8} [0-9]{2} [0-9]{2}";
        //12 991 10170662 13 82

        /// <summary>
        /// Rule using the pattern expressed on swagger. (+)33 6|7 12345678
        /// </summary>
        private const string ValidPhoneNumberPattern = @"^((\+?)33)(6|7)[0-9]{8}$";

        /// <summary>
        /// Simple rule, 3-16 characters, letters only.
        /// </summary>
        private const string ValidNicknamePattern = @"^[a-zA-Z-_ ]{3,16}$";

        /// <summary>
        /// Check if the email is valid
        /// </summary>
        /// <param name="mail">Email to check</param>
        /// <returns>Return if the email match the regex</returns>
        public static bool Email(string mail)
        {
            return mail != null && Regex.IsMatch(mail, EmailPattern);
        }

        /// <summary>
        /// Check if the Password is valid
        /// </summary>
        /// <param name="pass">Password to check</param>
        /// <returns>Return if the password match the regex</returns>
        public static bool Password(string pass)
        {
            return pass != null && Regex.IsMatch(pass, PasswordPattern) && pass.Length >= 8;
        }

        /// <summary>
        /// Check if the Phone number is valid
        /// </summary>
        /// <param name="phoneNumber">Phone Number to check</param>
        /// <returns>Return if the phone number match the regex</returns>
        public static bool PhoneNumber(string phoneNumber)
        {
            return phoneNumber != null && Regex.IsMatch(phoneNumber, ValidPhoneNumberPattern);
        }

        /// <summary>
        /// Check if the nickname is valid
        /// </summary>
        /// <param name="nickname">Nickname to check</param>
        /// <returns>Return if the username match the regex</returns>
        public static bool Nickname(string nickname)
        {
            return nickname != null && Regex.IsMatch(nickname, ValidNicknamePattern);
        }

        /// <summary>
        /// Check if two string is the same
        /// </summary>
        /// <param name="str1">First string to check</param>
        /// <param name="str2">Second string to check</param>
        /// <returns>Return if str1 & str2 are the same</returns>
        public static bool StringsEqual(string str1, string str2)
        {
            return str1 != null && str2 != null && str1.Equals(str2);
        }


        public static bool PhoneCode(string code)
        {
            return true;
        }

        /// <summary>
        /// Check if this manual code is valid
        /// </summary>
        /// <param name="code">The code to check</param>
        /// <returns>Return if the code match the regex from scanCode or QRCode</returns>
        public static bool ManualEntry(string code)
        {
            Debug.Log("code : " + code);
            return code != null && (Regex.IsMatch(code, ScanCodePattern) || Regex.IsMatch(code, ScanQRCodePattern) ||
                                    Regex.IsMatch(code, ManualScanQRCodePattern));
        }

    }
}