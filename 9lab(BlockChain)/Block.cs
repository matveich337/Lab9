using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlockChain
{
    class Block
    {
        public int index;
        public string previousHash;
        public DateTime timestamp;
        public string data;
        public string hash;
        public Block(int index, string previousHash, DateTime timestamp, string data, string hash)
        {
            this.index = index;
            this.previousHash = previousHash;
            this.timestamp = timestamp;
            this.data = data;
            this.hash = hash;
        }
    }
}
