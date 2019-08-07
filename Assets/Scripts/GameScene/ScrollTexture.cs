using UnityEngine;

public class ScrollTexture : MonoBehaviour {
    public float velocityX, velocityY;

	private float m_currentOffsetX, m_currentOffsetY;

	private Renderer m_renderer;

	private bool m_isStopped = false;

	// Use this for initialization
	void Start () {
		m_renderer = GetComponent<Renderer> ();

		m_renderer.material.mainTextureOffset = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if (m_isStopped) {
			return;
		}

		m_currentOffsetX += velocityX;
		if (m_currentOffsetX > 1f) {
			m_currentOffsetX -= 1f;
		}

		m_currentOffsetY += velocityY;
		if (m_currentOffsetY > 1f) {
			m_currentOffsetY -= 1f;
		}

		m_renderer.material.mainTextureOffset = new Vector2(m_currentOffsetX, m_currentOffsetY);
	}

	void StopScroll(){

		m_isStopped = true;

	}

	void StartScroll(){

		m_isStopped = false;

	}
}
