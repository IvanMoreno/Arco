using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Stacklands
{
    public static class Sound
    {
        public enum PitchModification
        {
            None,
            SlightlyLowered,
            SlightlyModified,
            SlightlyRaised,
        }
        
        public static void PlayWithPitch(this AudioSource source, AudioClip clip, PitchModification pitchModification)
        {
            source.pitch = PitchToPlayWith(pitchModification);
            source.clip = clip;
            source.Play();
        }
        
        public static void PlayWithPitch(this AudioSource source, PitchModification pitchModification)
        {
            source.pitch = PitchToPlayWith(pitchModification);
            source.Play();
        }

        static float PitchToPlayWith(PitchModification pitchModification)
        {
            return pitchModification switch
            {
                PitchModification.None => 1,
                PitchModification.SlightlyLowered => Random.Range(0.85f, 1f),
                PitchModification.SlightlyModified => Random.Range(0.95f, 1.05f),
                PitchModification.SlightlyRaised => Random.Range(1.0f, 1.15f),
                _ => throw new ArgumentOutOfRangeException(nameof(pitchModification), pitchModification, null)
            };
        }
    }
}