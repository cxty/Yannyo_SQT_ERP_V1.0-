using System;
using System.Collections.Generic;
using System.Text;
using Yannyo.BLL;
using Yannyo.Config;
using Yannyo.Entity;
using Yannyo.Public;
using Yannyo.Public.ScheduledEvents;

namespace Yannyo.Event
{
    public class StatEvent : IEvent
    {
        public void Execute(object state)
        { 
            //执行计划任务

            //更新缓存
            Caches.ReSet();
        }
    }
}
