using System;
using System.Collections.Generic;
using UnityEngine;

namespace SC.XR.Unity.Module_PerformanceSampler
{
    /*  >> SamplerSys <<
     *  
     *  性能采集模块
     *  
     *  回调方式获取数据
     *  
     *      GetSample, GetSamples ---> 调用方法
     *      SampleType ---> 样本种类
     *      
     */
    public class SamplerSys
    {
        public delegate void SamplePickCallBack(string val);
        public delegate void SamplePickMultipleCallBack(string[] vals);

        public void GetSample(SamplePickCallBack callback, SampleType sampleType)
        {
            getSample(callback, (int)sampleType);
        }

        /// <summary>
        /// callback 返回的 String[] 按照传入的 SampleType[] 顺序返回, 长度一致
        /// </summary>
        public void GetSamples(SamplePickMultipleCallBack callback, SampleType[] samples)
        {
            int[] SampleTypes = new int[samples.Length];
            for (int i = 0; i < SampleTypes.Length; i++)
            {
                SampleTypes[i] = (int)samples[i];
            }

            getSamples(callback, SampleTypes);
        }

        public enum SampleType
        {
            //Cpu
            TotalCpuRate = 1000,
            ProcessCpuRate = 1001,
            CpuModel = 1002,
            TopListByCpuOrder = 1003,

            //Mem
            TotalMemRate = 2000,
            ProcessMemRate = 2001,
            TotalMemSize = 2002, // MB
            ProcessTotalPSS = 2003, // MB
            TopListByMemOrder = 2004,

            SampleMemInfo = 2010, // MB
            DetailMemInfo = 2011, // KB
            AvailableMem = 2012, // MB

            PrivateDirty = 2020, // KB
            ProcessPSSInfo = 2021, // KB
            NativeHeap = 2022, // KB
            DalvikHeap = 2023, // KB

            //Gpu
            TotalGpuRate = 3000,
            GpuModel = 3001,
            GpuMinFreq = 3002,
            GpuMaxFreq = 3003
        }

        private static AndroidJavaObject _AJC = null;
        private static AndroidJavaObject AJC
        {
            get
            {
                if (_AJC == null)
                {
                    _AJC = new AndroidJavaClass("com.Ychao.PerformanceAnalysis.SamplerSystem").CallStatic<AndroidJavaObject>("getInstance", Context);
                }
                return _AJC;
            }
        }
        private static AndroidJavaObject context = null;
        private static AndroidJavaObject Context
        {
            get
            {
                if (context == null)
                {
                    using (AndroidJavaObject unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                    {
                        context = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
                    }
                }
                return context;
            }
        }
        
        private static Lazy<SamplerSys> instance;
        public static SamplerSys Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Lazy<SamplerSys>();
                }
                return instance.Value;
            }
        }

        private void getSample(SamplePickCallBack callBack, int SampleType)
        {
#if !UNITY_EDITOR && UNITY_ANDROID
            AJC.Call("getSample",  new SamlpesReceiver(callBack, null), SampleType);
#endif
        }
        private void getSamples(SamplePickMultipleCallBack callBack, int[] SampleTypes)
        {
#if !UNITY_EDITOR && UNITY_ANDROID
            AJC.Call("getSamples", new SamlpesReceiver(null, callBack), SampleTypes);
#endif
        }
    }
}
