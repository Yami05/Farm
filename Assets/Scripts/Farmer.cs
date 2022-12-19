using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class Farmer : MonoBehaviour
{
	[SerializeField] private float movementSpeed;
	[SerializeField] private int workAmount;

	private AnimationController animationController;
	private SoilGrid currentGrid;
	private SkinnedMeshRenderer skinnedMesh;

	private Vector3 startGridPos;

	private int currentAnimCount = 0;
	private int totalAnimCount;


	private void Awake()
	{
		animationController = GetComponentInChildren<AnimationController>();
		skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();
	}

	public void StartWorking(SoilGrid[] soilGrids)
	{
		StartCoroutine(IEWork(soilGrids));
	}

	private IEnumerator IEWork(SoilGrid[] grids)
	{
		WaitForFixedUpdate wait = new WaitForFixedUpdate();

		int iterator = 0;
		int workIndex = workAmount;

		SoilGrid targetGrid = grids[iterator++];

		Vector3 targetPos = targetGrid.transform.position + Vector3.forward * -targetGrid.Offset;

		for (int i = 0; i < workIndex; i++)
		{
			while ((targetPos - transform.position).magnitude > .1f)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.fixedDeltaTime);
				yield return wait;
			}

			OnGrid(targetGrid);

			yield return new WaitForSeconds(3);

			animationController.PlayAnim(AnimType.Walk);

			currentAnimCount = 0;

			targetGrid = grids[iterator++];

			targetPos = targetGrid.transform.position + Vector3.forward * -targetGrid.Offset;
		}

		WorkEnded();
	}

	private void OnGrid(SoilGrid currentGrid)
	{
		currentGrid.ChangeType(PlayAnim);
		this.currentGrid = currentGrid;
	}

	private void PlayAnim(AnimType type, int totalAnimCount)
	{
		animationController.PlayAnim(type);
		this.totalAnimCount = totalAnimCount;
	}

	private void OnAnimationEnd()
	{
		currentAnimCount++;
		if (currentAnimCount == totalAnimCount)
		{
			print("aa");
			currentGrid.InitType();
		}
	}

	private void WorkEnded()
	{
		//Particle
		skinnedMesh.enabled = false;
		transform.DOMove(startGridPos, 0.4f).OnComplete(() => skinnedMesh.enabled = true);
		ActionManager.OnFarmerRunEnd?.Invoke();
		animationController.PlayAnim(AnimType.Idle);
	}

	public void SetFirstPos(Transform startGrid)
	{
		startGridPos = startGrid.position;
	}

}
