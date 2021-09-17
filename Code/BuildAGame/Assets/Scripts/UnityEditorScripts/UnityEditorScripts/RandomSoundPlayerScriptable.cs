using UnityEngine;

public abstract class RandomSoundPlayerScriptable : ScriptableObject
{
    public abstract float Play(AudioSource _source);
}