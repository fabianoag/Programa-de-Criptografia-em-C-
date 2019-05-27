using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cryptography;

namespace Criptografia
{
    public partial class frmCriptografia : Form
    {
        public frmCriptografia()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            txtEncrypt.Text = Encrypt.EncryptData(txtTextoUsado.Text);
            txtDecrypt.Text = Decrypt.DecryptData(txtEncrypt.Text);
        }

        private void btnExecutaEncrypt_Click(object sender, EventArgs e)
        {
            txtEncrypt.Text = Encrypt.EncryptData(txtTextoUsado.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtDecrypt.Text = Decrypt.DecryptData(txtEncrypt.Text);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDecrypt.Text = "";
            txtEncrypt.Text = "";
            txtTextoUsado.Text = "";
        }
    }
}
