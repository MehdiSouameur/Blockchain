using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        Blockchain blockchain;
        public BlockchainApp()
        {
            InitializeComponent();
            blockchain = new Blockchain();
            richTextBox1.Text = "New Blockchain Initialised";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Update terminal with text
        private void UpdateText(String text)
        {
            richTextBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 0;
            richTextBox1.Text = blockchain.GetBlockAsString(index);
            
        }

        //Generate Wallet
        private void button2_Click(object sender, EventArgs e)
        {
            String privKey;
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out privKey);

            publicKey.Text = myNewWallet.publicID;
            privateKey.Text = privKey;
        }

        //Validate Keys button
        private void button3_Click(object sender, EventArgs e)
        {
            if(Wallet.Wallet.ValidatePrivateKey(privateKey.Text, publicKey.Text))
            {   
                richTextBox1.Text = "Keys are valid";
            } 
            else
            {
                richTextBox1.Text = "Keys are invalid";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Generate New Block
        private void button4_Click(object sender, EventArgs e)
        {
            // Retrieve pending transactions to be added to the newly generated Block
            List<Transaction> transactions = blockchain.GetPendingTransactions();
            int mineCount = blockchain.getMineCount();
            string iterationMessage = "";

            // Create and append the new block - requires a reference to the previous block, a set of transactions and the miners public address (For the reward to be issued)
            Block newBlock = new Block(blockchain.GetLastBlock(), transactions, mineCount, blockchain.difficulty, publicKey.Text);
            int mineTime = newBlock.getMineTime();
            blockchain.addMineCount(mineTime);
            blockchain.blocks.Add(newBlock);

            Console.WriteLine("Mine Count: " + blockchain.getMineCount());

            if(newBlock.mineCountStatus == true)
            {
                blockchain.setMineCount(0);
                iterationMessage = newBlock.newIterationMessage();
            }
            if(newBlock.increaseDifficulty == true)
            {
                blockchain.difficulty++;
            }
            if(newBlock.decreaseDifficulty == true)
            {
                blockchain.difficulty--;
            }


            UpdateText(blockchain.ToString());
            if(iterationMessage != "")
            {
                richTextBox1.Text += iterationMessage;
            }
        }


        //Create Transaction Button
        private void button5_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(publicKey.Text, receiver.Text, Double.Parse(amount.Text), Double.Parse(fee.Text), privateKey.Text);
            blockchain.transactionPool.Add(transaction);
            richTextBox1.Text = transaction.ToString();
        }

        private void validateChain_Click(object sender, EventArgs e)
        {
            //Contiguity Checks
            bool valid = true;

            if(blockchain.blocks.Count == 1)
            {
                if (!blockchain.validateMerkleRoot(blockchain.blocks[0]))
                {
                    richTextBox1.Text = "Blockchain is invalid";
                }
                richTextBox1.Text = "Blockchain is valid";
                return;
            }
            
            for(int i=1; i<blockchain.blocks.Count - 1; i++)
            {
                //Compare neighbouring hash/previous hashs for all blocks in the blockchain 
                if (blockchain.blocks[i].prevHash != blockchain.blocks[i - 1].hash || !blockchain.validateMerkleRoot(blockchain.blocks[i]))
                {
                    richTextBox1.Text = "Blockchain is invalid";
                    return;
                }
            }

            if (valid)
            {
                richTextBox1.Text = "Blockchain is valid";
            }
            else
            {
                richTextBox1.Text = "Blockchain is invalid";
            }
        }

        private void checkBalance_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = blockchain.GetBalance(publicKey.Text).ToString() + "Assignment Coin";
        }


        //Greedy transaction button
        private void greedyTransaction_Click(object sender, EventArgs e)
        {
            if(blockchain.transactionPool.Count != 0)
            {
                blockchain.greedySort();
                richTextBox1.Text = "Transaction order set to Greedy!\nCurrent pending Transactions:\n\n";
                foreach (Transaction transaction in blockchain.transactionPool)
                {
                    richTextBox1.Text += transaction.ToString() + "\n";
                }
            }
            
        }

        //Print pending transactions
        private void printTransactions_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Current pending Transactions:\n\n";
            foreach (Transaction transaction in blockchain.transactionPool)
            {
                richTextBox1.Text += transaction.ToString() + "\n";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void receiver_TextChanged(object sender, EventArgs e)
        {

        }

        //Random transactions button
        private void randomTransaction_Click(object sender, EventArgs e)
        {
            if(blockchain.transactionPool.Count != 0)
            {
                blockchain.randomSort();
                richTextBox1.Text = "Transaction order set to Random!\nCurrent pending Transactions:\n\n";
                foreach (Transaction transaction in blockchain.transactionPool)
                {
                    richTextBox1.Text += transaction.ToString() + "\n";
                }
            }
        }

        private void altruisticTransaction_Click(object sender, EventArgs e)
        {
            if(blockchain.transactionPool.Count != 0)
            {
                blockchain.altruisticSort();
                richTextBox1.Text = "Transaction order set to Altruistic!\nCurrent pending Transactions:\n\n";
                foreach (Transaction transaction in blockchain.transactionPool)
                {
                    richTextBox1.Text += transaction.ToString() + "\n";
                }
            }
        }

        private void addressTransaction_Click(object sender, EventArgs e)
        {
            if(blockchain.transactionPool.Count != 0)
            {
                blockchain.addressSort(transactionAddress.Text);
                richTextBox1.Text = "Transaction order set by address: !" + transactionAddress.Text + "\nCurrent pending Transactions:\n\n";
                foreach (Transaction transaction in blockchain.transactionPool)
                {
                    richTextBox1.Text += transaction.ToString() + "\n";
                }
            }
        }
    }
}
