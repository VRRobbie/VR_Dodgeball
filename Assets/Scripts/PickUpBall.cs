using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.Networking;

public class PickUpBall : NetworkBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Material defaultMaterial;
	[SerializeField] private Material hoverMaterial;

	public Rigidbody rb;
	public GameObject holdLocation;
	public float throwForce;
	public bool holdingball = false;



	// Use this for initialization
	void Start () {
		if (holdLocation == null)
		{
			holdLocation = GameObject.FindWithTag ("HoldPosition");
		}
		rb = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if (holdingball && Input.GetMouseButtonDown (0)) 
		{
			ThrowBall ();
		}
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
		if (!holdingball && holdLocation.transform.childCount < 1) 
		{
			Debug.Log ("Picked up ball");
			m_InteractiveItem.transform.parent = holdLocation.transform;
			m_InteractiveItem.transform.position = holdLocation.transform.position;
			holdingball = true;
		}
		if (holdingball) 
		{
			rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
		}
	}

	private void ThrowBall()
	{
			holdingball = false;
			m_InteractiveItem.transform.parent = null;
			rb.constraints = RigidbodyConstraints.None;
			//m_InteractiveItem.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * throwForce;
			m_InteractiveItem.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
	}

	private void HighlightObject()
	{
		m_InteractiveItem.GetComponent<Renderer> ().material = hoverMaterial;
	}

	private void DeHighlightObject()
	{
		m_InteractiveItem.GetComponent<Renderer> ().material = defaultMaterial;
	}
}
