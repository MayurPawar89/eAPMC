using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace eAPMC.Classes
{
    public static class MachineDetails
    {
        public class MachineInfo
        {
            public string MachineName = "";
            public string DomainName = "";
            public string UserName = "";
            public string MachineIp = "";
            public string ProgramName = "";
        }
        private static MachineInfo m_localMachine = null;
        private static MachineInfo m_remoteMachine = null;

        public static MachineInfo LocalMachineDetails(bool bReGetDetails = false)
        {
            string LocalIp = string.Empty;
            string Domain = string.Empty;
            NET_API_STATUS status;
            IntPtr bufPtr;
            NETSETUP_JOIN_STATUS GroupType;
            string Host = string.Empty;
            System.Net.IPHostEntry host;
            try
            {
                if ((m_localMachine == null) || (bReGetDetails))
                {
                    Domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                    if (string.IsNullOrEmpty(Domain))
                    {
                        try
                        {
                            Domain = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().ToString();
                        }
                        catch
                        {
                        }
                        if (string.IsNullOrEmpty(Domain))
                        {

                            status = default(NET_API_STATUS);
                            bufPtr = default(IntPtr);
                            GroupType = default(NETSETUP_JOIN_STATUS);

                            try
                            {
                                status = NetGetJoinInformation(null, ref bufPtr, ref GroupType);
                                if (status == NET_API_STATUS.NERR_Success)
                                {
                                    Domain = System.Runtime.InteropServices.Marshal.PtrToStringAuto(bufPtr);
                                }
                            }
                            catch
                            {
                            }
                            finally
                            {
                                if (bufPtr != IntPtr.Zero)
                                {
                                    NetApiBufferFree(bufPtr);
                                }
                            }

                        }
                    }
                    Host = System.Net.Dns.GetHostName();
                    if (string.IsNullOrEmpty(Host))
                    {
                        Host = System.Windows.Forms.SystemInformation.ComputerName;
                    }
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    {


                        host = System.Net.Dns.GetHostEntry(Host);

                        foreach (System.Net.IPAddress ip in host.AddressList)
                        {

                            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {

                                LocalIp = ip.ToString();

                                break;

                            }
                        }
                    }
                    m_localMachine = new MachineInfo();
                    m_localMachine.MachineName = Host;
                    m_localMachine.MachineIp = LocalIp;
                    m_localMachine.UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    m_localMachine.DomainName = Domain;
                    m_localMachine.ProgramName = Assembly.GetEntryAssembly().GetName().Name;
                    //return m_localMachine;
                }
                else
                {
                    //return m_localMachine;
                }
            }
            catch
            { }
            finally
            {
                LocalIp = null;
                Domain = null;
                //status = null;
                //bufPtr = null;
                //GroupType = null;
                Host = null;
                host = null;
            }
            return m_localMachine;
        }
        private static bool foundRemoteCorrectly = false;
        public static MachineInfo RemoteMachineDetails(bool bReGetDetails = false)
        {


            if ((foundRemoteCorrectly == false) || (m_remoteMachine == null) || (bReGetDetails))
            {
                LocalMachineDetails(bReGetDetails);
                string WhoAmI = GetRemoteConnectionType();
                if (WhoAmI == "RDP")
                {
                    foundRemoteCorrectly = true;
                    m_remoteMachine = new MachineInfo();
                    m_remoteMachine.MachineName = GetWTSInformation(WTS_INFO_CLASS.WTSClientName);
                    if (string.IsNullOrEmpty(m_remoteMachine.MachineName))
                    {
                        foundRemoteCorrectly = false;
                        m_remoteMachine.MachineName = m_localMachine.MachineName;
                    }
                    m_remoteMachine.DomainName = GetWTSInformation(WTS_INFO_CLASS.WTSDomainName);
                    if (string.IsNullOrEmpty(m_remoteMachine.DomainName))
                    {
                        foundRemoteCorrectly = false;
                        m_remoteMachine.DomainName = m_localMachine.DomainName;
                    }
                    m_remoteMachine.MachineIp = GetWTSInformation(WTS_INFO_CLASS.WTSClientAddress);
                    if (string.IsNullOrEmpty(m_remoteMachine.MachineIp))
                    {
                        foundRemoteCorrectly = false;
                        m_remoteMachine.MachineIp = m_localMachine.MachineIp;
                    }
                    m_remoteMachine.UserName = GetWTSInformation(WTS_INFO_CLASS.WTSUserName);
                    if (string.IsNullOrEmpty(m_remoteMachine.UserName))
                    {
                        foundRemoteCorrectly = false;
                        m_remoteMachine.UserName = m_localMachine.UserName;
                    }
                    m_remoteMachine.ProgramName = GetWTSInformation(WTS_INFO_CLASS.WTSInitialProgram);
                    if (string.IsNullOrEmpty(m_remoteMachine.ProgramName))
                    {
                        m_remoteMachine.ProgramName = m_localMachine.ProgramName;
                    }

                    return m_remoteMachine;
                }
                else
                {
                    foundRemoteCorrectly = false;
                    m_remoteMachine = LocalMachineDetails(bReGetDetails);
                    return m_remoteMachine;
                }
            }
            else
            {
                return m_remoteMachine;
            }

        }

        private static string GetWTSInformation(WTS_INFO_CLASS whatInfoNeeded)
        {
            IntPtr buffer = IntPtr.Zero;
            Int32 bytesReturned;

            string strClientName = "";
            try
            {
                WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
                bool sucess = WTSQuerySessionInformation(WTS_CURRENT_SERVER_HANDLE, WTS_CURRENT_SESSION, whatInfoNeeded, out buffer, out bytesReturned);
                if (sucess)
                {
                    if (whatInfoNeeded == WTS_INFO_CLASS.WTSClientAddress)
                    {
                        WTS_CLIENT_ADDRESS oClientAddres = new WTS_CLIENT_ADDRESS();
                        try
                        {
                            oClientAddres = (WTS_CLIENT_ADDRESS)System.Runtime.InteropServices.Marshal.PtrToStructure(buffer, oClientAddres.GetType());
                        }
                        catch
                        {
                        }
                        strClientName = oClientAddres.bAddress[2] + "." + oClientAddres.bAddress[3] + "." + oClientAddres.bAddress[4] + "." + oClientAddres.bAddress[5];
                    }
                    else
                    {
                        strClientName = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(buffer);
                    }

                }
            }
            catch
            {
            }

            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    try
                    {
                        WTSFreeMemory(buffer);
                    }
                    catch
                    {
                    }
                    buffer = IntPtr.Zero;
                }
            }
            return strClientName;
        }
        //Structure for Terminal Service Client IP Address
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct WTS_CLIENT_ADDRESS
        {
            public int iAddressFamily;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] bAddress;
        }
        private enum WTS_INFO_CLASS
        {
            WTSInitialProgram = 0,
            WTSApplicationName,
            WTSWorkingDirectory,
            WTSOEMId,
            WTSSessionId,
            WTSUserName,
            WTSWinStationName,
            WTSDomainName,
            WTSConnectState,
            WTSClientBuildNumber,
            WTSClientName,
            WTSClientDirectory,
            WTSClientProductId,
            WTSClientHardwareId,
            WTSClientAddress,
            WTSClientDisplay,
            WTSClientProtocolType

        }
        private enum NET_API_STATUS : uint
        {
            NERR_Success = 0,
            ERROR_NOT_ENOUGH_MEMORY = 8
        }

        private enum NETSETUP_JOIN_STATUS : uint
        {
            NetSetupUnknownStatus = 0,
            NetSetupUnjoined,
            NetSetupWorkgroupName,
            NetSetupDomainName
        }

        [System.Runtime.InteropServices.DllImport("wtsapi32.dll")]
        private static extern bool WTSQuerySessionInformation(System.IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out System.IntPtr ppBuffer, out Int32 pBytesReturned);
        /// <summary>
        /// The WTSFreeMemory function frees memory allocated by a Terminal
        /// Services function.
        /// </summary>
        /// <param name="memory">Pointer to the memory to free.</param>
        [System.Runtime.InteropServices.DllImport("wtsapi32.dll", ExactSpelling = true, SetLastError = false)]
        private static extern void WTSFreeMemory(IntPtr memory);
        [System.Runtime.InteropServices.DllImport("Netapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern NET_API_STATUS NetGetJoinInformation(string lpServer, ref IntPtr lpNameBuffer, ref NETSETUP_JOIN_STATUS bufferType);
        [System.Runtime.InteropServices.DllImport("Netapi32.dll")]
        private static extern NET_API_STATUS NetApiBufferFree(IntPtr Buffer);
        //[System.Runtime.InteropServices.DllImport("wfapi.dll")]
        //private static extern long WFGetActiveProtocol(int SessionId);

        private static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        private const int WTS_CURRENT_SESSION = -1;

        public static string GetRemoteConnectionType()
        {
            IntPtr buffer = IntPtr.Zero;
            Int32 bytesReturned;
            try
            {
                WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
                bool success = WTSQuerySessionInformation(WTS_CURRENT_SERVER_HANDLE, WTS_CURRENT_SESSION, WTS_INFO_CLASS.WTSClientProtocolType, out buffer, out bytesReturned);
                if (success)
                {
                    int ClientProtocolType = System.Runtime.InteropServices.Marshal.ReadInt32(buffer);
                    try
                    {
                        if (buffer != IntPtr.Zero)
                        {
                            try
                            {
                                WTSFreeMemory(buffer);
                            }
                            catch
                            {
                            }
                            buffer = IntPtr.Zero;
                        }

                    }
                    catch
                    {
                    }

                    switch (ClientProtocolType)
                    {

                        case 0:
                            {
                                //long  ResultCode = WFGetActiveProtocol(WTS_CURRENT_SESSION);
                                //switch (ResultCode )
                                //{
                                //    case 0: return "CONSOLE";
                                //    case 1: return "ICA";
                                //    default: return "Others( "+ResultCode.ToString()+" )";
                                //}
                                if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                                {
                                    return "RDP";
                                }
                                else
                                {
                                    return "CONSOLE";
                                }
                            }
                        case 1: if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                            {
                                return "RDP";
                            }
                            else
                            {
                                return "ICA";
                            }
                        case 2: return "RDP";
                        default: if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                            {
                                return "RDP";
                            }
                            else
                            {
                                return "Others( " + ClientProtocolType.ToString() + " )";
                            }
                    }

                }
            }
            catch
            {
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    try
                    {
                        WTSFreeMemory(buffer);
                    }
                    catch
                    {
                    }
                    buffer = IntPtr.Zero;
                }

            }
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                return "RDP";
            }
            else
            {
                return "CONSOLE";
            }
        }

    }
}
