using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            string ComputeSha256Hash(string rawData)
            {
                // Create a SHA256   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            string calculateHash(int index, string previousHash, DateTime timestamp, string data)
            {
                return ComputeSha256Hash(Convert.ToString(index) + Convert.ToString(previousHash) + Convert.ToString(timestamp) + Convert.ToString(data));
            }

            Block getGenesisBlock()
            {
                DateTime aDateTime = new DateTime(2005, 11, 20, 12, 1, 10);
                return new Block(0, "0", aDateTime, "my genesis block!!", "816534932c2b7154836da6afc367695e6337db8a921823784c14378abed4f7d7");
            }
            List<Block> blockchain = new List<Block>();
            blockchain.Add(getGenesisBlock());

            Block getLatestBlock()
            {
                return blockchain[blockchain.Count - 1];
            }
            Block generateNextBlock(string blockData)
            {
                Block previousBlock = getLatestBlock();
                int nextIndex = previousBlock.index + 1;
                DateTime nextTimestamp = DateTime.Now;
                string nextHash = calculateHash(nextIndex, previousBlock.hash, nextTimestamp, blockData);
                return new Block(nextIndex, previousBlock.hash, nextTimestamp, blockData, nextHash);
            }
            string calculateHashForBlock(Block block){
                return calculateHash(block.index, block.previousHash, block.timestamp, block.data);
            }
            bool isValidNewBlock(Block newBlock, Block previousBlock)
            {
                if(previousBlock.index + 1 != newBlock.index)
                {
                    Console.WriteLine("Invalid index!");
                    return false;
                }
                else if (previousBlock.hash != newBlock.previousHash)
                {
                    Console.WriteLine("Invalid hash of previous block");
                    return false;
                }
                else if (calculateHashForBlock(newBlock) != newBlock.hash)
                {
                    Console.WriteLine("Invalid hash! " + calculateHashForBlock(newBlock) + ' ' + newBlock.hash);
                    return false;
                }
                return true;
            }

            bool isValidChain(List<Block> blockchainToValidate){
                if ((blockchainToValidate[0]) != (getGenesisBlock()))
                {
                    return false;
                }
                List<Block> tempBlocks = new List<Block>();
                tempBlocks.Add(blockchainToValidate[0]);
                for (var i = 1; i < blockchainToValidate.Count; i++)
                {
                    if (isValidNewBlock(blockchainToValidate[i], tempBlocks[i - 1]))
                    {
                        tempBlocks.Add(blockchainToValidate[i]);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            void responseLatestMsg()
            {

            }

            void replaceChain(List<Block> newBlocks){
                if (isValidChain(newBlocks) && newBlocks.Count > blockchain.Count)
                {
                    Console.WriteLine("Received blockchain is valid. Replacing current blockchain with received blockchain");
                    blockchain = newBlocks;                    
                }
                else
                {
                    Console.WriteLine("Received blockchain invalid");
                }
            }

        }
    }
}