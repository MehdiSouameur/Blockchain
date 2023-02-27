using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    internal class Blockchain
    {
        public List<Block> blocks;

        //Task 2 Variables
        public int mineCount = 0;
        public int mineTimeAverage = 0;
        public int blockchainIndex = 0;
        public int difficulty = 1;

        public List<Transaction> transactionPool = new List<Transaction>();
        int transactionsPerBlock = 5;

        public Blockchain()
        {
            blocks = new List<Block>()
            {
                new Block()
            };
        }

        public String GetBlockAsString(int index)
        {
            return blocks[index].ToString();
        }

        public Block GetLastBlock()
        {
            return blocks[blocks.Count - 1];
        }

        public List<Transaction> GetPendingTransactions()
        {
            int n = Math.Min(transactionsPerBlock, transactionPool.Count);

            List<Transaction> transactions = transactionPool.GetRange(0, n);
            transactionPool.RemoveRange(0, n);

            return transactions;
        }

        public override string ToString()
        {
            String output = String.Empty;
            blocks.ForEach(b => output += (b.ToString() + "\n"));
            return output;
        }

        public double GetBalance(String address)
        {
            double balance = 0.0;
            foreach(Block b in blocks)
            {
                foreach (Transaction t in b.transactionList)
                {
                    if (t.recipientAddress.Equals(address))
                    {
                        balance += t.amount;
                    }
                    if (t.senderAddress.Equals(address))
                    {
                        balance -= (t.amount + t.fee);
                    }

                }
                
            }

            return balance;
        }

        public bool validateMerkleRoot(Block b)
        {
            String reMerkle = Block.MerkleRoot(b.transactionList);
            return reMerkle.Equals(b.merkleRoot);
        }

        //Task 2 Methods
        public void addMineCount(int mineTime)
        {
            this.mineCount += mineTime;
            blockchainIndex++;
        }

        public bool checkBlockchainIndex()
        {
            if(blockchainIndex % 10 == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int getMineCount()
        {
            return mineCount;
        }

        public void setMineCount(int mineCount) {
            this.mineCount = mineCount;

         }
    }
}
