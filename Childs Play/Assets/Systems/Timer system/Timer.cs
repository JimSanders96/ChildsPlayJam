using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public GameEvent TimerEndEvent;
    public GameEvent TimerStartEvent;
    public FloatVariable CurrentTimerValue, CurrentTimerPercentage;
    public float MinTimerValue, MaxTimerValue;

    private float startTime = 0f;
    private bool timerActive = false;

    private void Update()
    {
        UpdateTimer(Time.deltaTime);
    }

    public void StartTimer()
    {
        startTime = CurrentTimerValue.Value = GetRandomTime();
        timerActive = true;
        TimerStartEvent.Raise();
    }

    /// <summary>
    /// Reduces the current timer value by deltaSeconds and fires the TimerEndEvent when timer value reaches 0.
    /// </summary>
    /// <param name="deltaSeconds"></param>
    private void UpdateTimer(float deltaSeconds)
    {
        if (!timerActive)
            return;

        if (CurrentTimerValue.Value > 0)
        {
            // Update values
            CurrentTimerValue.Value = Mathf.Clamp(CurrentTimerValue.Value - deltaSeconds, 0, MaxTimerValue);
            CurrentTimerPercentage.Value = CurrentTimerValue.Value / startTime;
            if (CurrentTimerValue.Value == 0)
            {
                // Disable timer
                timerActive = false;
                TimerEndEvent.Raise();
            }
        }
    }

    private float GetRandomTime()
    {
        return Random.Range(MinTimerValue, MaxTimerValue);
    }
}
