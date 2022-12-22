using System.Collections.Generic;
using UnityEngine;

namespace Game
{

	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private UIScorePanel m_scorePanel;
		[SerializeField]
		private CameraController m_cameraController;

		public int m_score = 0;
		public int m_maxScore = 0;

		public int maxScore => m_maxScore;
		public int score => m_score;

		[SerializeField] private MainMenuState m_mainMenuState;
		[SerializeField] private GameState m_gameState;
		[SerializeField] private GameObject m_gameOverText;
		[SerializeField] private Animator m_gameOverAnim;

		public bool isLosed;

		private const string saveKey= "mainSave";

		private void Start()
		{
			MainMenuState();
			Application.targetFrameRate = 30;
			m_gameOverText.SetActive(false);
		}

		private void MainMenuState()
		{
			m_mainMenuState.enabled = true;
			m_gameState.enabled = false;
		}

		private void GameState()
		{
			m_gameOverText.SetActive(false);
			m_mainMenuState.enabled = false;
			m_gameState.enabled = true;
		}

		public void StartGame()
		{
			isLosed = false;
			GameState();
			m_cameraController.m_animator.SetTrigger("GameStarted");
		}

		public void GameOver()
		{
			isLosed = true;
			MainMenuState();
			m_cameraController.m_animator.SetTrigger("GameEnded");
			m_gameOverText.SetActive(true);
			m_gameOverAnim.SetTrigger("GameOver");
		}

		public void IncScore()
		{
			m_score++;
			m_maxScore = Mathf.Max(m_score, m_maxScore);
		}

		public void ResetScore()
		{
			m_score = 0;
		}

		public void RefreshScore(int score)
		{
			m_scorePanel.SetScore(score);
		}

	

		
	}
}