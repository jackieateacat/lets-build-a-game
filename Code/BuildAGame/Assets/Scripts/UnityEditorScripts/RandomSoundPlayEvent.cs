using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Audio Events/RandomAudio")]
public class RandomSoundPlayEvent : RandomSoundPlayerScriptable
{
    [Tooltip("List of clips to be selected randomly")]
    [SerializeField]
    AudioClip[] clips;

    [Tooltip("Range to select random volume to play")]
    [SerializeField]
    [FloatRange(0f, 1f)]
    Vector2 volumeRange;

    [Tooltip("Range to select random pitch to play")]
    [SerializeField]
    [FloatRange(0f, 2f)]
    Vector2 pitchRange;

    public override float Play(AudioSource _source)
    {
        if (clips.Length == 0) return 0;

        _source.clip = clips[Random.Range(0, clips.Length)];
        _source.volume = Random.Range(volumeRange.x, volumeRange.y);
        _source.pitch = Random.Range(pitchRange.x, pitchRange.y);
        _source.Play();
        return _source.clip.length;
    }
}
