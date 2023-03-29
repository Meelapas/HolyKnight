using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
   [SerializeField] private float _bpm;
   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private Intervals[] _intervals;
   private void Update() {
    foreach (Intervals interval in _intervals)
    {
        float sampleTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalsLength(_bpm)));
        interval.CheckForNewIntervals(sampleTime);
    }
   }

[System.Serializable]
   public class Intervals
   {
        [SerializeField] private float _steps;
        [SerializeField] private UnityEvent _trigger;
        private int _lastinterval;

        public float GetIntervalsLength(float bpm)
        {
            return 60f / (bpm*_steps);
        }
        public void CheckForNewIntervals(float interval)
        {
            if(Mathf.FloorToInt(interval) != _lastinterval)
            {
                _lastinterval = Mathf.FloorToInt(interval);
                _trigger.Invoke();
            }
        }
   }
}
