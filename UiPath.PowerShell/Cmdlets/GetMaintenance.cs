﻿using System.Collections.Generic;
using System.Dynamic;
using System.Management.Automation;
using UiPath.PowerShell.Util;
using UiPath.Web.Client201910;

namespace UiPath.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Returns a Maintenance session summary</para>
    /// <para type="description">This cmdlet will return a summary of the current or last Maintenance session with the following structure</para>
    /// <para type="description">State: None | Draining | Suspended</para>
    /// <para type="description">MaintenanceLogs      : {{ State = None, TimeStamp =  }, { State = Draining, TimeStamp =  }, { State = Suspended, TimeStamp =  }}</para>
    /// <para type="description">JobsStopped          : 0</para>
    /// <para type="description">JobsKilled           : 0</para>
    /// <para type="description">SchedulesFired       : 0</para>
    /// <para type="description">SystemSchedulesFired : 0</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.Maintenance)]
    public class GetMaintenance : AuthenticatedCmdlet
    {
        protected override void ProcessRecord()
        {
            var result = HandleHttpOperationException(() => Api_19_10.Maintenance.Get());
            WriteObject(result.ToDynamic());
        }
    }
}