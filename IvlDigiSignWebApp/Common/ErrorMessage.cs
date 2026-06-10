using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IvlDigiSignWebApp.Common
{
    public class ErrorMessage
    {


        #region Functions

        public void CreateLogFile(String Pagename, String FunctionName, String ErrorMsg, String ErromsgName)
        {
            try
            {
                String Content = "{0}:{1}:{2}: Message{3}: {4}";
                int checkIfNeeded = 1;
                if (checkIfNeeded == 1)
                {
                    String fullPath = "IVL_DigiSignWeb_ErrorLog_On_" + DateTime.Now.ToLongDateString().ToString() + ".txt";

                    fullPath = HttpContext.Current.Server.MapPath("Log//") + "" + fullPath;

                    String PageName = Pagename.Substring(Pagename.LastIndexOf("/") + 1, ((Pagename.Length) - (Pagename.LastIndexOf("/") + 1)));
                    if (ErromsgName.Trim() == "")
                    {
                        Content = String.Format(Content, DateTime.Now.ToString(), PageName, FunctionName, ErromsgName, ErrorMsg);
                    }
                    else
                    {
                        ErromsgName = "(" + ErromsgName.Trim() + ")";
                        Content = String.Format(Content, DateTime.Now.ToString(), PageName, FunctionName, ErromsgName, ErrorMsg);
                    }


                    if (!Directory.Exists(fullPath))
                    {
                        if (!File.Exists(fullPath))
                        {
                            File.WriteAllText(fullPath, Content + Environment.NewLine);
                        }
                        else
                        {
                            File.AppendAllText(fullPath, Content + Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        #endregion

    }
}