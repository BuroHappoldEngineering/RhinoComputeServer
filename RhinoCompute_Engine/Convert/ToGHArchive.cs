﻿
using BH.oM.RemoteCompute.RhinoCompute;
using GH_IO.Serialization;
using Grasshopper.Kernel;

namespace BH.Engine.RemoteCompute.RhinoCompute
{
    public static partial class Convert
    {
        public static GH_Archive ToGHArchive(this GH_Document ghDoc)
        {
            try
            {
                GH_Archive archive = new GH_Archive();
                archive.AppendObject(ghDoc, "Definition");
                return archive;
            }
            catch
            {
            }

            return null;
        }
    }
}