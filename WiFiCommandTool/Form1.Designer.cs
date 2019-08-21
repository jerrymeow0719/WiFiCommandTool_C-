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
            this.Connet_label1 = new System.Windows.Forms.Label();
            this.Connect_button1 = new System.Windows.Forms.Button();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Connect_ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.groupBox_Socket = new System.Windows.Forms.GroupBox();
            this.Socket_button1 = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.Socket_ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.groupBox_URL = new System.Windows.Forms.GroupBox();
            this.URL_textBox2 = new System.Windows.Forms.TextBox();
            this.URL_button2 = new System.Windows.Forms.Button();
            this.URL_button1 = new System.Windows.Forms.Button();
            this.URL_textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.Info_listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_Connect.SuspendLayout();
            this.groupBox_Socket.SuspendLayout();
            this.groupBox_URL.SuspendLayout();
            this.groupBox_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Connect
            // 
            this.groupBox_Connect.Controls.Add(this.Connet_label1);
            this.groupBox_Connect.Controls.Add(this.Connect_button1);
            this.groupBox_Connect.Controls.Add(this.shapeContainer2);
            this.groupBox_Connect.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Connect.Name = "groupBox_Connect";
            this.groupBox_Connect.Size = new System.Drawing.Size(150, 80);
            this.groupBox_Connect.TabIndex = 0;
            this.groupBox_Connect.TabStop = false;
            this.groupBox_Connect.Text = "Connect";
            // 
            // Connet_label1
            // 
            this.Connet_label1.AutoSize = true;
            this.Connet_label1.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Connet_label1.Location = new System.Drawing.Point(6, 64);
            this.Connet_label1.Name = "Connet_label1";
            this.Connet_label1.Size = new System.Drawing.Size(38, 13);
            this.Connet_label1.TabIndex = 3;
            this.Connet_label1.Text = "SSID";
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
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 18);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Connect_ovalShape1});
            this.shapeContainer2.Size = new System.Drawing.Size(144, 59);
            this.shapeContainer2.TabIndex = 2;
            this.shapeContainer2.TabStop = false;
            // 
            // Connect_ovalShape1
            // 
            this.Connect_ovalShape1.FillColor = System.Drawing.Color.Gray;
            this.Connect_ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.Connect_ovalShape1.Location = new System.Drawing.Point(5, 0);
            this.Connect_ovalShape1.Name = "Connect_ovalShape1";
            this.Connect_ovalShape1.Size = new System.Drawing.Size(30, 30);
            // 
            // groupBox_Socket
            // 
            this.groupBox_Socket.Controls.Add(this.Socket_button1);
            this.groupBox_Socket.Controls.Add(this.shapeContainer1);
            this.groupBox_Socket.Location = new System.Drawing.Point(12, 98);
            this.groupBox_Socket.Name = "groupBox_Socket";
            this.groupBox_Socket.Size = new System.Drawing.Size(150, 80);
            this.groupBox_Socket.TabIndex = 0;
            this.groupBox_Socket.TabStop = false;
            this.groupBox_Socket.Text = "Socket";
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
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 18);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.Socket_ovalShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(144, 59);
            this.shapeContainer1.TabIndex = 2;
            this.shapeContainer1.TabStop = false;
            // 
            // Socket_ovalShape1
            // 
            this.Socket_ovalShape1.FillColor = System.Drawing.Color.Gray;
            this.Socket_ovalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.Socket_ovalShape1.Location = new System.Drawing.Point(5, 0);
            this.Socket_ovalShape1.Name = "Socket_ovalShape1";
            this.Socket_ovalShape1.Size = new System.Drawing.Size(30, 30);
            // 
            // groupBox_URL
            // 
            this.groupBox_URL.Controls.Add(this.URL_textBox2);
            this.groupBox_URL.Controls.Add(this.URL_button2);
            this.groupBox_URL.Controls.Add(this.URL_button1);
            this.groupBox_URL.Controls.Add(this.URL_textBox1);
            this.groupBox_URL.Location = new System.Drawing.Point(168, 12);
            this.groupBox_URL.Name = "groupBox_URL";
            this.groupBox_URL.Size = new System.Drawing.Size(345, 86);
            this.groupBox_URL.TabIndex = 1;
            this.groupBox_URL.TabStop = false;
            this.groupBox_URL.Text = "URL";
            // 
            // URL_textBox2
            // 
            this.URL_textBox2.Location = new System.Drawing.Point(276, 58);
            this.URL_textBox2.Name = "URL_textBox2";
            this.URL_textBox2.Size = new System.Drawing.Size(60, 22);
            this.URL_textBox2.TabIndex = 5;
            // 
            // URL_button2
            // 
            this.URL_button2.Location = new System.Drawing.Point(200, 50);
            this.URL_button2.Name = "URL_button2";
            this.URL_button2.Size = new System.Drawing.Size(70, 30);
            this.URL_button2.TabIndex = 3;
            this.URL_button2.Text = "Delay";
            this.URL_button2.UseVisualStyleBackColor = true;
            this.URL_button2.Click += new System.EventHandler(this.URL_button2_Click);
            // 
            // URL_button1
            // 
            this.URL_button1.Location = new System.Drawing.Point(6, 50);
            this.URL_button1.Name = "URL_button1";
            this.URL_button1.Size = new System.Drawing.Size(70, 30);
            this.URL_button1.TabIndex = 1;
            this.URL_button1.Text = "Add";
            this.URL_button1.UseVisualStyleBackColor = true;
            this.URL_button1.Click += new System.EventHandler(this.URL_button1_Click);
            // 
            // URL_textBox1
            // 
            this.URL_textBox1.Location = new System.Drawing.Point(6, 18);
            this.URL_textBox1.Name = "URL_textBox1";
            this.URL_textBox1.Size = new System.Drawing.Size(330, 22);
            this.URL_textBox1.TabIndex = 0;
            this.URL_textBox1.Text = "192.168.1.254/?custom=1&cmd=7001";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 190);
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
            this.groupBox_Info.Location = new System.Drawing.Point(168, 104);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Size = new System.Drawing.Size(345, 116);
            this.groupBox_Info.TabIndex = 2;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "Information";
            // 
            // Info_listView1
            // 
            this.Info_listView1.FullRowSelect = true;
            this.Info_listView1.Location = new System.Drawing.Point(6, 21);
            this.Info_listView1.Name = "Info_listView1";
            this.Info_listView1.Size = new System.Drawing.Size(330, 89);
            this.Info_listView1.TabIndex = 4;
            this.Info_listView1.UseCompatibleStateImageBehavior = false;
            this.Info_listView1.View = System.Windows.Forms.View.List;
            this.Info_listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Info_listView1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 232);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Connect;
        private System.Windows.Forms.GroupBox groupBox_Socket;
        private System.Windows.Forms.Button Connect_button1;
        private System.Windows.Forms.Button Socket_button1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.OvalShape Connect_ovalShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape Socket_ovalShape1;
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
    }
}

