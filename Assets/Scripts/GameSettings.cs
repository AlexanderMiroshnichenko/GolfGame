using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings")]
	public class GameSettings : ScriptableObject
	{
		[Header("Stone")]
		[SerializeField] private float m_minDelay = 1f;
		public float minDelay => m_minDelay;

		[SerializeField] private float m_maxDelay = 5f;
		public float maxDelay => m_maxDelay;

		[SerializeField] private float m_stepDelay = 0.25f;
		public float stepDelay => m_stepDelay;


		[Header("Tool")]

		[SerializeField] private float m_speed = 2f;
		public float speed => m_speed;

		[SerializeField] private float m_power = 100f;
		public float power => m_power;


	}

}