using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SC.XR.Unity.Module_PerformanceSampler
{
    public class SamlpesReceiver : AndroidJavaProxy
    {
        private readonly SamplerSys.SamplePickCallBack sampleCall;
        private readonly SamplerSys.SamplePickMultipleCallBack samplesCall;
        private readonly SamplesCallBackHelper callbackHelper;

        public SamlpesReceiver(SamplerSys.SamplePickCallBack sampleCall, SamplerSys.SamplePickMultipleCallBack samplesCall) : base("com.Ychao.PerformanceAnalysis.SampleReceiver")
        {
            this.sampleCall = sampleCall;
            this.samplesCall = samplesCall;

            callbackHelper = new GameObject("SamplesCallBackHelper").AddComponent<SamplesCallBackHelper>();
        }

        public void OnSampleReceived(string val)
        {
            callbackHelper.CallonMainThread(() => sampleCallBack(val));
        }

        public void OnSamplesReceived(string[] vals)
        {
            callbackHelper.CallonMainThread(() => samplesCallBcak(vals));
        }

        private void sampleCallBack(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                val = null;
            }
            try
            {
                if (sampleCall != null)
                    sampleCall(val);
            }
            finally
            {
                Object.Destroy(callbackHelper.gameObject);
            }
        }

        private void samplesCallBcak(string[] vals)
        {
            if (vals == null||vals.Length == 0)
            {
                vals = null;
            }

            for (int item = 0; item < vals.Length; item++)
            {
                if (string.IsNullOrEmpty(vals[item]))
                {
                    vals[item] = null;
                }
            }
            try
            {
                if (samplesCall != null)
                    samplesCall(vals);
            }
            finally
            {
                Object.Destroy(callbackHelper.gameObject);
            }
        }

    }
}
