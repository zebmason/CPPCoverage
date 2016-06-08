﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using EnvDTE80;

namespace NubiloSoft.CoverageExt
{
    public class OutputWindow
    {
        public OutputWindow(DTE dte)
        {
            try
            {
                var d = dte as DTE2;
                if (d != null && d.ToolWindows != null && d.ToolWindows.OutputWindow != null)
                {
                    var o = d.ToolWindows.OutputWindow;
                    for (int i = 1; i <= o.OutputWindowPanes.Count; ++i)
                    {
                        var wnd = o.OutputWindowPanes.Item(i);
                        if (wnd.Name == "CodeCoverage")
                        {
                            window = wnd;
                            break;
                        }
                    }

                    if (window == null)
                    {
                        window = o.OutputWindowPanes.Add("CodeCoverage");
                    }
                }
            }
            catch
            {
            }
        }

        private OutputWindowPane window;

        public void WriteLine(string format, params object[] par)
        {
            if (window != null)
            {
                window.OutputString(string.Format(format, par) + "\r\n");
            }
        }
    }
}
