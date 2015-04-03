﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.ModAPI;
using EssentialsPlugin.Utility;
using VRageMath;

using SEModAPIInternal.API.Entity;
using SEModAPIInternal.API.Entity.Sector.SectorObject;
using SEModAPIInternal.API.Entity.Sector.SectorObject.CubeGrid.CubeBlock;
using SEModAPIInternal.API.Common;


namespace EssentialsPlugin.ChatHandlers
{
	public class HandleFaction : ChatHandlerBase
	{
		public override string GetHelp()
		{
			return "Sends a private message to all faction members that are online.  Usage: /faction <msg>";
		}

		public override string GetCommandText()
		{
			return "/faction";
		}

		public override bool IsAdminCommand()
		{
			return false;
		}

		public override bool AllowedInConsole()
		{
			return true;
		}

		public override bool IsClientOnly()
		{
			return true;
		}

		public override bool HandleCommand(ulong userId, string[] words)
		{
			if(words.Count() < 1)
			{
				Communication.SendClientMessage(userId, "/message Server " + GetHelp());
			}

			string userName = PlayerMap.Instance.GetPlayerNameFromSteamId(userId);
			Communication.SendFactionClientMessage(userId, string.Format("/message F:{0} {1}", userName, string.Join(" ", words)));
//			Communication.SendClientMessage(userId, string.Format("/message Server Sent faction message"));
			return true;
		}
	}
}
