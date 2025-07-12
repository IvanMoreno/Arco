using UnityEngine;

namespace Stacklands
{
    public static class Sound
    {
        public static void PlayTweakingPitch(this AudioSource source, AudioClip clip)
        {
            source.pitch = Random.Range(0.9f, 1.1f);
            source.clip = clip;
            source.Play();
        }
    }
}