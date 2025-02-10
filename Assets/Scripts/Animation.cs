using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;
    public string runAnimation = "Run";
    public string idleAnimation = "Idle";
    private void Update()
    {
        {

        }
        void PlayRun()
        {
            if (animator != null)
            {
                animator.Play(runAnimation);
            }
            else
            {
                Debug.LogWarning("Animator is not assigned!!!");
            }

            void PlayIdle()
            {
                if (animator != null)
                {
                    animator.Play(idleAnimation);
                }
                else
                {
                    Debug.LogWarning("Animator is not assigned!!!");
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    PlayRun();
                }
                else
                {
                    PlayIdle();
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    PlayRun();
                }
                else
                {
                    PlayIdle();
                }
            }
        }
    }
}