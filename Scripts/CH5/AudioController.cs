using UnityEngine;
using System.Collections;

public class AudioController
{
  // initial audio levels for background and
  // sound FX
  public float AUDIO_LEVEL = 0.11f;
  public float FX_LEVEL = 0.11f;

  public AudioSource AUDIO_SOURCE;

  public void SetDefaultVolume()
  {
    this.AUDIO_SOURCE.volume = AUDIO_LEVEL;
  }

  public void MasterVolume(float volume)
  {
    this.AUDIO_LEVEL = volume;
    this.AUDIO_SOURCE.volume = AUDIO_LEVEL;
  }
}
