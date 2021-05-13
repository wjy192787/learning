using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;




namespace PLCconnect
{
    public  class ConnectPLC 
    {

        public bool isPLCConnected = false;
        System.String[] arrData = new string[32];       //Array for 'Data'
        public short[] arrDeviceValue = new short[32];         //Data for 'DeviceValue'    
        public int iReturnCode = 0;
        object plcLock = new object();


        /*The declaration of instance value for ACT controls************************/
        // When you use Dot controls by 'References', you should program as follows;
        public ActUtlTypeLib.ActUtlType lpcom_ReferencesUtlType ;
        

        public ConnectPLC()
        {
            /* Create instance for ACT Controls*************************************/
            lpcom_ReferencesUtlType = new ActUtlTypeLib.ActUtlType();
            /* Set EventHandler for ACT Controls************************************/
            // Create EventHandler(ActUtlType)

            /**************************************************************************/
        }


        /// <summary>
        /// 断开PLC连接
        /// </summary>
        public void ClosePLC()
        {
            int iReturnCode;    //Return code

            //Displayed output data is cleared.

            //
            //Processing of Close method
            //
            try
            {
                //When ActProgType is selected by the radio button,

                //The Close method is executed.
                iReturnCode = lpcom_ReferencesUtlType.Close();

                //When The Close method is succeeded, enable the TextBox of 'LogocalStationNumber'.
                if (iReturnCode == 0)
                {
                    isPLCConnected = false;
                }
                lpcom_ReferencesUtlType = null;
                //The return code of the method is displayed by the hexadecimal.

            }

            //Exception processing
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        #region  "PLC连接"
        public void connectPLC()
        {
            int iReturnCode;                     //Return code
            int iLogicalStationNumber = 1;      //LogicalStationNumber for ActUtlType     
           
            //
            //Processing of Open method
            //
            try
            {
                //Set the value of 'LogicalStationNumber' to the property.
                lpcom_ReferencesUtlType.ActLogicalStationNumber = iLogicalStationNumber;

                ////Set the value of 'Password'.
                //lpcom_ReferencesUtlType.ActPassword = txt_Password.Text;

                //The Open method is executed.
                iReturnCode = lpcom_ReferencesUtlType.Open();
                //}
                //When the Open method is succeeded, disable the TextBox of 'LogocalStationNumber'.
                if (iReturnCode == 0)
                {
                    isPLCConnected = true;
                    Thread PLC_Thread = new Thread(new ThreadStart(PLC_MONITOR));
                    PLC_Thread.IsBackground = true;
                    PLC_Thread.Start();
                }
                //The return code of the method is displayed by the hexadecimal.
            }
            //Exception processing
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// PLC监控线程
        /// </summary>
        public void PLC_MONITOR()
        {
            while (true)
            {
                //ReadPlcData("M2510", out PLC_M2510);
                //ReadPlcData("M2530", out PLC_M2530);
                //ReadPlcData("M2531", out PLC_M2531);
                //ReadPlcData("M2532", out PLC_M2532);
                //ReadPlcData("D4", out PLC_D4);
                //ReadPlcData("D5", out PLC_D5);
                //TextBoxChange(tbM2510, PLC_M2510.ToString());
                //TextBoxChange(tbM2530, PLC_M2530.ToString());
                //TextBoxChange(tbM2531, PLC_M2531.ToString());
                //TextBoxChange(tbM2532, PLC_M2532.ToString());
                //TextBoxChange(tbD4, PLC_D4.ToString());
                //TextBoxChange(tbD5, PLC_D5.ToString());

                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 读取PLC信息
        /// </summary>
        /// <param name="szDevice"></param>
        /// <param name="lplData"></param>
        /// <returns></returns>
        public bool ReadPlcData(string szDevice, out int lplData)
        {
            lock (plcLock)
            {
                int iReturnCode = 0;                //Return code
                lplData = 0;
                try
                {
                    iReturnCode = lpcom_ReferencesUtlType.GetDevice(szDevice, out lplData);
                    if (iReturnCode == 0)
                        return true;
                    else
                        return true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        /// <summary>
        /// 发送PLC信息
        /// </summary>
        /// <param name="szDevice"></param>
        /// <param name="lplData"></param>
        /// <returns></returns>
        public bool WritePlcData(string szDevice, int lplData)
        {
            lock (plcLock)
            {
                int iReturnCode = 0;                //Return code
                try
                {
                    iReturnCode = lpcom_ReferencesUtlType.SetDevice(szDevice, lplData);
                    if (iReturnCode == 0)
                        return true;
                    else
                        return true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        /// <summary>
        /// 软元件参数批量读取
        /// </summary>
        /// <param name="szDevice"></起始地址>
        /// <param name="lSize"></长度/个数>
        /// <param name="lplData"></值>
        /// <returns></returns>
        public bool ReadPlcBlockData(string szDevice, int lSize, out int lplData)
        {

            lplData = 0;
            int iReturnCode = 0;          //Return code
            try
            {
                iReturnCode = lpcom_ReferencesUtlType.ReadDeviceBlock(szDevice, lSize, out lplData);   //lSize表示读取多少个 8位
                if (iReturnCode == 0)
                    return true;
                else
                    return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

    }
}
