﻿using Game.UI;
using Game.Weapon;
using UnityEngine;
namespace Game.Player
{
	public class PlayerController : Chicken
	{
		[SerializeField] private GameOverPopup _gameOverPopup;
		
		private Vector3 _input;

		protected override void OnStart()
		{
			WeaponController.SetWeapon(WeaponType.Spear);
		}

		protected override void OnUpdate()
		{
			MoveInput();
			AttackInput();
			InventoryInput();
		}

		private void MoveInput()
		{
			_input = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));

			ChickenController.UpdateMoveTarget(transform.position + _input);
			ChickenController.PlayMoveAnimation(_input.magnitude);
		}

		private void AttackInput()
		{
			if (Input.GetButtonDown("Attack"))
			{
				if (WeaponController.ActiveWeapon != null)
				{
					WeaponController.ActiveWeapon.Attack();
				}
			}
		}

		private void InventoryInput()
		{
			if (Input.GetButtonDown("Jump"))
			{
				Inventory.ThrowAway();
			}
		}

		protected override void OnDie()
		{
			_gameOverPopup.Open();
		}
	}
}