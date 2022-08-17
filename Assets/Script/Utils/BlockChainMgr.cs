using System.Runtime.InteropServices;

namespace Script.FGui.Utils
{
    public class BlockChainMgr
    {
        private static BlockChainMgr _instance = null;
        
        
        [DllImport("__Internal")]
        private static extern void Web3Connect();
        
        //账户连接
        [DllImport("__Internal")]
        private static extern string ConnectAccount();
        
        [DllImport("__Internal")]
        private static extern void SetConnectAccount(string value);
        
        public static BlockChainMgr getInstance()
        {
            if (BlockChainMgr._instance == null)
            {
                return new BlockChainMgr();
            }
            return BlockChainMgr._instance;
        }

        public void init()
        {
            
        }
    }
}