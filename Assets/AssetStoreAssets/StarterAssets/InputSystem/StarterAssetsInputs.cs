using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool throwP;
		public bool Cycle;
		public bool interact;
		public bool craft;
		public bool InvCycle;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
        public void OnThrow(InputValue value)
        {
            ThrowInput(value.isPressed);
        }

        public void OnCycle(InputValue value)
        {
            CycleInput(value.isPressed);
        }
        public void OnInteract(InputValue value)
        {
            InteractInput(value.isPressed);
        }
        public void OnCraft(InputValue value)
        {
			craft = value.isPressed;
        }
		public void OnInventoryCycle(InputValue value)
		{
			InvCycle = true;
		}
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
        public void ThrowInput(bool newThrowState)
        {
            throwP = newThrowState;
        }

        public void CycleInput(bool newCycleState)
        {
            Cycle = newCycleState;
        }
        public void InteractInput(bool newInteractState)
        {
            interact = newInteractState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}