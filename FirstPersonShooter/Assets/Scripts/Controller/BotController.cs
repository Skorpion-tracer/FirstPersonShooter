﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace Geekbrains
{
    public sealed class BotController : BaseController, IExecute, IInitialization
    {
        private readonly int _countBot = 20;
        private readonly List<Bot> _botList  = new List<Bot>();

        public void Initialization()
        {
            for (var index = 0; index < _countBot; index++)
            {
                var tempBot = Object.Instantiate(ServiceLocatorMonoBehaviour.GetService<Reference>().Bot,
                    Patrol.GenericPoint(ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform),
                    Quaternion.identity);

                tempBot.Agent.avoidancePriority = index;
                tempBot.Target = ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform; 
                //todo разных противников
                AddBotToList(tempBot);
            }
        }

        private void AddBotToList(Bot bot)
        {
            if (!_botList.Contains(bot))
            {
                _botList.Add(bot);
                bot.OnDieChange += RemoveBotToList;
            }
        }

        private void RemoveBotToList(Bot bot)
        {
            if (!_botList.Contains(bot))
            {
                return;
            }

            bot.OnDieChange -= RemoveBotToList;
            _botList.Remove(bot);
        }

        public void Execute()
        {
            if (!IsActive)
            {
                return;
            }

            for (var i = 0; i < _botList.Count; i++)
            {
                _botList[i].Execute();
            }
        }
    }
}
