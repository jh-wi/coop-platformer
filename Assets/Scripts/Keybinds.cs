using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Keybinds {
	
	public static KeyCode bearJump = KeyCode.W;
	public static KeyCode bearLeft = KeyCode.A;
	public static KeyCode bearDown = KeyCode.S;
	public static KeyCode bearRight = KeyCode.D;
	public static KeyCode bearDash = KeyCode.LeftShift;
	
	public static KeyCode birdJump = KeyCode.UpArrow;
	public static KeyCode birdLeft = KeyCode.LeftArrow;
	public static KeyCode birdDown = KeyCode.DownArrow;
	public static KeyCode birdRight = KeyCode.RightArrow;
	
	public static void ResetControls() {
		bearJump = KeyCode.W;
		bearJump = KeyCode.A;
		bearJump = KeyCode.S;
		bearJump = KeyCode.D;
		bearJump = KeyCode.LeftShift;
		
		birdJump = KeyCode.UpArrow;
		birdJump = KeyCode.LeftArrow;
		birdJump = KeyCode.DownArrow;
		birdJump = KeyCode.RightArrow;
	}
	
}
