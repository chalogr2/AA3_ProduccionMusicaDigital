using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowFilterOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject triggerObject;
    private AudioLowPassFilter lpf;
    private int defaultValue = 22000;
    private int newValue = 3000;

    // Start is called before the first frame update
    void Start()
    {
        lpf = GetComponent<AudioLowPassFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerObject.transform.position, triggerObject.transform.position) < 3)
        {
            StartCoroutine(decreaseCutoff(lpf, newValue));
        }
        else
        {
            if(lpf.cutoffFrequency < defaultValue)
            {
                StartCoroutine(increaseCutoff(lpf, defaultValue));
            }
        }
    }

    static IEnumerator decreaseCutoff(AudioLowPassFilter _lpf, int targetval)
    {
        while (_lpf.cutoffFrequency > targetval)
        {
            _lpf.cutoffFrequency -= 100;
            yield return new WaitForSeconds(.1f);
        }
    }

    static IEnumerator increaseCutoff(AudioLowPassFilter _lpf, int targetval)
    {
        while (_lpf.cutoffFrequency < targetval)
        {
            _lpf.cutoffFrequency += 100;
            yield return new WaitForSeconds(.1f);
        }
    }
}
