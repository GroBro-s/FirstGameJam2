using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 0f;
    private Rigidbody2D rb = null;

	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
		if (IsGliding && rb.velocity.y < 0f && Mathf.Abs(rb.velocity.y) > fallSpeed)
		{
			rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * fallSpeed);
        }

        if(Input.GetButtonDown("Jump"))
        {
            StartGliding();
        }

        if(Input.GetButtonUp("Jump"))
        {
            StopGliding();
        }
    }

    private void StartGliding()
    {
        IsGliding = true;
    }

    private void StopGliding()
    {
        IsGliding = false;
    }

    private bool IsGliding { get; set; } = false;
}
