using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : PressurePlate 
{
	public int correct_color;

	private int color_index = -1;

	public Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow };

	/*
	private Color[] colors;

	void Start()
	{
		triggered = false;
		colors = new Color[] {
			Color.red,
			Color.green,
			Color.blue,
			Color.yellow

			
		};
	}
	*/

	void Start()
	{
		triggered = false;
	}

	public override void OnTriggerEnter2D (Collider2D col)
	{
		ChangeColor ();

	}

	void ChangeColor()
	{
		color_index += 1;
		if (color_index > 3) {
			color_index = 0;
		}
		transform.GetComponent<SpriteRenderer> ().color = colors [color_index];

		if (color_index == correct_color) {
			triggered = true;
		} 
		else {
			triggered = false;
		}


	}
		


}

//transform.GetComponent<SpriteRenderer>().color
//transform.GetComponent<Renderer> ().material.color = redcolor;

/*
if (change_color == 0) 
		{
			transform.GetComponent<SpriteRenderer> ().color = Color.cyan;
			change_color = 1;

			if (change_color == correctColor) {
				triggered = true;
			} 
			else {
				triggered = false;
			}
		} 

		else if (change_color == 1) 
		{
			transform.GetComponent<SpriteRenderer> ().color = Color.yellow;
			change_color = 2;
			if (change_color == correctColor) {
				triggered = true;
			}
			else {
				triggered = false;
			}
		} 

		else if (change_color == 2) 
		{
			transform.GetComponent<SpriteRenderer> ().color = Color.cyan;
			change_color = 1;
			if (change_color == correctColor) {
				triggered = true;
			}
			else {
				triggered = false;
			}
		}*/