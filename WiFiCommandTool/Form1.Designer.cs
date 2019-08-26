namespace WiFiCommandTool
{
    partial class Form1
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
            this.groupBox_Connect = new System.Windows.Forms.GroupBox();
            this.Connect_progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Connet_label1 = new System.Windows.Forms.Label();
            this.Connect_button1 = new System.Windows.Forms.Button();
            this.groupBox_Socket = new System.Windows.Forms.GroupBox();
            this.Socket_progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Socket_button1 = new System.Windows.Forms.Button();
            this.groupBox_URL = new System.Windows.Forms.GroupBox();
            this.URL_textBox2 = new System.Windows.Forms.TextBox();
            this.URL_button2 = new System.Windows.Forms.Button();
            this.URL_button1 = new System.Windows.Forms.Button();
            this.URL_textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.Info_listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabControl1_tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1_tabPage1_button1 = new System.Windows.Forms.Button();
            this.tabControl1_tabPage1_label2 = new System.Windows.Forms.Label();
            this.tabControl1_tabPage1_label1 = new System.Windows.Forms.Label();
            this.tabControl1_tabPage1_textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1_tabPage1_textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1_tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1_tabPage2_button1 = new System.Windows.Forms.Button();
            this.tabControl1_tabPage2_label1 = new System.Windows.Forms.Label();
            this.tabControl1_tabPage2_textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1_tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1_tabPage3_button1 = new System.Windows.Forms.Button();
            this.tabControl1_tabPage3_label2 = new System.Windows.Forms.Label();
            this.tabControl1_tabPage3_textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1_tabPage3_label1 = new System.Windows.Forms.Label();
            this.tabControl1_tabPage3_textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox_Note = new System.Windows.Forms.GroupBox();
            this.Note_textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox_Connect.SuspendLayout();
            this.groupBox_Socket.SuspendLayout();
            this.groupBox_URL.SuspendLayout();
            this.groupBox_Info.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabControl1_tabPage1.SuspendLayout();
            this.tabControl1_tabPage2.SuspendLayout();
            this.tabControl1_tabPage3.SuspendLayout();
            this.groupBox_Note.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Connect
            // 
            this.groupBox_Connect.Controls.Add(this.Connect_progressBar1);
            this.groupBox_Connect.Controls.Add(this.Connet_label1);
            this.groupBox_Connect.Controls.Add(this.Connect_button1);
            this.groupBox_Connect.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_Connect.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Connect.Name = "groupBox_Connect";
            this.groupBox_Connect.Size = new System.Drawing.Size(150, 80);
            this.groupBox_Connect.TabIndex = 0;
            this.groupBox_Connect.TabStop = false;
            this.groupBox_Connect.Text = "Connect";
            // 
            // Connect_progressBar1
            // 
            this.Connect_progressBar1.Location = new System.Drawing.Point(9, 22);
            this.Connect_progressBar1.Name = "Connect_progressBar1";
            this.Connect_progressBar1.Size = new System.Drawing.Size(52, 23);
            this.Connect_progressBar1.TabIndex = 4;
            // 
            // Connet_label1
            // 
            this.Connet_label1.AutoSize = true;
            this.Connet_label1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Connet_label1.Location = new System.Drawing.Point(6, 64);
            this.Connet_label1.Name = "Connet_label1";
            this.Connet_label1.Size = new System.Drawing.Size(101, 13);
            this.Connet_label1.TabIndex = 3;
            this.Connet_label1.Text = "Connected SSID";
            // 
            // Connect_button1
            // 
            this.Connect_button1.Location = new System.Drawing.Point(67, 18);
            this.Connect_button1.Name = "Connect_button1";
            this.Connect_button1.Size = new System.Drawing.Size(70, 30);
            this.Connect_button1.TabIndex = 0;
            this.Connect_button1.Text = "Connect";
            this.Connect_button1.UseVisualStyleBackColor = true;
            this.Connect_button1.Click += new System.EventHandler(this.Connect_button1_Click);
            // 
            // groupBox_Socket
            // 
            this.groupBox_Socket.Controls.Add(this.Socket_progressBar1);
            this.groupBox_Socket.Controls.Add(this.Socket_button1);
            this.groupBox_Socket.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_Socket.Location = new System.Drawing.Point(12, 98);
            this.groupBox_Socket.Name = "groupBox_Socket";
            this.groupBox_Socket.Size = new System.Drawing.Size(150, 80);
            this.groupBox_Socket.TabIndex = 0;
            this.groupBox_Socket.TabStop = false;
            this.groupBox_Socket.Text = "Socket";
            // 
            // Socket_progressBar1
            // 
            this.Socket_progressBar1.Location = new System.Drawing.Point(9, 22);
            this.Socket_progressBar1.Name = "Socket_progressBar1";
            this.Socket_progressBar1.Size = new System.Drawing.Size(52, 23);
            this.Socket_progressBar1.TabIndex = 5;
            // 
            // Socket_button1
            // 
            this.Socket_button1.Location = new System.Drawing.Point(67, 18);
            this.Socket_button1.Name = "Socket_button1";
            this.Socket_button1.Size = new System.Drawing.Size(70, 30);
            this.Socket_button1.TabIndex = 1;
            this.Socket_button1.Text = "Socket";
            this.Socket_button1.UseVisualStyleBackColor = true;
            this.Socket_button1.Click += new System.EventHandler(this.Socket_button1_Click);
            // 
            // groupBox_URL
            // 
            this.groupBox_URL.Controls.Add(this.URL_textBox2);
            this.groupBox_URL.Controls.Add(this.URL_button2);
            this.groupBox_URL.Controls.Add(this.URL_button1);
            this.groupBox_URL.Controls.Add(this.URL_textBox1);
            this.groupBox_URL.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_URL.Location = new System.Drawing.Point(168, 98);
            this.groupBox_URL.Name = "groupBox_URL";
            this.groupBox_URL.Size = new System.Drawing.Size(345, 80);
            this.groupBox_URL.TabIndex = 1;
            this.groupBox_URL.TabStop = false;
            this.groupBox_URL.Text = "URL";
            // 
            // URL_textBox2
            // 
            this.URL_textBox2.Location = new System.Drawing.Point(200, 51);
            this.URL_textBox2.Name = "URL_textBox2";
            this.URL_textBox2.Size = new System.Drawing.Size(65, 23);
            this.URL_textBox2.TabIndex = 5;
            // 
            // URL_button2
            // 
            this.URL_button2.Location = new System.Drawing.Point(271, 46);
            this.URL_button2.Name = "URL_button2";
            this.URL_button2.Size = new System.Drawing.Size(70, 30);
            this.URL_button2.TabIndex = 3;
            this.URL_button2.Text = "Delay";
            this.URL_button2.UseVisualStyleBackColor = true;
            this.URL_button2.Click += new System.EventHandler(this.URL_button2_Click);
            // 
            // URL_button1
            // 
            this.URL_button1.Location = new System.Drawing.Point(6, 46);
            this.URL_button1.Name = "URL_button1";
            this.URL_button1.Size = new System.Drawing.Size(70, 30);
            this.URL_button1.TabIndex = 1;
            this.URL_button1.Text = "Add";
            this.URL_button1.UseVisualStyleBackColor = true;
            this.URL_button1.Click += new System.EventHandler(this.URL_button1_Click);
            // 
            // URL_textBox1
            // 
            this.URL_textBox1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.URL_textBox1.Location = new System.Drawing.Point(6, 18);
            this.URL_textBox1.Name = "URL_textBox1";
            this.URL_textBox1.Size = new System.Drawing.Size(335, 22);
            this.URL_textBox1.TabIndex = 0;
            this.URL_textBox1.Text = "http://192.168.1.254/?custom=1&";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(88, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Controls.Add(this.Info_listView1);
            this.groupBox_Info.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_Info.Location = new System.Drawing.Point(169, 184);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(345, 111);
            this.groupBox_Info.TabIndex = 2;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "Information";
            // 
            // Info_listView1
            // 
            this.Info_listView1.FullRowSelect = true;
            this.Info_listView1.Location = new System.Drawing.Point(6, 21);
            this.Info_listView1.Name = "Info_listView1";
            this.Info_listView1.Size = new System.Drawing.Size(334, 84);
            this.Info_listView1.TabIndex = 4;
            this.Info_listView1.UseCompatibleStateImageBehavior = false;
            this.Info_listView1.View = System.Windows.Forms.View.List;
            this.Info_listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Info_listView1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(12, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabControl1_tabPage1);
            this.tabControl1.Controls.Add(this.tabControl1_tabPage2);
            this.tabControl1.Controls.Add(this.tabControl1_tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(168, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(345, 71);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabControl1_tabPage1
            // 
            this.tabControl1_tabPage1.Controls.Add(this.tabControl1_tabPage1_button1);
            this.tabControl1_tabPage1.Controls.Add(this.tabControl1_tabPage1_label2);
            this.tabControl1_tabPage1.Controls.Add(this.tabControl1_tabPage1_label1);
            this.tabControl1_tabPage1.Controls.Add(this.tabControl1_tabPage1_textBox2);
            this.tabControl1_tabPage1.Controls.Add(this.tabControl1_tabPage1_textBox1);
            this.tabControl1_tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabControl1_tabPage1.Name = "tabControl1_tabPage1";
            this.tabControl1_tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl1_tabPage1.Size = new System.Drawing.Size(337, 42);
            this.tabControl1_tabPage1.TabIndex = 0;
            this.tabControl1_tabPage1.Text = "Command";
            this.tabControl1_tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1_tabPage1_button1
            // 
            this.tabControl1_tabPage1_button1.Location = new System.Drawing.Point(272, 13);
            this.tabControl1_tabPage1_button1.Name = "tabControl1_tabPage1_button1";
            this.tabControl1_tabPage1_button1.Size = new System.Drawing.Size(59, 26);
            this.tabControl1_tabPage1_button1.TabIndex = 8;
            this.tabControl1_tabPage1_button1.Text = "Enter";
            this.tabControl1_tabPage1_button1.UseVisualStyleBackColor = true;
            this.tabControl1_tabPage1_button1.Click += new System.EventHandler(this.tabControl1_tabPage1_button1_Click);
            // 
            // tabControl1_tabPage1_label2
            // 
            this.tabControl1_tabPage1_label2.AutoSize = true;
            this.tabControl1_tabPage1_label2.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1_tabPage1_label2.Location = new System.Drawing.Point(104, 16);
            this.tabControl1_tabPage1_label2.Name = "tabControl1_tabPage1_label2";
            this.tabControl1_tabPage1_label2.Size = new System.Drawing.Size(31, 12);
            this.tabControl1_tabPage1_label2.TabIndex = 7;
            this.tabControl1_tabPage1_label2.Text = "參數";
            // 
            // tabControl1_tabPage1_label1
            // 
            this.tabControl1_tabPage1_label1.AutoSize = true;
            this.tabControl1_tabPage1_label1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1_tabPage1_label1.Location = new System.Drawing.Point(6, 16);
            this.tabControl1_tabPage1_label1.Name = "tabControl1_tabPage1_label1";
            this.tabControl1_tabPage1_label1.Size = new System.Drawing.Size(31, 12);
            this.tabControl1_tabPage1_label1.TabIndex = 6;
            this.tabControl1_tabPage1_label1.Text = "編號";
            // 
            // tabControl1_tabPage1_textBox2
            // 
            this.tabControl1_tabPage1_textBox2.Location = new System.Drawing.Point(141, 13);
            this.tabControl1_tabPage1_textBox2.Name = "tabControl1_tabPage1_textBox2";
            this.tabControl1_tabPage1_textBox2.Size = new System.Drawing.Size(55, 23);
            this.tabControl1_tabPage1_textBox2.TabIndex = 5;
            // 
            // tabControl1_tabPage1_textBox1
            // 
            this.tabControl1_tabPage1_textBox1.Location = new System.Drawing.Point(43, 13);
            this.tabControl1_tabPage1_textBox1.Name = "tabControl1_tabPage1_textBox1";
            this.tabControl1_tabPage1_textBox1.Size = new System.Drawing.Size(55, 23);
            this.tabControl1_tabPage1_textBox1.TabIndex = 0;
            // 
            // tabControl1_tabPage2
            // 
            this.tabControl1_tabPage2.Controls.Add(this.tabControl1_tabPage2_button1);
            this.tabControl1_tabPage2.Controls.Add(this.tabControl1_tabPage2_label1);
            this.tabControl1_tabPage2.Controls.Add(this.tabControl1_tabPage2_textBox1);
            this.tabControl1_tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabControl1_tabPage2.Name = "tabControl1_tabPage2";
            this.tabControl1_tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl1_tabPage2.Size = new System.Drawing.Size(337, 42);
            this.tabControl1_tabPage2.TabIndex = 1;
            this.tabControl1_tabPage2.Text = "Liveview";
            this.tabControl1_tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1_tabPage2_button1
            // 
            this.tabControl1_tabPage2_button1.Location = new System.Drawing.Point(272, 13);
            this.tabControl1_tabPage2_button1.Name = "tabControl1_tabPage2_button1";
            this.tabControl1_tabPage2_button1.Size = new System.Drawing.Size(59, 26);
            this.tabControl1_tabPage2_button1.TabIndex = 9;
            this.tabControl1_tabPage2_button1.Text = "Enter";
            this.tabControl1_tabPage2_button1.UseVisualStyleBackColor = true;
            this.tabControl1_tabPage2_button1.Click += new System.EventHandler(this.tabControl1_tabPage2_button1_Click);
            // 
            // tabControl1_tabPage2_label1
            // 
            this.tabControl1_tabPage2_label1.AutoSize = true;
            this.tabControl1_tabPage2_label1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1_tabPage2_label1.Location = new System.Drawing.Point(6, 16);
            this.tabControl1_tabPage2_label1.Name = "tabControl1_tabPage2_label1";
            this.tabControl1_tabPage2_label1.Size = new System.Drawing.Size(31, 12);
            this.tabControl1_tabPage2_label1.TabIndex = 8;
            this.tabControl1_tabPage2_label1.Text = "埠號";
            // 
            // tabControl1_tabPage2_textBox1
            // 
            this.tabControl1_tabPage2_textBox1.Location = new System.Drawing.Point(43, 13);
            this.tabControl1_tabPage2_textBox1.Name = "tabControl1_tabPage2_textBox1";
            this.tabControl1_tabPage2_textBox1.Size = new System.Drawing.Size(55, 23);
            this.tabControl1_tabPage2_textBox1.TabIndex = 7;
            // 
            // tabControl1_tabPage3
            // 
            this.tabControl1_tabPage3.Controls.Add(this.tabControl1_tabPage3_button1);
            this.tabControl1_tabPage3.Controls.Add(this.tabControl1_tabPage3_label2);
            this.tabControl1_tabPage3.Controls.Add(this.tabControl1_tabPage3_textBox2);
            this.tabControl1_tabPage3.Controls.Add(this.tabControl1_tabPage3_label1);
            this.tabControl1_tabPage3.Controls.Add(this.tabControl1_tabPage3_textBox1);
            this.tabControl1_tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabControl1_tabPage3.Name = "tabControl1_tabPage3";
            this.tabControl1_tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl1_tabPage3.Size = new System.Drawing.Size(337, 42);
            this.tabControl1_tabPage3.TabIndex = 2;
            this.tabControl1_tabPage3.Text = "FileSystem";
            this.tabControl1_tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl1_tabPage3_button1
            // 
            this.tabControl1_tabPage3_button1.Location = new System.Drawing.Point(272, 13);
            this.tabControl1_tabPage3_button1.Name = "tabControl1_tabPage3_button1";
            this.tabControl1_tabPage3_button1.Size = new System.Drawing.Size(59, 26);
            this.tabControl1_tabPage3_button1.TabIndex = 11;
            this.tabControl1_tabPage3_button1.Text = "Enter";
            this.tabControl1_tabPage3_button1.UseVisualStyleBackColor = true;
            this.tabControl1_tabPage3_button1.Click += new System.EventHandler(this.tabControl1_tabPage3_button1_Click);
            // 
            // tabControl1_tabPage3_label2
            // 
            this.tabControl1_tabPage3_label2.AutoSize = true;
            this.tabControl1_tabPage3_label2.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1_tabPage3_label2.Location = new System.Drawing.Point(104, 16);
            this.tabControl1_tabPage3_label2.Name = "tabControl1_tabPage3_label2";
            this.tabControl1_tabPage3_label2.Size = new System.Drawing.Size(31, 12);
            this.tabControl1_tabPage3_label2.TabIndex = 10;
            this.tabControl1_tabPage3_label2.Text = "動作";
            // 
            // tabControl1_tabPage3_textBox2
            // 
            this.tabControl1_tabPage3_textBox2.Location = new System.Drawing.Point(141, 13);
            this.tabControl1_tabPage3_textBox2.Name = "tabControl1_tabPage3_textBox2";
            this.tabControl1_tabPage3_textBox2.Size = new System.Drawing.Size(55, 23);
            this.tabControl1_tabPage3_textBox2.TabIndex = 9;
            // 
            // tabControl1_tabPage3_label1
            // 
            this.tabControl1_tabPage3_label1.AutoSize = true;
            this.tabControl1_tabPage3_label1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1_tabPage3_label1.Location = new System.Drawing.Point(6, 16);
            this.tabControl1_tabPage3_label1.Name = "tabControl1_tabPage3_label1";
            this.tabControl1_tabPage3_label1.Size = new System.Drawing.Size(31, 12);
            this.tabControl1_tabPage3_label1.TabIndex = 8;
            this.tabControl1_tabPage3_label1.Text = "檔案";
            // 
            // tabControl1_tabPage3_textBox1
            // 
            this.tabControl1_tabPage3_textBox1.Location = new System.Drawing.Point(43, 13);
            this.tabControl1_tabPage3_textBox1.Name = "tabControl1_tabPage3_textBox1";
            this.tabControl1_tabPage3_textBox1.Size = new System.Drawing.Size(55, 23);
            this.tabControl1_tabPage3_textBox1.TabIndex = 7;
            // 
            // groupBox_Note
            // 
            this.groupBox_Note.Controls.Add(this.Note_textBox1);
            this.groupBox_Note.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_Note.Location = new System.Drawing.Point(12, 184);
            this.groupBox_Note.Name = "groupBox_Note";
            this.groupBox_Note.Size = new System.Drawing.Size(150, 111);
            this.groupBox_Note.TabIndex = 5;
            this.groupBox_Note.TabStop = false;
            this.groupBox_Note.Text = "Note";
            // 
            // Note_textBox1
            // 
            this.Note_textBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Note_textBox1.Location = new System.Drawing.Point(3, 21);
            this.Note_textBox1.Multiline = true;
            this.Note_textBox1.Name = "Note_textBox1";
            this.Note_textBox1.ReadOnly = true;
            this.Note_textBox1.Size = new System.Drawing.Size(144, 84);
            this.Note_textBox1.TabIndex = 3;
            this.Note_textBox1.Text = "1.手動完成連線\r\n2.點選Connect按鈕\r\n3.鍵入指令後點選Enter\r\n4.確認URL後點選Add\r\n5.指令流程完成後點選Start";
            //
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(439, 301);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 30);
            this.button3.TabIndex = 6;
            this.button3.Text = "Load\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 343);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox_Note);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox_Info);
            this.Controls.Add(this.groupBox_URL);
            this.Controls.Add(this.groupBox_Socket);
            this.Controls.Add(this.groupBox_Connect);
            this.Name = "Form1";
            this.Text = "WiFi Command Tool";
            this.groupBox_Connect.ResumeLayout(false);
            this.groupBox_Connect.PerformLayout();
            this.groupBox_Socket.ResumeLayout(false);
            this.groupBox_URL.ResumeLayout(false);
            this.groupBox_URL.PerformLayout();
            this.groupBox_Info.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabControl1_tabPage1.ResumeLayout(false);
            this.tabControl1_tabPage1.PerformLayout();
            this.tabControl1_tabPage2.ResumeLayout(false);
            this.tabControl1_tabPage2.PerformLayout();
            this.tabControl1_tabPage3.ResumeLayout(false);
            this.tabControl1_tabPage3.PerformLayout();
            this.groupBox_Note.ResumeLayout(false);
            this.groupBox_Note.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Connect;
        private System.Windows.Forms.GroupBox groupBox_Socket;
        private System.Windows.Forms.Button Connect_button1;
        private System.Windows.Forms.Button Socket_button1;
        private System.Windows.Forms.GroupBox groupBox_URL;
        private System.Windows.Forms.TextBox URL_textBox1;
        private System.Windows.Forms.Button URL_button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox_Info;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView Info_listView1;
        private System.Windows.Forms.TextBox URL_textBox2;
        private System.Windows.Forms.Button URL_button2;
        private System.Windows.Forms.Label Connet_label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabControl1_tabPage1;
        private System.Windows.Forms.TabPage tabControl1_tabPage2;
        private System.Windows.Forms.TabPage tabControl1_tabPage3;
        private System.Windows.Forms.Label tabControl1_tabPage1_label2;
        private System.Windows.Forms.Label tabControl1_tabPage1_label1;
        private System.Windows.Forms.TextBox tabControl1_tabPage1_textBox2;
        private System.Windows.Forms.TextBox tabControl1_tabPage1_textBox1;
        private System.Windows.Forms.Button tabControl1_tabPage1_button1;
        private System.Windows.Forms.Button tabControl1_tabPage2_button1;
        private System.Windows.Forms.Label tabControl1_tabPage2_label1;
        private System.Windows.Forms.TextBox tabControl1_tabPage2_textBox1;
        private System.Windows.Forms.Button tabControl1_tabPage3_button1;
        private System.Windows.Forms.Label tabControl1_tabPage3_label2;
        private System.Windows.Forms.TextBox tabControl1_tabPage3_textBox2;
        private System.Windows.Forms.Label tabControl1_tabPage3_label1;
        private System.Windows.Forms.TextBox tabControl1_tabPage3_textBox1;
        private System.Windows.Forms.GroupBox groupBox_Note;
        private System.Windows.Forms.TextBox Note_textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar Connect_progressBar1;
        private System.Windows.Forms.ProgressBar Socket_progressBar1;
    }
}

