﻿using UnityEngine;
using UnityEngine.Networking;

public class SoundNetworkActions : NetworkBehaviour
{
	[Command]
	public void CmdPlaySound(string soundName, Vector3 pos)
	{
		RpcPlayNetworkSound(soundName, pos);
	}

	// fixme: unsecure af, lets client play arbitrary sounds at will ^v

	[Command]
	public void CmdPlaySoundAtPlayerPos(string soundName)
	{
		RpcPlayNetworkSound(soundName, transform.position, 1f);
	}

	[ClientRpc]
	public void RpcPlayNetworkSound(string soundName, Vector3 pos, float pitch = 1f)
	{
		SoundManager.PlayAtPosition(soundName, pos, pitch);
	}
}