using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		public StoneSpawner m_stoneSpawner;

		[SerializeField]
		public UIScorePanel m_scorePanel;

		[SerializeField]
		public GameSettings m_settings;

		[SerializeField]
		public GameObject[] m_UIObjects;


		public bool isLosed;


		private List<GameObject> m_stones = new();
		private int m_score = 0;
		private int m_maxScore = 0;
		private float m_timer = 0f;
		private float m_delay = 0f;
		private float m_maxDelay = 0f;
		

		private void Start()
		{
			SetMainMenuState();
		}

		public void SetMainMenuState()
		{
			ClearStones();
			enabled = false;
			foreach(GameObject uiElement in m_UIObjects)
            {
                if (uiElement.tag == "MainMenu")
                {
					uiElement.SetActive(true);
                }
				else uiElement.SetActive(false);
			}
			RefreshScore(m_maxScore);
		}

		private float CalcNextDelay()
		{
			var delay = Random.Range(m_settings.minDelay, m_maxDelay);
			//Debug.Log($"CalcNextDelay - delay: {delay} - maxDelay: {m_maxDelay}");
			return delay;
		}

		public void SetGameState()
		{
			m_delay = CalcNextDelay();
			m_maxDelay = m_settings.maxDelay;
			foreach (GameObject uiElement in m_UIObjects)
			{
				if (uiElement.tag == "Game")
				{
					uiElement.SetActive(true);
				}
				else uiElement.SetActive(false);
			}
			enabled = true;
			m_score = 0;
			RefreshScore(m_score);
			StartGame();
		}

		private void StartGame()
		{
			GameEvents.onGameOver += OnGameOver;
			isLosed = false;
		}

		private void OnGameOver()
		{
			GameEvents.onGameOver -= OnGameOver;
			Debug.Log("Game Over");
			isLosed = true;
			SetMainMenuState();
		}

		private void ClearStones()
		{
			foreach (GameObject stone in m_stones)
			{
				Destroy(stone);
			}
			m_stones.Clear();
		}

		private void Update()
		{
			m_timer += Time.deltaTime;
			if (m_timer >= m_delay)
            {
                var stone = m_stoneSpawner.Spawn();
                m_stones.Add(stone);
                m_timer -= m_delay;
                m_delay = CalcNextDelay();
                CalcMaxDelay();
            }
        }

        private void CalcMaxDelay()
        {
            if (m_maxDelay <= 0.25)
                m_maxDelay = 0.25f;
            else
                m_maxDelay -= m_settings.stepDelay;
        }

        public void RefreshScore(int score)
		{
			m_scorePanel.SetScore(score);
		}

		public void OnCollisionStone(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<Stone>(out var stone))
			{
				stone.SetAffect(false);
				var contact = collision.contacts[0];

				var stick = contact.thisCollider.GetComponent<Stick>();
				
				var body = stone.GetComponent<Rigidbody>();
				body.AddForce(stick.dir * m_settings.power, ForceMode.Impulse);

				m_score++;
				m_maxScore = Mathf.Max(m_score, m_maxScore);
				RefreshScore(m_score);

				Physics.IgnoreCollision(contact.thisCollider, contact.otherCollider, true);
			}
		}

		private void OnDestroy()
		{
			GameEvents.onGameOver -= OnGameOver;
		}
	}
}