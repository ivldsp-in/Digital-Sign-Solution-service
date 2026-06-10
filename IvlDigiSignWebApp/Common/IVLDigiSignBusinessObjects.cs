using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvlDigiSignWebApp.Common
{
    public  class IVLDigiSignBusinessObjects
    {

        public static string UserName { set; get; }
        public static string Password { set; get; }
        public static float LocllX { set; get; }
        public static float LocllY { set; get; }
        public static float LocX { set; get; }
        public static float LocY { set; get; }
        public static string Place { set; get; }
        public static string Address { set; get; }
        public static string PinCode { set; get; }
        public static string DocId { set; get; }
        public static string SystemId { set; get; }
        public static string ClientId { set; get; }
        public static string ServerDetails { set; get; }
        public static string UserType { set; get; } // Single or multiple
        public static string SignType { set; get; }
        public static string SignTypeDefault { set; get; }

        public static string Designation { set; get; }
        public static string Location { set; get; }

        public static string SAPUserName { set; get; }
        public static string isPfxFile { set; get; }
        public static string DesignationCaption { set; get; }

        public static string LocationCaption { set; get; }
    }
    
}