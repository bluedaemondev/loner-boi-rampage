using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "Libraries/SoundLibrary", order = 0)]
public class SoundLibrary : ScriptableObject
{
    public List<NamedSound> levelSounds;

    public static AudioClip GetByName(string clipName, SoundLibrary lib)
    {
        return lib.levelSounds.SingleOrDefault(s => s.name == clipName).clip;
    }
}

[System.Serializable]
public class NamedSound
{
    public string name;
    public AudioClip clip;
}
