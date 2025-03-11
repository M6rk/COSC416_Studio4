using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new();
    public UnityEvent OnJump = new();
    public UnityEvent OnDash = new();
    public UnityEvent OnSettingsMenu = new();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            OnSettingsMenu?.Invoke();
        }
        if(GameManager.Instance.IsSettingsMenuActive) return;
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnDash?.Invoke();
        }
        OnMove?.Invoke(input.normalized);
    }
}
