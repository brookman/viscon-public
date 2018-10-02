using System;
using UnityEngine;

public class SbbRotationMethod : MonoBehaviour, Clock.RotationMethod
{
    public Clock.HandRotation GetHandRotationForTime(TimeSpan timeSinceMidnight)
    {
        var sekundenSprungDuration = 1.5f;
        var minuteHandTransitionDuration = 0.5f;

        var minutesOfHourFloat = (float) (timeSinceMidnight.TotalMinutes % 60.0f);
        var minutesOfHour = (int) minutesOfHourFloat;

        var s = Mathf.Min((float) (timeSinceMidnight.TotalSeconds % 60.0f) / (60.0f - sekundenSprungDuration), 1.0f);
        var m = LerpOutExpo(minutesOfHour - 1, minutesOfHour, minutesOfHourFloat - minutesOfHour, minuteHandTransitionDuration / 60f) / 60.0f;
        var h = (float) (timeSinceMidnight.TotalHours % 12.0f) / 12.0f;

        return new Clock.HandRotation
        {
            s = s,
            m = m,
            h = h
        };
    }

    private static float LerpOutExpo(float from, float to, float t, float d)
    {
        if (t <= 0) return from;
        if (t >= d) return to;

        return (to - from) * (-Mathf.Pow(2, -10 * t / d) + 1) + from;
    }
}