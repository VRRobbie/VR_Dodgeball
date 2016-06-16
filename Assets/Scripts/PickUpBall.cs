using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class PickUpBall : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Shader defaultShader;
	[SerializeField] private Shader hoverShader;

	public GameObject holdLocation;
	public float throwForce;
	public bool holdingball = false;



	// Use this for initialization
	void Start () {
		if (holdLocation == null)
			holdLocation = GameObject.FindWithTag("HoldPosition");
		
	}
	
	// Update is called once per frame
	void Update () {

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
		if (m_InteractiveItem.GetComponent<Renderer> ().material.shader == hoverShader) 
			{
				Debug.Log ("Look and click brotha!");
				transform.parent = holdLocation.transform;
				holdingball = true;

			//while (holdingball) 
			//{
				//m_InteractiveItem.transform.parent = holdLocation.transform;
			//	m_InteractiveItem.transform.localPosition = new Vector3 (0, 0, 0);
			//}
				//m_InteractiveItem.GetComponent<Rigidbody>().velocity = m_InteractiveItem.transform.forward * throwForce;
			}
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
