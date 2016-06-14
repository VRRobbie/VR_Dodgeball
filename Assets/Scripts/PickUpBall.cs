using UnityEngine;
using System.Collections;
//using UnityEngine.VR;
using VRStandardAssets.Utils;

public class PickUpBall : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Shader defaultShader;
	[SerializeField] private Shader hoverShader;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//hoverShader = Shader.Find ("Highlight");
	
	}

	private void OnEnable()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleOver()
	{
		Debug.Log ("Looking");
		HighlightObject ();
	}

	private void HandleOut()
	{
		Debug.Log ("Not looking");
		DeHighlightObject ();
	}

	private void HandleClick()
	{
		Debug.Log ("Look and click brotha!");
	}

	private void HighlightObject()
	{
		m_InteractiveItem.GetComponent<Renderer> ().material.shader = hoverShader;
	}

	private void DeHighlightObject()
	{
		m_InteractiveItem.GetComponent<Renderer> ().material.shader = defaultShader;
	}
}
