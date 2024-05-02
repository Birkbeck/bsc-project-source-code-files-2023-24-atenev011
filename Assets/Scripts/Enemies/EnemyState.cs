using UnityEngine;

public enum State
{
    ALIVE,
    KICKED,
    DEAD
}

public class EnemyState : MonoBehaviour
{
    public State state;
    public EnemyAnimation EnemyAnimation;

    private void Start()
    {
        state = State.ALIVE;
    }

    public void Kick()
    {
        state = State.KICKED;
        EnemyAnimation.ToggleKickedState();
    }
}
