using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    public List<SerializableAnimationClip> animationClips = new List<SerializableAnimationClip>();

    void Start()
    {
        animator = GetComponent<Animator>();
        SetUpAnimationClips();
    }

    public void PlayAnimation(string animationName)
    {
        foreach (SerializableAnimationClip clip in animationClips)
        {
            if (clip.Name == animationName)
            {
                animator.SetTrigger(animationName);
                return;
            }
        }
    
        Debug.LogWarning("Animation clip " + animationName + " not found.");
    }

    private void SetUpAnimationClips()
    {
        AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;
        if (controller != null)
        {
            foreach (var layer in controller.layers)
            {
                foreach (var state in layer.stateMachine.states)
                {
                    string animationName = state.state.name;
                    AnimationClip clip = state.state.motion as AnimationClip;
                    animationClips.Add(new SerializableAnimationClip(animationName, clip));
                }
            }
        }
    }

    public AnimationClip GetAnimationClip(string name)
    {
        foreach (SerializableAnimationClip clip in animationClips)
        {
            if (clip.Name.Equals(name))
            {
                return clip.AnimationClip;
            }
        }

        Debug.LogWarning("No animation " + name + " was found");
        return null;
    }
}
