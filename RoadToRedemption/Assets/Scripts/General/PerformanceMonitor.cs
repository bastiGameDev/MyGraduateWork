using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class PerformanceMonitor : MonoBehaviour
{
    public TextMeshProUGUI statsText;

    private float updateInterval = 1f; // Интервал обновления в секундах
    private float lastUpdateTime = 0f;

    void Update()
    {
        // Получаем текущее время
        float currentTime = Time.time;

        // Если прошла секунда с последнего обновления
        if (currentTime - lastUpdateTime > updateInterval)
        {
            // Обновляем информацию
            UpdatePerformanceStats();

            // Запоминаем время последнего обновления
            lastUpdateTime = currentTime;
        }
    }

    void UpdatePerformanceStats()
    {
        // Получаем информацию о времени кадра
        float frameTime = Time.deltaTime * Time.timeScale * 1000f; // в миллисекундах

        // Получаем информацию о использовании памяти
        long usedMemory = Profiler.GetTotalAllocatedMemoryLong();
        long totalMemory = Profiler.GetTotalReservedMemoryLong();
        float memoryUsage = (float)usedMemory / totalMemory;

        // Обновляем текст с информацией
        UpdateStatsText(frameTime, memoryUsage);
    }

    void UpdateStatsText(float frameTime, float memoryUsage)
    {
        string statsString = string.Format("Frame Time: {0} ms\nMemory Usage: {1}%", frameTime, Mathf.RoundToInt(memoryUsage * 100));
        statsText.text = statsString;
    }
}