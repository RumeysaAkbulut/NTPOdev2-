using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using KargoTakip.Models;

public partial class Form1 : Form
{
    private KargoYonetici kargoYonetici;
    private ListBox listBoxGonderiler;
    private Button btnYeniSiparis;
    private Button btnDurumTakip;
    private Button btnKargoAra;
    private Panel headerPanel;
    private Label lblBaslik;
    private Panel buttonPanel;

    public Form1()
    {
        InitializeComponent();
        kargoYonetici = new KargoYonetici();

        
        OrnekVerileriEkle();
        ListeyiGuncelle();
    }

    private void InitializeComponent()
    {
        
        this.Text = "🚚 Express Kargo Takip Merkezi";
        this.Size = new Size(1000, 650);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.FromArgb(245, 248, 250);
        this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

        
        this.headerPanel = new Panel();
        this.headerPanel.Location = new Point(0, 0);
        this.headerPanel.Size = new Size(1000, 80);
        this.headerPanel.BackColor = Color.FromArgb(34, 139, 230);
        this.headerPanel.Dock = DockStyle.Top;

        
        this.lblBaslik = new Label();
        this.lblBaslik.Text = "📦 KARGO YÖNETİM SİSTEMİ";
        this.lblBaslik.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblBaslik.ForeColor = Color.White;
        this.lblBaslik.Location = new Point(30, 25);
        this.lblBaslik.Size = new Size(400, 35);
        this.headerPanel.Controls.Add(this.lblBaslik);

        
        this.listBoxGonderiler = new ListBox();
        this.listBoxGonderiler.Location = new Point(30, 110);
        this.listBoxGonderiler.Size = new Size(940, 380);
        this.listBoxGonderiler.Font = new Font("Consolas", 10F);
        this.listBoxGonderiler.BackColor = Color.White;
        this.listBoxGonderiler.BorderStyle = BorderStyle.FixedSingle;
        this.listBoxGonderiler.SelectionMode = SelectionMode.One;

        
        this.buttonPanel = new Panel();
        this.buttonPanel.Location = new Point(30, 510);
        this.buttonPanel.Size = new Size(940, 70);
        this.buttonPanel.BackColor = Color.Transparent;

        
        this.btnYeniSiparis = new Button();
        this.btnYeniSiparis.Text = "➕ YENİ GÖNDERI";
        this.btnYeniSiparis.Location = new Point(20, 15);
        this.btnYeniSiparis.Size = new Size(180, 45);
        this.btnYeniSiparis.BackColor = Color.FromArgb(76, 175, 80);
        this.btnYeniSiparis.ForeColor = Color.White;
        this.btnYeniSiparis.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnYeniSiparis.FlatStyle = FlatStyle.Flat;
        this.btnYeniSiparis.FlatAppearance.BorderSize = 0;
        this.btnYeniSiparis.Cursor = Cursors.Hand;
        this.btnYeniSiparis.Click += new EventHandler(this.btnGonderiEkle_Click);

        this.btnDurumTakip = new Button();
        this.btnDurumTakip.Text = "🔄 DURUM GÜNCELLE";
        this.btnDurumTakip.Location = new Point(220, 15);
        this.btnDurumTakip.Size = new Size(180, 45);
        this.btnDurumTakip.BackColor = Color.FromArgb(255, 152, 0);
        this.btnDurumTakip.ForeColor = Color.White;
        this.btnDurumTakip.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnDurumTakip.FlatStyle = FlatStyle.Flat;
        this.btnDurumTakip.FlatAppearance.BorderSize = 0;
        this.btnDurumTakip.Cursor = Cursors.Hand;
        this.btnDurumTakip.Click += new EventHandler(this.btnDurumGuncelle_Click);

        this.btnKargoAra = new Button();
        this.btnKargoAra.Text = "🔍 KARGO SORGULA";
        this.btnKargoAra.Location = new Point(420, 15);
        this.btnKargoAra.Size = new Size(180, 45);
        this.btnKargoAra.BackColor = Color.FromArgb(156, 39, 176);
        this.btnKargoAra.ForeColor = Color.White;
        this.btnKargoAra.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnKargoAra.FlatStyle = FlatStyle.Flat;
        this.btnKargoAra.FlatAppearance.BorderSize = 0;
        this.btnKargoAra.Cursor = Cursors.Hand;
        this.btnKargoAra.Click += new EventHandler(this.btnGonderiSorgula_Click);

        
        this.buttonPanel.Controls.Add(this.btnYeniSiparis);
        this.buttonPanel.Controls.Add(this.btnDurumTakip);
        this.buttonPanel.Controls.Add(this.btnKargoAra);

        
        this.Controls.Add(this.headerPanel);
        this.Controls.Add(this.listBoxGonderiler);
        this.Controls.Add(this.buttonPanel);
    }

    private void OrnekVerileriEkle()
    {
        
        var yurticiKargo1 = new YurticiKargo("Ahmet Yılmaz", "Ankara", "Mehmet Demir", "İstanbul", 2.5, "İstanbul", "Kadıköy");
        var yurticiKargo2 = new YurticiKargo("Ayşe Kaya", "İzmir", "Fatma Öz", "Bursa", 1.8, "Bursa", "Osmangazi");

        
        var yurtdisiKargo1 = new Yurtdisi("Ali Veli", "İstanbul", "John Smith", "New York", 3.2, "ABD", "US001");
        var yurtdisiKargo2 = new Yurtdisi("Zeynep Ak", "Ankara", "Marie Dupont", "Paris", 1.5, "Fransa", "FR002");

        
        yurticiKargo1.DurumGuncelle(KargoDurum.Yolda);
        yurtdisiKargo1.DurumGuncelle(KargoDurum.TeslimEdildi);

        kargoYonetici.GonderiEkle(yurticiKargo1);
        kargoYonetici.GonderiEkle(yurticiKargo2);
        kargoYonetici.GonderiEkle(yurtdisiKargo1);
        kargoYonetici.GonderiEkle(yurtdisiKargo2);
    }

    private void ListeyiGuncelle()
    {
        listBoxGonderiler.Items.Clear();
        foreach (var gonderi in kargoYonetici.TumGonderiler())
        {
            listBoxGonderiler.Items.Add(gonderi.TakipBilgisi());
        }
    }

    private void btnGonderiEkle_Click(object sender, EventArgs e)
    {
        using (var form = new GonderiEkleForm())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                kargoYonetici.GonderiEkle(form.YeniGonderi);
                ListeyiGuncelle();
                MessageBox.Show($"✅ Gönderi başarıyla eklendi!\n📋 Takip Numarası: {form.YeniGonderi.TakipNumarasi}",
                               "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void btnDurumGuncelle_Click(object sender, EventArgs e)
    {
        using (var form = new DurumGuncelleForm(kargoYonetici))
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                ListeyiGuncelle();
            }
        }
    }

    private void btnGonderiSorgula_Click(object sender, EventArgs e)
    {
        string takipNo = "";
        using (var inputForm = new InputBoxForm("🔍 Kargo Sorgulama", "📋 Takip numarasını girin:"))
        {
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                takipNo = inputForm.UserInput;
            }
        }

        if (!string.IsNullOrEmpty(takipNo))
        {
            var gonderi = kargoYonetici.GonderiBul(takipNo);
            if (gonderi != null)
            {
                MessageBox.Show($"📦 {gonderi.TakipBilgisi()}", "Kargo Detayları",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("❌ Gönderi bulunamadı!", "Sonuç Bulunamadı",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}


public partial class GonderiEkleForm : Form
{
    public Gonderi YeniGonderi { get; private set; }

    private TextBox txtGonderenAd, txtGonderenAdres, txtAliciAd, txtAliciAdres, txtAgirlik;
    private ComboBox cmbKargoTipi;
    private TextBox txtEkBilgi1, txtEkBilgi2;
    private Label lblEkBilgi1, lblEkBilgi2;
    private Button btnOnay, btnVazgec;
    private Panel headerPanel;
    private Label lblFormBaslik;

    public GonderiEkleForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "➕ Yeni Gönderi Oluştur";
        this.Size = new Size(500, 450);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.BackColor = Color.FromArgb(250, 252, 255);

        
        this.headerPanel = new Panel();
        this.headerPanel.Location = new Point(0, 0);
        this.headerPanel.Size = new Size(500, 60);
        this.headerPanel.BackColor = Color.FromArgb(52, 152, 219);
        this.headerPanel.Dock = DockStyle.Top;

        this.lblFormBaslik = new Label();
        this.lblFormBaslik.Text = "📋 YENİ GÖNDERI FORMU";
        this.lblFormBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblFormBaslik.ForeColor = Color.White;
        this.lblFormBaslik.Location = new Point(20, 18);
        this.lblFormBaslik.Size = new Size(300, 25);
        this.headerPanel.Controls.Add(this.lblFormBaslik);

        
        int y = 90;
        CreateModernLabel("👤 Gönderen:", 30, y);
        txtGonderenAd = CreateModernTextBox(160, y);
        y += 40;

        CreateModernLabel("🏠 Gön. Adres:", 30, y);
        txtGonderenAdres = CreateModernTextBox(160, y);
        y += 40;

        CreateModernLabel("👥 Alıcı:", 30, y);
        txtAliciAd = CreateModernTextBox(160, y);
        y += 40;

        CreateModernLabel("🏢 Alıcı Adres:", 30, y);
        txtAliciAdres = CreateModernTextBox(160, y);
        y += 40;

        CreateModernLabel("⚖️ Ağırlık (kg):", 30, y);
        txtAgirlik = CreateModernTextBox(160, y);
        y += 40;

        CreateModernLabel("📦 Kargo Tipi:", 30, y);
        cmbKargoTipi = new ComboBox();
        cmbKargoTipi.Location = new Point(160, y);
        cmbKargoTipi.Size = new Size(250, 30);
        cmbKargoTipi.Font = new Font("Segoe UI", 10F);
        cmbKargoTipi.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbKargoTipi.Items.AddRange(new[] { "🏠 Yurtiçi Kargo", "🌍 Yurtdışı Kargo" });
        cmbKargoTipi.SelectedIndexChanged += CmbTip_SelectedIndexChanged;
        this.Controls.Add(cmbKargoTipi);
        y += 40;

        lblEkBilgi1 = CreateModernLabel("", 30, y);
        txtEkBilgi1 = CreateModernTextBox(160, y);
        y += 40;

        lblEkBilgi2 = CreateModernLabel("", 30, y);
        txtEkBilgi2 = CreateModernTextBox(160, y);
        y += 50;

        
        btnOnay = new Button();
        btnOnay.Text = "✅ OLUŞTUR";
        btnOnay.Location = new Point(160, y);
        btnOnay.Size = new Size(120, 40);
        btnOnay.BackColor = Color.FromArgb(46, 204, 113);
        btnOnay.ForeColor = Color.White;
        btnOnay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnOnay.FlatStyle = FlatStyle.Flat;
        btnOnay.FlatAppearance.BorderSize = 0;
        btnOnay.Cursor = Cursors.Hand;
        btnOnay.Click += BtnTamam_Click;
        this.Controls.Add(btnOnay);

        btnVazgec = new Button();
        btnVazgec.Text = "❌ VAZGEÇ";
        btnVazgec.Location = new Point(290, y);
        btnVazgec.Size = new Size(120, 40);
        btnVazgec.BackColor = Color.FromArgb(231, 76, 60);
        btnVazgec.ForeColor = Color.White;
        btnVazgec.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnVazgec.FlatStyle = FlatStyle.Flat;
        btnVazgec.FlatAppearance.BorderSize = 0;
        btnVazgec.Cursor = Cursors.Hand;
        btnVazgec.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        this.Controls.Add(btnVazgec);

        this.Controls.Add(this.headerPanel);
    }

    private Label CreateModernLabel(string text, int x, int y)
    {
        var label = new Label();
        label.Text = text;
        label.Location = new Point(x, y);
        label.Size = new Size(120, 25);
        label.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        label.ForeColor = Color.FromArgb(52, 73, 94);
        this.Controls.Add(label);
        return label;
    }

    private TextBox CreateModernTextBox(int x, int y)
    {
        var textBox = new TextBox();
        textBox.Location = new Point(x, y);
        textBox.Size = new Size(250, 25);
        textBox.Font = new Font("Segoe UI", 10F);
        textBox.BorderStyle = BorderStyle.FixedSingle;
        this.Controls.Add(textBox);
        return textBox;
    }

    private void CmbTip_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbKargoTipi.SelectedIndex == 0) 
        {
            lblEkBilgi1.Text = "🏙️ İl:";
            lblEkBilgi2.Text = "🏘️ İlçe:";
        }
        else 
        {
            lblEkBilgi1.Text = "🌍 Ülke:";
            lblEkBilgi2.Text = "🛃 Gümrük Kodu:";
        }
        txtEkBilgi1.Visible = txtEkBilgi2.Visible = true;
        lblEkBilgi1.Visible = lblEkBilgi2.Visible = true;
    }

    private void BtnTamam_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtGonderenAd.Text) || string.IsNullOrEmpty(txtAliciAd.Text) ||
                cmbKargoTipi.SelectedIndex == -1 || string.IsNullOrEmpty(txtAgirlik.Text))
            {
                MessageBox.Show("⚠️ Lütfen tüm alanları eksiksiz doldurun!", "Eksik Bilgi",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double agirlik = double.Parse(txtAgirlik.Text);

            if (cmbKargoTipi.SelectedIndex == 0) 
            {
                YeniGonderi = new YurticiKargo(txtGonderenAd.Text, txtGonderenAdres.Text,
                                               txtAliciAd.Text, txtAliciAdres.Text, agirlik,
                                               txtEkBilgi1.Text, txtEkBilgi2.Text);
            }
            else 
            {
                YeniGonderi = new Yurtdisi(txtGonderenAd.Text, txtGonderenAdres.Text,
                                                txtAliciAd.Text, txtAliciAdres.Text, agirlik,
                                                txtEkBilgi1.Text, txtEkBilgi2.Text);
            }

            this.DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("❌ Hata: " + ex.Message, "İşlem Hatası",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}


public partial class DurumGuncelleForm : Form
{
    private KargoYonetici kargoYonetici;
    private TextBox txtKargoNo;
    private ComboBox cmbYeniDurum;
    private Button btnGuncelle, btnIptal;
    private Panel headerPanel;
    private Label lblFormBaslik;

    public DurumGuncelleForm(KargoYonetici yonetici)
    {
        kargoYonetici = yonetici;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "🔄 Kargo Durum Güncelleme";
        this.Size = new Size(450, 300);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.BackColor = Color.FromArgb(250, 252, 255);

        
        this.headerPanel = new Panel();
        this.headerPanel.Location = new Point(0, 0);
        this.headerPanel.Size = new Size(450, 60);
        this.headerPanel.BackColor = Color.FromArgb(230, 126, 34);
        this.headerPanel.Dock = DockStyle.Top;

        this.lblFormBaslik = new Label();
        this.lblFormBaslik.Text = "🔄 DURUM GÜNCELLEME";
        this.lblFormBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblFormBaslik.ForeColor = Color.White;
        this.lblFormBaslik.Location = new Point(20, 18);
        this.lblFormBaslik.Size = new Size(300, 25);
        this.headerPanel.Controls.Add(this.lblFormBaslik);

        CreateModernLabel("📋 Takip No:", 40, 100);
        txtKargoNo = CreateModernTextBox(160, 100);

        CreateModernLabel("🔄 Yeni Durum:", 40, 150);
        cmbYeniDurum = new ComboBox();
        cmbYeniDurum.Location = new Point(160, 150);
        cmbYeniDurum.Size = new Size(200, 30);
        cmbYeniDurum.Font = new Font("Segoe UI", 10F);
        cmbYeniDurum.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbYeniDurum.Items.AddRange(new[] { "⏳ Hazırlanıyor", "🚛 Yolda", "✅ Teslim Edildi" });
        this.Controls.Add(cmbYeniDurum);

        btnGuncelle = new Button();
        btnGuncelle.Text = "💾 GÜNCELLE";
        btnGuncelle.Location = new Point(120, 210);
        btnGuncelle.Size = new Size(120, 40);
        btnGuncelle.BackColor = Color.FromArgb(52, 152, 219);
        btnGuncelle.ForeColor = Color.White;
        btnGuncelle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnGuncelle.FlatStyle = FlatStyle.Flat;
        btnGuncelle.FlatAppearance.BorderSize = 0;
        btnGuncelle.Cursor = Cursors.Hand;
        btnGuncelle.Click += BtnGuncelle_Click;
        this.Controls.Add(btnGuncelle);

        btnIptal = new Button();
        btnIptal.Text = "❌ İPTAL";
        btnIptal.Location = new Point(260, 210);
        btnIptal.Size = new Size(120, 40);
        btnIptal.BackColor = Color.FromArgb(231, 76, 60);
        btnIptal.ForeColor = Color.White;
        btnIptal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnIptal.FlatStyle = FlatStyle.Flat;
        btnIptal.FlatAppearance.BorderSize = 0;
        btnIptal.Cursor = Cursors.Hand;
        btnIptal.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        this.Controls.Add(btnIptal);

        this.Controls.Add(this.headerPanel);
    }

    private Label CreateModernLabel(string text, int x, int y)
    {
        var label = new Label();
        label.Text = text;
        label.Location = new Point(x, y);
        label.Size = new Size(110, 25);
        label.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        label.ForeColor = Color.FromArgb(52, 73, 94);
        this.Controls.Add(label);
        return label;
    }

    private TextBox CreateModernTextBox(int x, int y)
    {
        var textBox = new TextBox();
        textBox.Location = new Point(x, y);
        textBox.Size = new Size(200, 25);
        textBox.Font = new Font("Segoe UI", 10F);
        textBox.BorderStyle = BorderStyle.FixedSingle;
        this.Controls.Add(textBox);
        return textBox;
    }

    private void BtnGuncelle_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtKargoNo.Text) || cmbYeniDurum.SelectedIndex == -1)
        {
            MessageBox.Show("⚠️ Lütfen tüm alanları doldurun!", "Eksik Bilgi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        KargoDurum yeniDurum = (KargoDurum)cmbYeniDurum.SelectedIndex;

        if (kargoYonetici.DurumGuncelle(txtKargoNo.Text, yeniDurum))
        {
            MessageBox.Show("✅ Durum başarıyla güncellendi!", "İşlem Tamamlandı",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
        else
        {
            MessageBox.Show("❌ Gönderi bulunamadı!", "Kayıt Bulunamadı",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}


public partial class InputBoxForm : Form
{
    public string UserInput { get; private set; }
    private TextBox txtGiriş;
    private Button btnTamam, btnIptal;
    private Panel headerPanel;
    private Label lblFormBaslik;

    public InputBoxForm(string title, string prompt)
    {
        InitializeComponent(title, prompt);
    }

    private void InitializeComponent(string title, string prompt)
    {
        this.Text = title;
        this.Size = new Size(420, 220);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.BackColor = Color.FromArgb(250, 252, 255);

        
        this.headerPanel = new Panel();
        this.headerPanel.Location = new Point(0, 0);
        this.headerPanel.Size = new Size(420, 60);
        this.headerPanel.BackColor = Color.FromArgb(142, 68, 173);
        this.headerPanel.Dock = DockStyle.Top;

        this.lblFormBaslik = new Label();
        this.lblFormBaslik.Text = title;
        this.lblFormBaslik.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        this.lblFormBaslik.ForeColor = Color.White;
        this.lblFormBaslik.Location = new Point(20, 20);
        this.lblFormBaslik.Size = new Size(350, 25);
        this.headerPanel.Controls.Add(this.lblFormBaslik);

        Label lblPrompt = new Label();
        lblPrompt.Text = prompt;
        lblPrompt.Location = new Point(30, 85);
        lblPrompt.Size = new Size(350, 25);
        lblPrompt.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        lblPrompt.ForeColor = Color.FromArgb(52, 73, 94);
        this.Controls.Add(lblPrompt);

        txtGiriş = new TextBox();
        txtGiriş.Location = new Point(30, 115);
        txtGiriş.Size = new Size(350, 25);
        txtGiriş.Font = new Font("Segoe UI", 10F);
        txtGiriş.BorderStyle = BorderStyle.FixedSingle;
        this.Controls.Add(txtGiriş);

        btnTamam = new Button();
        btnTamam.Text = "✅ TAMAM";
        btnTamam.Location = new Point(180, 155);
        btnTamam.Size = new Size(100, 35);
        btnTamam.BackColor = Color.FromArgb(39, 174, 96);
        btnTamam.ForeColor = Color.White;
        btnTamam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnTamam.FlatStyle = FlatStyle.Flat;
        btnTamam.FlatAppearance.BorderSize = 0;
        btnTamam.Cursor = Cursors.Hand;
        btnTamam.Click += (s, e) => {
            UserInput = txtGiriş.Text;
            this.DialogResult = DialogResult.OK;
        };
        this.Controls.Add(btnTamam);

        btnIptal = new Button();
        btnIptal.Text = "❌ İPTAL";
        btnIptal.Location = new Point(290, 155);
        btnIptal.Size = new Size(100, 35);
        btnIptal.BackColor = Color.FromArgb(231, 76, 60);
        btnIptal.ForeColor = Color.White;
        btnIptal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnIptal.FlatStyle = FlatStyle.Flat;
        btnIptal.FlatAppearance.BorderSize = 0;
        btnIptal.Cursor = Cursors.Hand;
        btnIptal.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        this.Controls.Add(btnIptal);

        this.Controls.Add(this.headerPanel);
        this.AcceptButton = btnTamam;
        this.CancelButton = btnIptal;
    }
}
