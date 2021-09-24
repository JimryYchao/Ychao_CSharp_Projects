using SC.XR.Unity.Module_PerformanceSampler;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceSampler : MonoBehaviour
{
    GameObject Sampler;
    SamplerSys.SamplePickMultipleCallBack multipleCallBack;
    SamplerSys.SampleType[] samples;

    int FrameCount = 0;
    private float _framesPerSecond;
    double _peak = 0;
    Text Text_FPS;
    Text Text_USED;
    Text Text_PEAK;
    Text Text_TotalMemRate;
    GameObject Slider;
    RectTransform Slider_Total_Width;
    RectTransform Slider_USED_Width;

    void initUI()
    {
        Text_FPS = Sampler.transform.Find("Text_FPS").GetComponent<Text>();
        Text_USED = Sampler.transform.Find("Text_USED").GetComponent<Text>();
        Text_PEAK = Sampler.transform.Find("Text_PEAK").GetComponent<Text>();
        Text_TotalMemRate = Sampler.transform.Find("Text_TotalMemRate").GetComponent<Text>();

        Slider = Sampler.transform.Find("Slider").gameObject;
        Slider_Total_Width = Slider.transform.Find("Slider_Total").GetComponent<RectTransform>();
        Slider_USED_Width = Slider.transform.Find("Slider_USED").GetComponent<RectTransform>();
    }

    private void Awake()
    {
        Sampler = transform.Find("PerformanceSampler").gameObject;

        if (Sampler == null)
        {
            Sampler = Resources.Load("UIPrefabs/PerformanceSampler") as GameObject;
            if (Sampler == null)
            {
                Destroy(this);
                return;
            }
            Instantiate(Sampler, this.transform);
        }

        multipleCallBack = null;
        samples = new SamplerSys.SampleType[] { SamplerSys.SampleType.ProcessTotalPSS, SamplerSys.SampleType.TotalMemRate, SamplerSys.SampleType.ProcessMemRate };
        initUI();
    }

    private void Start()
    {
        StartCoroutine(Cor_CollectSamples());

    }

    private void Update()
    {
        FrameCount++;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    void UpdateProcessPSS(string val)
    {
        double processPss = Convert.ToDouble(val);
        Text_USED.text = $"USED : {val} MB";
        if (_peak <= processPss)
        {
            _peak = processPss;
            Text_PEAK.text = $"USED PEAK : {_peak} MB";
        }
    }

    void UpdateProcessCpuRate(string val)
    {
        float processPssRate = (float)Convert.ToDouble(val);
        Slider_USED_Width.sizeDelta = new Vector2(processPssRate * 3 + 5, Slider_USED_Width.rect.height);
    }

    void UpdateTotalMemRate(string val)
    {
        float totalMemRate = (float)Convert.ToDouble(val);
        Text_TotalMemRate.text = $"总内存使用 (率) : {totalMemRate}%";
        Color color = new Color(Text_TotalMemRate.color.r, 1f - (0.6666f * totalMemRate / 100f), Text_TotalMemRate.color.b);
        Text_TotalMemRate.color = color;
        Slider_Total_Width.GetComponent<Image>().color = color;
        var total = totalMemRate * 3 + 5;
        if (total >= 305)
            total = 305;
        Slider_Total_Width.sizeDelta = new Vector2(total, Slider_Total_Width.rect.height);
    }

    private IEnumerator Cor_CollectSamples()
    {
        int lastFrameCount = 0;

        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            // Update FPS
            _framesPerSecond = (FrameCount - lastFrameCount);
            lastFrameCount = FrameCount;
            Text_FPS.text = string.Format("CPU帧速率 : {0} fps", _framesPerSecond);
            //Update Samples
            SamplerSys.Instance.GetSamples((vals) =>
            {
                if (!string.IsNullOrEmpty(vals[0]))
                {
                    UpdateProcessPSS(vals[0]);
                }
                if (!string.IsNullOrEmpty(vals[1]))
                {
                    UpdateTotalMemRate(vals[1]);
                }
                if (!string.IsNullOrEmpty(vals[2]))
                {
                    UpdateProcessCpuRate(vals[2]);
                }
            }, samples);
        }
    }
}
