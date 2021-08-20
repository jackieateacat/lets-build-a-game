using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChaotic : MonoBehaviour
{
    // Reset my oscillator. This is like a heartbeat
    
    [Range(-5.0f, 5.0f)]
    [SerializeField] float kValue;

    [SerializeField] float timeToShift;

    [SerializeField] AudioSource audioRef;

    [SerializeField] List<float> referenceList = new List<float>();

    [SerializeField] float matchPercent;

    [SerializeField] float matchZeroCutoff;

    private List<float> monitorList = new List<float>();

    private float xNext = .00001f;

    private float timePassed;

    private float lastKValue;

    bool monitor = true;

    int sampleSize = 10;

    private void Start()
    {
        lastKValue = kValue;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if(lastKValue != kValue)
        {
            lastKValue = kValue;
            xNext = .00001f;

            monitor = true;

            // Clear the list
            monitorList = new List<float>();
        }

        if(timePassed >= timeToShift)
        {
            timePassed = 0.0f;
            //ChaoticOne();
            //ChaoticTwo();
            ChaoticThree();

            if(monitor)
            {
                MonitorPitch();
            }
        }
    }


    // TODO: Refactor so new list is compared with a reference list and percent match determined
    private void MonitorPitch()
    {
        if(monitorList.Count < sampleSize)
        {
            monitorList.Add(audioRef.pitch);
            CalculateMatch();
        }
        else
        {
            monitor = false;
        }
    }

    private void CalculateMatch()
    {
        List<float> matchList = new List<float>();
        
        for (int i = 0; i < monitorList.Count; i++)
        {
            matchList.Add(Mathf.Abs(referenceList[i] - monitorList[i]));
        }

        float sum = 0.0f;

        foreach(float entry in matchList)
        {
            sum += entry;
        }

        sum = sum / matchList.Count;
  
        matchPercent = Mathf.Clamp(-1 / matchZeroCutoff * sum + 1, 0.0f, 1.0f);
    }


    private void ChaoticOne()
    {
        float result = kValue * xNext * (1 - xNext);
        xNext = result;

        audioRef.pitch = result;
    }

    private void ChaoticTwo()
    {
        // Good beats at a value of .3
        float result = - kValue * kValue - xNext - kValue;
        xNext = result;

        audioRef.pitch = result;
    }

    private void ChaoticThree()
    {
        // .727 kValue
        // THIS ONE!
        float result = xNext * xNext - xNext - kValue;
        xNext = result;

        audioRef.pitch = result;
    }
}
