namespace BlockchainAssignment
{
    partial class BlockchainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.publicKey = new System.Windows.Forms.TextBox();
            this.privateKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.createTransaction = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.TextBox();
            this.fee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.receiver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.validateChain = new System.Windows.Forms.Button();
            this.checkBalance = new System.Windows.Forms.Button();
            this.greedyTransaction = new System.Windows.Forms.Button();
            this.printTransactions = new System.Windows.Forms.Button();
            this.randomTransaction = new System.Windows.Forms.Button();
            this.altruisticTransaction = new System.Windows.Forms.Button();
            this.addressTransaction = new System.Windows.Forms.Button();
            this.transactionAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(2, 13);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1050, 451);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 486);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Print Block";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(951, 491);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generate Wallet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(951, 545);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 46);
            this.button3.TabIndex = 5;
            this.button3.Text = "Validate Keys";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(667, 491);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(278, 22);
            this.publicKey.TabIndex = 6;
            // 
            // privateKey
            // 
            this.privateKey.Location = new System.Drawing.Point(667, 517);
            this.privateKey.Name = "privateKey";
            this.privateKey.Size = new System.Drawing.Size(278, 22);
            this.privateKey.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Public Key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Private Key";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(2, 525);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 47);
            this.button4.TabIndex = 10;
            this.button4.Text = "Generate New Block";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // createTransaction
            // 
            this.createTransaction.Location = new System.Drawing.Point(2, 653);
            this.createTransaction.Name = "createTransaction";
            this.createTransaction.Size = new System.Drawing.Size(107, 47);
            this.createTransaction.TabIndex = 11;
            this.createTransaction.Text = "Create Transaction";
            this.createTransaction.UseVisualStyleBackColor = true;
            this.createTransaction.Click += new System.EventHandler(this.button5_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(187, 653);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(53, 22);
            this.amount.TabIndex = 12;
            // 
            // fee
            // 
            this.fee.Location = new System.Drawing.Point(187, 684);
            this.fee.Name = "fee";
            this.fee.Size = new System.Drawing.Size(53, 22);
            this.fee.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 653);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 684);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fee";
            // 
            // receiver
            // 
            this.receiver.Location = new System.Drawing.Point(241, 719);
            this.receiver.Name = "receiver";
            this.receiver.Size = new System.Drawing.Size(278, 22);
            this.receiver.TabIndex = 16;
            this.receiver.TextChanged += new System.EventHandler(this.receiver_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 722);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Receiver Key";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // validateChain
            // 
            this.validateChain.Location = new System.Drawing.Point(822, 597);
            this.validateChain.Name = "validateChain";
            this.validateChain.Size = new System.Drawing.Size(238, 72);
            this.validateChain.TabIndex = 18;
            this.validateChain.Text = "Validate Blockchain";
            this.validateChain.UseVisualStyleBackColor = true;
            this.validateChain.Click += new System.EventHandler(this.validateChain_Click);
            // 
            // checkBalance
            // 
            this.checkBalance.Location = new System.Drawing.Point(822, 545);
            this.checkBalance.Name = "checkBalance";
            this.checkBalance.Size = new System.Drawing.Size(123, 46);
            this.checkBalance.TabIndex = 19;
            this.checkBalance.Text = "Check Balance";
            this.checkBalance.UseVisualStyleBackColor = true;
            this.checkBalance.Click += new System.EventHandler(this.checkBalance_Click);
            // 
            // greedyTransaction
            // 
            this.greedyTransaction.Location = new System.Drawing.Point(436, 654);
            this.greedyTransaction.Name = "greedyTransaction";
            this.greedyTransaction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.greedyTransaction.Size = new System.Drawing.Size(143, 52);
            this.greedyTransaction.TabIndex = 20;
            this.greedyTransaction.Text = "Greedy Transaction";
            this.greedyTransaction.UseVisualStyleBackColor = true;
            this.greedyTransaction.Click += new System.EventHandler(this.greedyTransaction_Click);
            // 
            // printTransactions
            // 
            this.printTransactions.Location = new System.Drawing.Point(2, 719);
            this.printTransactions.Name = "printTransactions";
            this.printTransactions.Size = new System.Drawing.Size(107, 42);
            this.printTransactions.TabIndex = 21;
            this.printTransactions.Text = "Print Transactions";
            this.printTransactions.UseVisualStyleBackColor = true;
            this.printTransactions.Click += new System.EventHandler(this.printTransactions_Click);
            // 
            // randomTransaction
            // 
            this.randomTransaction.Location = new System.Drawing.Point(273, 653);
            this.randomTransaction.Name = "randomTransaction";
            this.randomTransaction.Size = new System.Drawing.Size(143, 52);
            this.randomTransaction.TabIndex = 22;
            this.randomTransaction.Text = "Random Transaction";
            this.randomTransaction.UseVisualStyleBackColor = true;
            this.randomTransaction.Click += new System.EventHandler(this.randomTransaction_Click);
            // 
            // altruisticTransaction
            // 
            this.altruisticTransaction.Location = new System.Drawing.Point(592, 654);
            this.altruisticTransaction.Name = "altruisticTransaction";
            this.altruisticTransaction.Size = new System.Drawing.Size(143, 52);
            this.altruisticTransaction.TabIndex = 23;
            this.altruisticTransaction.Text = "Altruistic Transaction";
            this.altruisticTransaction.UseVisualStyleBackColor = true;
            this.altruisticTransaction.Click += new System.EventHandler(this.altruisticTransaction_Click);
            // 
            // addressTransaction
            // 
            this.addressTransaction.Location = new System.Drawing.Point(592, 719);
            this.addressTransaction.Name = "addressTransaction";
            this.addressTransaction.Size = new System.Drawing.Size(143, 52);
            this.addressTransaction.TabIndex = 24;
            this.addressTransaction.Text = "Address Transaction";
            this.addressTransaction.UseVisualStyleBackColor = true;
            this.addressTransaction.Click += new System.EventHandler(this.addressTransaction_Click);
            // 
            // transactionAddress
            // 
            this.transactionAddress.Location = new System.Drawing.Point(763, 738);
            this.transactionAddress.Name = "transactionAddress";
            this.transactionAddress.Size = new System.Drawing.Size(297, 22);
            this.transactionAddress.TabIndex = 25;
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1065, 780);
            this.Controls.Add(this.transactionAddress);
            this.Controls.Add(this.addressTransaction);
            this.Controls.Add(this.altruisticTransaction);
            this.Controls.Add(this.randomTransaction);
            this.Controls.Add(this.printTransactions);
            this.Controls.Add(this.greedyTransaction);
            this.Controls.Add(this.checkBalance);
            this.Controls.Add(this.validateChain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.receiver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fee);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.createTransaction);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.privateKey);
            this.Controls.Add(this.publicKey);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox publicKey;
        private System.Windows.Forms.TextBox privateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button createTransaction;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.TextBox fee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox receiver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button validateChain;
        private System.Windows.Forms.Button checkBalance;
        private System.Windows.Forms.Button greedyTransaction;
        private System.Windows.Forms.Button printTransactions;
        private System.Windows.Forms.Button randomTransaction;
        private System.Windows.Forms.Button altruisticTransaction;
        private System.Windows.Forms.Button addressTransaction;
        private System.Windows.Forms.TextBox transactionAddress;
    }
}

