using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ChainedWork  {

    public List<WorkRing> chain = new List<WorkRing>();

    public IEnumerator DoWorkCO() {
        for (int i = 0; i < chain.Count; i++) {
            yield return chain[i].DoWorkRing();
        }
        yield return null;
    }

    public void AddWork (Action action)
    {
        AddWork (action, 0);
    }

    public void AddWork(Action action,float delay) {
        chain.Add(new WorkRing(action,delay));
    }

}

public class WorkRing {
	
    public Action action;
    public float delay;

    public WorkRing (Action action, float delay)
    {
        this.action = action;
        this.delay = delay;
    }

    public IEnumerator DoWorkRing() {
        yield return new WaitForSeconds(delay);
        PopulateAction(action);
    }

    public void PopulateAction(Action action) {
        if (action == null) {
            action = ()=>{
                Debug.Log("Null Callback");
            };
        }
        action();
    }
}