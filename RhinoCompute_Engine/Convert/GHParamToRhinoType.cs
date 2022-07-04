﻿using System;
using BH.oM.RemoteCompute.RhinoCompute;
using Grasshopper.Kernel;
using log = BH.Engine.RemoteCompute.Log;

namespace BH.Engine.RemoteCompute.RhinoCompute
{
    public static partial class Convert
    {
        public static Type GHParamToRhinoType(this Type t, bool warningIfNotFound = true)
        {
            if (!typeof(IGH_Param).IsAssignableFrom(t))
            {
                log.RecordWarning($"Input type {t.FullName} is not a Grasshopper parameter.");
                return null;
            }

            Type equivalentRhinoType = null;
            if (TypeConversions.GHParamToRhinoTypes.TryGetValue(t, out equivalentRhinoType))
                return equivalentRhinoType;

            if (warningIfNotFound)
                log.RecordWarning($"No equivalent Rhino type found for type: {t.FullName}");

            return null;
        }
    }
}