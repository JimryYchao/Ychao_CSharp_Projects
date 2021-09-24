using System;
using System.Collections.Generic;
using UnityEngine;

namespace SC.XR.Unity.Module_PerformanceSampler
{
    //回调发布
    public class SamplesCallBackHelper:MonoBehaviour
    {
        private Action mainThreadAction = null;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);   
        }

        private void Update()
        {
            if (mainThreadAction != null)
            {
                Action temp = mainThreadAction;
                mainThreadAction = null;
                temp.Invoke();
            }
        }

        public void CallonMainThread(Action function)
        {
            mainThreadAction = function;
        }
    }
}
