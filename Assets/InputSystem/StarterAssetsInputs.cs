using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
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
		public bool aim;
		public bool shoot;
		public bool weaponSwitch1;
		public bool weaponSwitch2;
		public bool weaponSwitch3;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
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

		public void OnAim(InputValue value)
        {
			AimInput(value.isPressed);
        }

		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}

		public void OnWeaponSwitch1(InputValue value)
		{
			WeaponSwitch1Input(value.isPressed);
		}

		public void OnWeaponSwitch2(InputValue value)
		{
			WeaponSwitch2Input(value.isPressed);
		}

		public void OnWeaponSwitch3(InputValue value)
		{
			WeaponSwitch3Input(value.isPressed);
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

		public void AimInput(bool newAimState)
		{
			aim = newAimState;
		}

		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}

		public void WeaponSwitch1Input(bool newWeaponSwitch1State)
		{
			weaponSwitch1 = newWeaponSwitch1State;
		}

		public void WeaponSwitch2Input(bool newWeaponSwitch2State)
		{
			weaponSwitch2 = newWeaponSwitch2State;
		}

		public void WeaponSwitch3Input(bool newWeaponSwitch3State)
		{
			weaponSwitch3 = newWeaponSwitch3State;
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