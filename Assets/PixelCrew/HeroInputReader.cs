using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private HeroInputAction _inputActions;

    private void Awake()
    {
        _inputActions = new HeroInputAction();
        _inputActions.Hero.SaySomething.performed += OnSaySomething;
        _inputActions.Hero.movement.performed += OnMovement;
        _inputActions.Hero.movement.canceled += OnMovement;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }
    
    private void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }
    

    private void OnSaySomething(InputAction.CallbackContext context)
    {
        _hero.SaySomething();
    }
}