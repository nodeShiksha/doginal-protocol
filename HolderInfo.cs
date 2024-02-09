using System.Numerics;

namespace doginals
{
    public class HolderInfo
    {
        public int rank { get; set; }
        public decimal percentage { get; set; }
        public string address { get; set; }
        public string b58Address { get; set; }
        public BigInteger value { get; set; }
        public bool transferable { get; set; }
        public BigInteger available { get; set; }
    }
}