using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public struct HandRotation
    {
        public float s;
        public float m;
        public float h;
    }

    public interface RotationMethod
    {
        HandRotation GetHandRotationForTime(TimeSpan timeSinceMidnight);
    }

    public Transform SecondHand;
    public Transform MinuteHand;
    public Transform HourHand;

    private RotationMethod HandRotationMethod;

    void Start()
    {
        HandRotationMethod = GetComponent<RotationMethod>();
    }

    void Update()
    {
        var time = TimeProvider.GetTime();

        if (HandRotationMethod != null)
        {
            var handRotation = HandRotationMethod.GetHandRotationForTime(time);

            SecondHand.localRotation = Quaternion.Euler(0, 0, handRotation.s * 360);
            MinuteHand.localRotation = Quaternion.Euler(0, 0, handRotation.m * 360);
            HourHand.localRotation = Quaternion.Euler(0, 0, handRotation.h * 360);
        }
    }
}