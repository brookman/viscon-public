using System;
using UnityEngine;

public class SimpleRotationMethod : MonoBehaviour, Clock.RotationMethod
{
    public Clock.HandRotation GetHandRotationForTime(TimeSpan timeSinceMidnight)
    {
        double minutesSinceMidnight = timeSinceMidnight.TotalMinutes; // decimal: e.g. 823.384
        double hoursSinceMidnight = timeSinceMidnight.TotalHours; // decimal: e.g. 19.290

        // Exercise:
        var rotationSeconds = 0.0; // value 0.0 - 1.0
        var rotationMinutes = 0.0; // value 0.0 - 1.0
        var rotationHours = 0.0; // value 0.0 - 1.0

        return new Clock.HandRotation
        {
            s = (float) rotationSeconds,
            m = (float) rotationMinutes,
            h = (float) rotationHours
        };
    }
}