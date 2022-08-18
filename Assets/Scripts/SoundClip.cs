using UnityEngine;

[System.Serializable]
public class SoundClip
{
    [SerializeField] string _name;
    [SerializeField] AudioClip _clip;
    [SerializeField][Range(0, 1)] float _volume;

    public string Name { get { return _name; } set { _name = value; } }

    public AudioClip Clip { get { return _clip; } set { _clip = value; } }

    public float Volume
    {
        get { return _volume; }
        set
        {
            if (value < 0 || value > 1) return;
            _volume = value;
        }
    }
}
