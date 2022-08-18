using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound Data", menuName = "Data/Sound Data", order = 1)]
public class SoundData : ScriptableObject
{
    [SerializeField] SoundClip[] soundClips;

    public SoundClip[] SoundClips => soundClips;
}
