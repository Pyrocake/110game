using Godot;
using System;

public class Player : KinematicBody2D
{
	public AnimationPlayer animationPlayer = null;
	public AnimationTree animationTree = null;
	private AnimationNodeStateMachinePlayback animationState;

	//Movement Declarations
	const int ACCELERATION = 500;
	const float MAX_SPEED = 80;
	const int FRICTION = 500;

	public enum States {
		MOVE,
		ROLL,
		ATTACK
	};

	public States state = States.MOVE;
	public Vector2 velocity = Vector2.Zero;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello World!");
		GD.Print("Character Anim Setup");
		animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
		animationTree = (AnimationTree)GetNode("AnimationTree");
		animationState = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");
		animationTree.Active = true;
		GD.Print("Character Anim Setup Complete");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  	public override void _Process(float delta){
		switch (state) {
			case States.MOVE:
				moveState(delta);
				break;
			case States.ROLL:
				moveState(delta);
				break;
			case States.ATTACK:
				attackState(delta);
				break;
		}
		//moveState(delta);
  	}

	public void moveState(float delta) {
		Vector2 inputVector = new Vector2();
		inputVector.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		inputVector.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		inputVector = inputVector.Normalized();

		if (inputVector != Vector2.Zero){
			velocity = velocity.MoveToward(inputVector * MAX_SPEED, ACCELERATION * delta);

			animationTree.Set("parameters/Idle/blend_position", inputVector);
			animationTree.Set("parameters/Run/blend_position", inputVector);
			animationTree.Set("parameters/Attack/blend_position", inputVector);

			animationState.Travel("Run");
		} else {
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION * delta);
			animationState.Travel("Idle");
		}
		velocity = MoveAndSlide(velocity);

		if (Input.IsActionJustPressed("attack")) {
			state = States.ATTACK;
		}
	}

	public void attackState(float delta) {
		animationState.Travel("Attack");
		
		velocity = velocity.MoveToward(Vector2.Zero, FRICTION * delta);
		velocity = MoveAndSlide(velocity);
	}

	public void attackDone() {
		state = States.MOVE;
	}
}
