﻿using System;
using BH.oM.RemoteCompute;
using BH.oM.RemoteCompute.RhinoCompute;
using compute.geometry;
using Grasshopper.Kernel;

namespace BH.Engine.RemoteCompute.RhinoCompute
{
    public static partial class Create
    {
        public static bool TryCreateGrasshopperDefinition(this ResthopperInput resthopperInput, out GrasshopperDefinition definition)
        {
            definition = null;

            if (string.IsNullOrWhiteSpace(resthopperInput.Script))
                throw new Exception("Missing script input.");

            Uri scriptUrl = null;
            if (Uri.TryCreate(resthopperInput.Script, UriKind.Absolute, out scriptUrl))
                definition = GrasshopperDefinitionUtils.FromUrl(scriptUrl);

            if (definition == null)
            {
                definition = GrasshopperDefinitionUtils.FromBase64String(resthopperInput.Script);

                if (definition == null)
                    throw new Exception("Unable to convert Base-64 encoded Grasshopper script to a GrasshopperDefinition object.");
            }

            return true;
        }
    }
}