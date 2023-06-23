using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Blacktool.Utils.PlayerPref;
using UnityEngine;
using UnityEngine.Networking;

namespace Blacktool.Backend.API
{
    /// <summary>
    /// All error codes sent by the Backend
    /// </summary>
    public enum ServerResponse
    {
        FatalError = -1,
        Ok = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        InternalServerError = 500,

        // Anything over 101x is client resolved from response body.
        Duplicate = 1010,
        MaxDailyScans = 1011,
        PhoneNotVerified = 1012,
        EmailNotVerified = 1013,
        DieselErrorUniqueViolation = 1014,
    }

    [CreateAssetMenu(fileName = "API", menuName = "FDJ/API", order = 0)]
    public class APIScriptableObject : ScriptableObject
    {
        [SerializeField] private string apiKey = "t84Gtj6S5FDCXsnydmrVfSQ6";
        [SerializeField] private string url;
        [SerializeField] private string urlImage;

        public string URL => url;
        public string URLImage => urlImage;

#if UNITY_EDITOR || DEVELOPMENT_BUILD
        [SerializeField] private bool verboseLog;
#endif
        [SerializeField] private int timeoutDuration = 10;

        /// <summary>
        /// Server passes its own response codes in the body, usually in a 403 response, so we need to parse it.
        /// </summary>
        private Dictionary<string, ServerResponse> _ExpandedServerResponse = new Dictionary<string, ServerResponse>()
        {
            { "EUD01", ServerResponse.DieselErrorUniqueViolation }, // DieselErrorUniqueViolation
            { "EUD02", ServerResponse.Unauthorized }, // DieselErrorNotFound
            { "EUD03", ServerResponse.InternalServerError }, // DieselError
            { "EUP04", ServerResponse.Unauthorized }, // InvalidPassword
            { "EUP05", ServerResponse.InternalServerError }, // Argon2Error
            {
                "ESI06", ServerResponse.InternalServerError
            }, // UnexpectedConversionError, InternalServerError, PooledConnection, Cookie, DatabaseConnection, LettreEmail, SmtpEmail, UuidError
            {
                "EUL07", ServerResponse.MaxDailyScans
            }, // MaxDailyScanReached, MaxSimultaneousExchanges, NoGamePassesLeft
            { "ESI08", ServerResponse.InternalServerError }, // Blocking
            { "EUP09", ServerResponse.InternalServerError }, // Parse
            { "EUU10", ServerResponse.Unauthorized }, // Unauthorized, InvalidResetToken
            { "EUI11", ServerResponse.BadRequest }, // InvalidInput
            { "EUV12", ServerResponse.EmailNotVerified }, // EmailNotVerified
            { "EUV13", ServerResponse.PhoneNotVerified }, // PhoneNotVerified
            { "ESF14", ServerResponse.InternalServerError }, // FCMSendingFailure
            { "EUF15", ServerResponse.BadRequest }, // FCMInvalidOrNullToken
            { "EUD16", ServerResponse.BadRequest }, // GenericBadRequest
            { "EUI17", ServerResponse.Duplicate }, // NothingToDelete, Duplicate
            { "EUF18", ServerResponse.Forbidden }, // FCMInvalidGlobalNotification
            { "EUQ19", ServerResponse.BadRequest }, // QuestNotClaimable
            { "EUQ20", ServerResponse.Forbidden }, // QuestAlreadyClaimed
            { "EUD21", ServerResponse.InternalServerError }, // InvalidWelcomePass,
        };

        private string token;

        /// <summary>
        /// Set the token of the user in player preferences
        /// </summary>
        /// <param name="token"></param>
        public void SetToken(string token)
        {
            this.token = token;
            PlayerPrefs.SetString(UserPrefsStrings._userTokenKey, token);
        }

        private string UrlRoute(string route) => $"{url}{(route.StartsWith("/") ? string.Empty : "/")}{route}";

        #region Public Methods

        #region Post

        public IEnumerator Post(string route, string data, Action<ServerResponse> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "POST"), callback);
        }

        public IEnumerator Post<T>(string route, string data, Action<ServerResponse, T> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "POST"), callback);
        }

        public IEnumerator RequestWithAuthResponse(string route, string data, Action<ServerResponse> callback)
        {
            yield return SendAuthRequest(NewWebRequest(route, data, "POST"), callback);
        }

        #endregion // Post

        #region Patch

        public IEnumerator Patch(string route, string data, Action<ServerResponse> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "PATCH"), callback);
        }

        public IEnumerator Patch<T>(string route, string data, Action<ServerResponse, T> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "PATCH"), callback);
        }

        #endregion // Patch

        #region Get

        public IEnumerator Get(string route, Action<ServerResponse> callback)
        {
            yield return ServerRequest(NewWebRequest(route, string.Empty, "GET"), callback);
        }

        public IEnumerator Get<T>(string route,string data, Action<ServerResponse, T> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "GET"), callback);
        }

        #endregion // Get

        #region Put

        public IEnumerator Put(string route, string data, Action<ServerResponse> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "PUT"), callback);
        }

        public IEnumerator Put<T>(string route, string data, Action<ServerResponse, T> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "PUT"), callback);
        }

        public IEnumerator Delete(string route, string data, Action<ServerResponse> callback)
        {
            yield return ServerRequest(NewWebRequest(route, data, "DELETE"), callback);
        }

        #endregion // Put

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Sets the correct headers for API calls
        /// </summary>
        /// <param name="request"></param>
        private void SetHeaders(UnityWebRequest request)
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("x-api-key", apiKey);
            if (!string.IsNullOrEmpty(token))
                request.SetRequestHeader("Authorization", $"{token}");
        }

        /// <summary>
        /// Returns a newly created webrequest for the AP
        /// </summary>
        /// <param name="route"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private UnityWebRequest NewWebRequest(string route, string data, string method)
        {
            UnityWebRequest request = new UnityWebRequest(UrlRoute(route), method);
            if (!string.IsNullOrEmpty(data))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(data);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            }

            request.timeout = timeoutDuration;

            request.downloadHandler = new DownloadHandlerBuffer();
            SetHeaders(request);

#if UNITY_EDITOR || DEVELOPMENT_BUILD
            VerboseRequestLog(request.method, data);
#endif

            return request;
        }

        /// <summary>
        /// Server request with no expected data response, just a response code.
        /// If the response is a 403, additional information is parsed from the body for the ServerResponse code.
        /// </summary>
        private IEnumerator ServerRequest(UnityWebRequest request, Action<ServerResponse> callback)
        {
            yield return request.SendWebRequest();

#if UNITY_EDITOR || DEVELOPMENT_BUILD
            VerboseResultLog(request);
#endif

            if (request.result != UnityWebRequest.Result.Success)
            {
                if (ContainsResponseCode(request.downloadHandler.text))
                {
                    callback.Invoke(_ExpandedServerResponse[request.downloadHandler.text]);
                    yield break;
                }
            }

            callback((ServerResponse)request.responseCode);
        }

        /// <summary>
        /// Server request with expected data in the body and returned through the callback.
        /// If the response is a 403, additional information is parsed from the body for the ServerResponse code.
        /// </summary>
        private IEnumerator ServerRequest<T>(UnityWebRequest request, Action<ServerResponse, T> callback)
        {
            yield return request.SendWebRequest();

#if UNITY_EDITOR || DEVELOPMENT_BUILD
            VerboseResultLog(request);
#endif

            if (request.result != UnityWebRequest.Result.Success)
            {
                if (ContainsResponseCode(request.downloadHandler.text))
                {
                    callback.Invoke(_ExpandedServerResponse[request.downloadHandler.text], default(T));
                    yield break;
                }

                callback.Invoke((ServerResponse)request.responseCode, default(T));
                yield break;
            }

            // TODO : Empty array, unsure how to parse this out without this check
            if (request.downloadHandler.text.Length == 2)
            {
                callback.Invoke((ServerResponse)request.responseCode, default(T));
                yield break;
            }

            Debug.Log(request.downloadHandler.text);//STOP
            T result;
            
            result = JsonUtility.FromJson<T>(request.downloadHandler.text);
            
            callback((ServerResponse)request.responseCode, result);
        }

        /// <summary>
        /// As we have to manually get the header, a bit more work is done, a request is sent and the token is pulled from the header and returned to the callback
        /// </summary>
        private IEnumerator SendAuthRequest(UnityWebRequest request, Action<ServerResponse> callback)
        {
            yield return request.SendWebRequest();

#if UNITY_EDITOR || DEVELOPMENT_BUILD
            VerboseResultLog(request);
#endif

            if (request.result != UnityWebRequest.Result.Success)
            {
                if (ContainsResponseCode(request.downloadHandler.text))
                {
                    callback.Invoke(_ExpandedServerResponse[request.downloadHandler.text]);
                    yield break;
                }

                callback.Invoke((ServerResponse)request.responseCode);
                yield break;
            }

            // We get the token from the response header, but we have to parse it manually.
            var header = request.GetResponseHeader("Set-Cookie");
            var loginToken = header.Split(';')[0].Replace("Authorization=", string.Empty);

            // Store token which is included with all future requests
            SetToken(loginToken);
            callback((ServerResponse)request.responseCode);
        }

        #endregion Server Requests

        #region Helper methods

        private bool ContainsResponseCode(string body)
        {
            if (string.IsNullOrEmpty(body))
                return false;

            return _ExpandedServerResponse.ContainsKey(body);
        }

#if UNITY_EDITOR || DEVELOPMENT_BUILD

        private void VerboseResultLog(UnityWebRequest request)
        {
            if (!verboseLog) return;
#if !UNITY_INCLUDE_TESTS
            if (request.downloadHandler.text.Length == 5 && ContainsResponseCode(request.downloadHandler.text))
            {
                Debug.Log(
                    $"[API:Incoming] Code: {request.responseCode} | BodyCode: {_ExpandedServerResponse[request.downloadHandler.text]}");
            }
            else
            {
                Debug.Log($"[API:Incoming] Code: {request.responseCode} | Body: {request.downloadHandler.text}");
            }
#endif
        }

        private void VerboseRequestLog(string type, string content)
        {
            if (!verboseLog) return;
            //Debug.Log($"[API:Outgoing] Auth?: {!string.IsNullOrEmpty(token)} | Method: {type} | Body: {content}");
        }

#endif

        #endregion Helper methods
    }
}