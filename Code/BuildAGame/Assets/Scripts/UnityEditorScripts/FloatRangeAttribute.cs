using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public sealed class FloatRangeAttribute : PropertyAttribute
{
    public readonly float min;
    public readonly float max;

    public FloatRangeAttribute(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}
