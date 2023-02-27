using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    internal class Block
    {
        public int index;
        DateTime timestamp;
        public String hash;
        public String prevHash;

        public List<Transaction> transactionList = new List<Transaction>();
        public String merkleRoot;

        public long nonce = 0;
        public int difficulty = 2;

        //Variables for Task1
        public long extraNonce = 5;
   
        private static ManualResetEvent _stopAllThreads = new ManualResetEvent(false);
        CancellationTokenSource cts = new CancellationTokenSource();

        //Variables for Task2
        Stopwatch stopwatch = new Stopwatch();
        public int mineTime;
        public int mineIterations = 1;
        public int mineTimeCount = 0;
        public int mineTimeAverage;
        public int desiredTime = 1500; //Target Time in ms
        public bool mineCountStatus; //Check if we need to change mine iterations
        public bool increaseDifficulty = false; //Check if we need to increase difficulty
        public bool decreaseDifficulty = false; //Check if we need to decrease difficulty
      
        


        //Rewards and fees
        public double reward = 1.0;
        public double fees = 0.0;

        public String minerAddress = String.Empty; 


        //Genesis Block
        public Block()
        {
            this.timestamp = DateTime.Now;
            this.index = 0;
            this.prevHash = String.Empty;
            reward = 0;
            for(int i = 0; i < difficulty; i++)
            {
                this.extraNonce *= 10;
            }

            Console.WriteLine(extraNonce);

            stopwatch.Start();

           
            Thread extraThread = new Thread(() => Mine(extraNonce, cts.Token));
            Thread mainThread = new Thread(() => Mine(nonce, cts.Token));

            extraThread.Start();
            mainThread.Start();

            extraThread.Join();
            mainThread.Join();
            

            stopwatch.Stop();

            mineTime = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);

            
        }
        public Block(String prevHash, int index)
        {
            this.timestamp = DateTime.Now;
            this.prevHash = prevHash;
            this.index = index + 1;
            this.hash = CreateHash();
        }

        public Block(Block lastBlock, List <Transaction> transactions, int blockchainMineTimeCount, int difficulty, String address = "")
        {
            this.timestamp = DateTime.Now;
            this.prevHash = lastBlock.hash;
            this.index = lastBlock.index + 1;
            this.mineIterations = lastBlock.mineIterations;
            this.difficulty = difficulty;

            minerAddress = address;

            transactions.Add(CreateRewardTransaction(transactions));
            transactionList = transactions;

            merkleRoot = MerkleRoot(transactionList);

            stopwatch.Start();

            for(int i = 0; i < mineIterations; i++)
            {
                Thread extraThread = new Thread(() => Mine(extraNonce, cts.Token));
                Thread mainThread = new Thread(() => Mine(nonce, cts.Token));

                extraThread.Start();
                mainThread.Start();

                extraThread.Join();
                mainThread.Join();
            }

            stopwatch.Stop();
          
            mineTime = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("Mine Time " + mineTime + "ms");

            //Add mine time to global count of mine time
            this.mineTimeCount = mineTimeCount + mineTime;

            //When we reach 10th block, do time average of previous 10 blocks and determine whether to increase or decrease mine iterations
            if ((index - 1) % 10 == 0 && index > 1)
            {
                mineCountStatus = true;
                mineTimeAverage = (blockchainMineTimeCount+mineTimeCount) / 10;

                int mineTimePerIteration = mineTimeAverage / mineIterations;
                int newIterations = desiredTime / mineTimePerIteration;
                if(newIterations == 0)
                {
                    newIterations = 1;
                }

                //If we reached lowest point already, decrease difficulty to lower time
                if(mineIterations == 1 && newIterations == 1)
                {
                    if (difficulty > 0)
                    {
                        decreaseDifficulty = true;
                    }
                }

                //If we have too many iterations, increase difficulty to increase time faster
                if(newIterations > 50)
                {
                    increaseDifficulty = true;
                    newIterations = 1;
                }
                mineIterations = newIterations;
                Console.WriteLine("Minecount set to 0");

            }

            Console.WriteLine("Block Mine Time Count: " + mineTimeCount);
            Console.WriteLine("Mine Iterations: " + mineIterations);
            Console.WriteLine("Target Time: " + desiredTime);
            Console.WriteLine("Difficulty: Level " + difficulty);
            if (mineCountStatus)
            {
                Console.WriteLine("Set the minecount to 0, iterations changed ");
                Console.WriteLine("Mine Time Average: " + mineTimeAverage);
            }
            
        }

        public Transaction CreateRewardTransaction(List<Transaction> transactions)
        {
            //Sum the fees
            fees = transactions.Aggregate(0.0, (acc, t) => acc + t.fee);

            //Create reward transaction
            return new Transaction("Mine Rewards", minerAddress, (reward + fees), 0, "");
        }

        public String CreateHash()
        {
            String hash = String.Empty;

            //Concatenate all Block properties for hashing 
            SHA256 hasher = SHA256Managed.Create();
            String input = index.ToString() + timestamp.ToString() + prevHash + nonce.ToString() + reward.ToString() + merkleRoot;

            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            //Convert Hash from byte array to string
            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }
            return hash;
        }

        public String CreateHash(long nonce)
        {
            String hash = String.Empty;

            //Concatenate all Block properties for hashing 
            SHA256 hasher = SHA256Managed.Create();
            String input = index.ToString() + timestamp.ToString() + prevHash + nonce.ToString() + reward.ToString() + merkleRoot;

            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            //Convert Hash from byte array to string
            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }
            return hash;
        }

        public void Mine()
        {
            String hash = CreateHash();

            String re = new string('0', difficulty); //Create a regex string of N (difficulty i.e. 4) 0's

            // Re-hash until criteria is met
            while (!hash.StartsWith(re))
            {
                nonce++; //Increment nonce
                hash = CreateHash();
            }

            this.hash = hash;
        }

        public void Mine(long nonce, CancellationToken cancellationToken)
        {

            String hash = CreateHash(nonce);

            String re = new string('0', difficulty); //Create a regex string of N (difficulty i.e. 4) 0's

            // Re-hash until criteria is met
            while (!hash.StartsWith(re) && !cancellationToken.IsCancellationRequested)
            {
                nonce++; //Increment nonce
                hash = CreateHash(nonce);
                //Console.WriteLine(nonce);
            }
            Console.WriteLine("A thread finished");
            if (!cancellationToken.IsCancellationRequested)
            {
                this.nonce = nonce;
                this.hash = hash;
            }
            cts.Cancel();
           
   
        }

        public static String MerkleRoot(List<Transaction> transactionList)
        {
            List<String> hashes = transactionList.Select(t => t.hash).ToList();
            if(hashes.Count == 0)
            {
                return String.Empty;
            }
            if(hashes.Count == 1)
            {
                return HashCode.HashTools.CombineHash(hashes[0], hashes[0]);
            }
            while(hashes.Count != 1)
            {
                List<String> merkleLeaves = new List<String>();
                for (int i=0; i<hashes.Count; i += 2)
                {
                    if(i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.CombineHash(hashes[i], hashes[i]));
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.CombineHash(hashes[i], hashes[i+1]));
                    }        
                }
                hashes = merkleLeaves;
            }
            return hashes[0];
        }

        public override string ToString()
        {
            String output = String.Empty;
            transactionList.ForEach(t => output += (t.ToString() + "\n"));

            return "Index: " + index.ToString() + 
                "\nTimestamp: " + timestamp.ToString() + 
                "\nPrevious Hash: " + prevHash + 
                "\nHash: " + hash +
                "\nNonce: " + nonce.ToString() +  
                "\nDifficulty: " + difficulty.ToString()   +
                "\nReward: " + reward.ToString() +
                "\nFees: " + fees.ToString() +
                "\nMiner's Address: " + minerAddress +
                "\nTransactions:\n" + output +
                "\nMine Time: " + mineTime + " ms\n";


        }


        public int getMineTime()
        {
            return mineTime;
        }

        public bool getMineCountStatus()
        {
            return mineCountStatus;
        }

        public int getMineIterations()
        {
            return mineIterations;
        }
    }
}
