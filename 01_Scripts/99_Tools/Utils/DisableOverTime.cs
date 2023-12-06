using System;
using System.Collections;
using System.Collections.Generic;
using Blacktool.Utils.Tools;
using UnityEngine;

public class DisableOverTime : MonoBehaviour
{
    public float lifeTime = 3f;
    private Timer disableTimer;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableElement",lifeTime);
        disableTimer = new Timer(lifeTime, DisableElement);
    }

    private void DisableElement()
    {
       /* if (TryGetComponent<RunTowardPlayer>(out var chararcter))
        {
//            FindObjectOfType<PoolingManager>().ResetBullet(chararcter);
        }*/
    }

    private void OnEnable()
    {
        if (disableTimer == null)
        {
            disableTimer = new Timer(lifeTime, DisableElement);
        }
        disableTimer.ResetPlay();
    }

    private void OnDestroy()
    {
        disableTimer.Pause();
    }
}
