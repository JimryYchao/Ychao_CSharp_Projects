# Performance Sampler

- 提供关于安卓设备 CPU GPU MEM 相关的性能信息采集(一般性仅提供当前进程)

---

## 1. Plugins

- SamplesReceiver
  - 从安卓端接收回调

- SamplesCallBackHelper
  - 接收回调并在主线程触发调用

- PerformanceAnalysis.aar
  - 安卓端插件包

---
## 2. SamplerSys

- 反射 Java 端 PerformanceAnalysis.SamplerSystem, 提供 Unity 端接口

