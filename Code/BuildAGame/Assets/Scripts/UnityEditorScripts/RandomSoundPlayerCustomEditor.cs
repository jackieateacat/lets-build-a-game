using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;

[CustomEditor(typeof(RandomSoundPlayEvent))]
public class RandomSoundPlayerCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RandomSoundPlayEvent randomSoundPlayEvent = (RandomSoundPlayEvent)target;

        if (GUILayout.Button("Preview Audio"))
        {
            GameObject tempObject = new GameObject("TempAudioObject");
            AudioSource source = tempObject.AddComponent<AudioSource>();
            UseDelayAsync(((int)randomSoundPlayEvent.Play(source))+1, source, tempObject);
        }
    }

    static void UseDelayAsync(int _delay, AudioSource _source, GameObject _tempObject)
    {
        DelayUseAsync(_delay, _source, _tempObject);
    }

    async static void DelayUseAsync(int _delay, AudioSource _source, GameObject _tempObject)
    {
        await Task.Delay(_delay*1000);
        DestroyImmediate(_source);
        _source = null;
        DestroyImmediate(_tempObject);
        _tempObject = null;
    }
}
