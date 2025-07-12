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
            SlightlyRaised,
        }

        public static void PlayWithPitch(this AudioSource source, AudioClip clip, PitchModification pitchModification = PitchModification.None)
        {
            source.pitch = PitchToPlayWith(pitchModification);
            source.clip = clip;
            source.Play();
        }

        static float PitchToPlayWith(PitchModification pitchModification)
        {
            return pitchModification switch
            {
                PitchModification.None => 1,
                PitchModification.SlightlyLowered => Random.Range(0.85f, 1f),
                PitchModification.SlightlyRaised => Random.Range(1.0f, 1.15f),
                _ => throw new ArgumentOutOfRangeException(nameof(pitchModification), pitchModification, null)
            };
        }
    }
}