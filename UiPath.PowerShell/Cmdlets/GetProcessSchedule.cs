﻿using System.Management.Automation;
using UiPath.PowerShell.Models;
using UiPath.PowerShell.Util;
using UiPath.Web.Client20181;

namespace UiPath.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, Nouns.ProcessSchedule)]
    public class GetProcessSchedule : FilteredIdCmdlet
    {
        [Filter]
        [Parameter(ParameterSetName = "Filter")]
        public string Name { get; internal set; }

        protected override void ProcessRecord()
        {
            ProcessImpl(
                (filter, top, skip) => Api.ProcessSchedules.GetProcessSchedules(filter: filter, top: top, skip: skip, count: false),
                id => Api.ProcessSchedules.GetById(id),
                dto => ProcessSchedule.FromDto(dto));
        }
    }
}
