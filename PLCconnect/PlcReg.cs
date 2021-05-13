using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vision.Peripheral
{
    public static class PlcReg
    {    
        //继电器控制
        //写
        //public const int M_ScanQrComplete = 756;
        //public const int M_CheckOutOK = 764;
        //public const int M_CheckOutNG = 772;
        //public const int M_SoftReady = 780;
        //public const int M_PeripheralException = 788;
        //public const int M_CameraLightOn = 796;
        //public const int M_CongexScanComplete = 804;
        //public const int M_ProductBarcodeNG = 812;

        public const string M_FetchA1 = "M560";
        public const string M_FetchA0 = "M580";
        public const string M_FetchB1 = "M570";
        public const string M_FetchB0 = "M590";

        public const string M_Error = "M830";
        public const string M_AutoRun = "M100";
        public const string M_PrintScannerReadOK = "M510";
        public const string M_CheckScannerAReadOK = "M301";
        public const string M_CheckScannerBReadOK = "M401";
        public const string M_APickup = "M760";
        public const string M_BPickup = "M770";
        public const string M_ALabelOK = "M790";
        public const string M_BLabelOK = "M800";
        public const string M_PrintAOrderWriteOK = "M740";
        public const string M_PrintAOrderWriteNG = "M210";
        public const string M_PrintBOrderWriteOK = "M750";
        public const string M_PrintBOrderWriteNG = "M210";
        public const string M_PrintA0PaperOut = "M530";
        public const string M_PrintA1PaperOut = "M520";
        public const string M_PrintB0PaperOut = "M550";
        public const string M_PrintB1PaperOut = "M540";

        public const string M_PastePosition ="D110";

        //读
        //public const int M_LocateComplete = 750;
        //public const int M_ReadQrCode = 751;
        //public const int M_MachineAutoRun = 752;
        public const string M_PrintScannerReadError = "M810";
        public const string M_ProductReadError = "M820";
        public const string M_CheckScannerAReadError = "M753";
        public const string M_CheckScannerBReadError = "M753";
        public const string M_PrintScannerStart = "M780";
        public const string M_CheckScannerStart = "M300";


    }
}
