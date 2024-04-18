using UnityEngine;

public class SpeedController
{
    public float SpeedIncreaseInterval { get; }
    public float SpeedIncreaseAmount { get; }
    public float DelayAfterSpeedIncrease { get; }
    public float CurrentSpeed { get; set; }
    public float TimeSinceLastSpeedIncrease { get; private set; }
    public float TimeSinceLastSpeedIncreaseStart { get; private set; }

    public SpeedController(float speedIncreaseInterval, float speedIncreaseAmount, float delayAfterSpeedIncrease, float initialSpeed)
    {
        SpeedIncreaseInterval = speedIncreaseInterval;
        SpeedIncreaseAmount = speedIncreaseAmount;
        DelayAfterSpeedIncrease = delayAfterSpeedIncrease;
        CurrentSpeed = initialSpeed;
    }

    public bool CanIncreaseSpeed()
    {
        TimeSinceLastSpeedIncrease += Time.deltaTime;
        TimeSinceLastSpeedIncreaseStart += Time.deltaTime;

        return TimeSinceLastSpeedIncrease >= SpeedIncreaseInterval && TimeSinceLastSpeedIncreaseStart >= DelayAfterSpeedIncrease;
    }

    public void ResetTimeSinceLastSpeedIncrease()
    {
        TimeSinceLastSpeedIncrease = 0f;
        TimeSinceLastSpeedIncreaseStart = 0f;
    }
}