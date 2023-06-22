using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Backend.API
{
    public class FakeStore : APIStore
    {
        /// <summary>
        /// Accepts a fake result that will be returned in the callback 2-3 seconds later.
        /// </summary>
        /// <param name="fakeResult">Prepared fake data to return in callback</param>
        /// <param name="callback">Action that will fire</param>
        /// <typeparam name="T">Any type of data</typeparam>
        public void MakeFakeRequest<T>(T fakeResult, Action<T> callback)
        {
            StartCoroutine(FakeRequest(fakeResult, callback, false));
        }

        /// <summary>
        /// Same as MakeFakeRequest but with only a 1 frame delay.
        /// </summary>
        public void FakeInstantRequest<T>(T fakeResult, Action<T> callback)
        {
            StartCoroutine(FakeRequest(fakeResult, callback, true));
        }

        private IEnumerator FakeRequest<T>(T fakeResult, Action<T> callback, bool instant = false)
        {
            if (!instant)
                yield return new WaitForSeconds(Random.Range(2f, 3f));
            else
                yield return null;

            callback(fakeResult);
        }
    }
}