using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Blacktool.Utils
{
    [ExecuteInEditMode]
    public class RatioHandler : MonoBehaviour
    {
        [ReadOnlyInspector] public Vector2Int res;
        [ReadOnlyInspector] public float ratio = 1f;

        public C_RatioEvent[] ratioEvents;

        //events
        public mEvent OnRatioChange;

        Vector2Int old_res = Vector2Int.zero;

        int oldRatioIndex = -1;
        int ratioIndex = -1;

        private void Start()
        {
            ratioIndex = -1;
            CheckRatioEvents();
        }

        void Update()
        {
            res.x = Screen.width;
            res.y = Screen.height;
            if (res.y > 0f)
            {
                ratio = (float)res.x / (float)res.y;
            }

            CheckRatioEvents();
        }

        void CheckRatioEvents()
        {
            if (HasResolutionChanged() || ratioIndex == -1)
            {
                ratioIndex = GetRatioIndex();

                if (ratioIndex != -1 && ratioIndex != oldRatioIndex)
                {
                    //new item from list selected

                    foreach (C_TransformModification mod in ratioEvents[ratioIndex].transformModifications)
                    {
                        SetTransform(mod);
                    }

                    ratioEvents[ratioIndex].OnThisRatioSelected.Invoke();

                    oldRatioIndex = ratioIndex;
                    OnRatioChange.Invoke();
                }
            }
        }

        bool HasResolutionChanged()
        {
            if (res.x != old_res.x || res.y != old_res.y)
            {
                old_res.x = res.x;
                old_res.y = res.y;
                return true;
            }

            return false;
        }

        //select the correct ratio
        int GetRatioIndex()
        {
            int selectedElement = -1;
            for (int i = 0; i < ratioEvents.Length; i++)
            {
                if (ratio > ratioEvents[i].ratio)
                {
                    selectedElement = i;
                }
            }

            return selectedElement;
        }

        void SetTransform(C_TransformModification mod)
        {
            if (mod.target != null)
            {
                mod.target.anchoredPosition = mod.position;
                mod.target.localScale = mod.scale;
            }
            else
            {
                Debug.LogWarning("Missing transform for orientation change. RatioHandler.cs at " + gameObject.name);
            }
        }

        [System.Serializable]
        public class mEvent : UnityEvent
        {
        }

        [System.Serializable]
        public class C_TransformModification
        {
            public RectTransform target;
            public Vector2 position;
            public Vector3 scale;

            C_TransformModification()
            {
                scale = new Vector3(1f, 1f, 1f);
            }
        }

        [System.Serializable]
        public class C_RatioEvent
        {
            public float ratio = 1f;
            public List<C_TransformModification> transformModifications;
            public mEvent OnThisRatioSelected;
        }
    }
}