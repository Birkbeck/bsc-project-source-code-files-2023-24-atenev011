using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableAnimationClip 
{
    public string Name;
    public AnimationClip AnimationClip;

    public SerializableAnimationClip(string name, AnimationClip animation)
    {
        this.Name = name;
        this.AnimationClip = animation;
    }
}
