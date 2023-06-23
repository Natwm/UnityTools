using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blacktool.Patterns
{
    public interface IObserver <T>
    {
        public void OnNotify(T value);
    }    
}

