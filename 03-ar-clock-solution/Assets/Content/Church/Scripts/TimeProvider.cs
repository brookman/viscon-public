using System;

public class TimeProvider
{
    private static bool overrideTimeEnabled;
    private static TimeSpan overrideTime;

    public static TimeSpan GetTime()
    {
        if (!overrideTimeEnabled)
        {
            return DateTime.Now.TimeOfDay;
        }

        return overrideTime;
    }

    public static void UpdateOverrideTime(TimeSpan newOverrideTime)
    {
        overrideTime = newOverrideTime;
    }

    public static void SetOverrideTimeEnabled(bool enabled)
    {
        overrideTimeEnabled = enabled;
    }
}