using UnityEngine;

public class AnimatorRobot : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (animator == null)
        {
            Debug.LogError("Animator não encontrado!");
        }
    }

    public void TriggerAnimation(string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
            Debug.Log($"Trigger ativado: {triggerName}");
        }
    }
}
